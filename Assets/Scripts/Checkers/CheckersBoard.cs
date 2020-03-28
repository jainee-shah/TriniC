using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckersBoard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8, 8];
    public GameObject whitePiecePrefab;     // stores the prefab for the white checkers piece
    public GameObject blackPiecePrefab;     // stores the prefab for the black checkers piece
    /*  board offset and piece offset use Vector3 to adjust the position of the checkers pieces
    *   makes sure that each team has the first three rows of black squares filled in       */    private Vector3 boardOffset = new Vector3(-3.0f, 0.596f, -3.0f);    // board offset
    private Vector3 pieceOffset = new Vector3(-0.48f, 0, -0.55f);       // piece offset

    private bool isWhite;
    private bool isWhiteTurn;
    private bool hasKilled;

    private Piece selectedPiece;
    private List<Piece> forcedPieces = new List<Piece>();

    private Vector2 mouseOver;  // where the cursor will be
    private Vector2 startDrag;
    private Vector2 endDrag;

    public TextMesh winText;    // Displays who won

    private void Start()
    {
        isWhiteTurn = true;
        isWhite = true;
        forcedPieces = new List<Piece>();
        GenerateBoard();
    }

    private void Update()
    {
        UpdateMouseOver();

        // Debug.Log(mouseOver); // checks position of mouseOver

        // if it is player 1's turn
        if(isWhite ? isWhiteTurn :  !isWhiteTurn)
        {
            int x = (int)mouseOver.x;
            int y = (int)mouseOver.y;

            if (selectedPiece != null)
            {
                UpdatePieceDrag(selectedPiece);
            }

            if (Input.GetMouseButtonDown(0))
            {
                SelectPiece(x, y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                TryMove((int)startDrag.x, (int)startDrag.y, x, y);
            }
        }

    }

    private void UpdateMouseOver()
    {
        if (!Camera.main)
        {
            Debug.Log("Unable to find main camera");
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            mouseOver.x = (int)((hit.point.x * 2 - boardOffset.x) + 1);
            mouseOver.y = (int)((hit.point.z * 2 - boardOffset.z) + 1);

            // board - roation-x=61.177; position-y=6.5; position-z=-5
        }
        else
        {
            // resets mouseOver to negative 1 if nothing is hit
            mouseOver.x = -1;
            mouseOver.y = -1;
        }
    }

    private void UpdatePieceDrag(Piece p)
    {
        if (!Camera.main)
        {
            Debug.Log("Unable to find main camera");
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            // - boardOffset
            // + new Vector3(1.0f, -0.596f, 1.0f)
            Vector3 h = new Vector3(hit.point.x, 0, hit.point.z);

            p.transform.position = (h*2) + Vector3.up;
        }
    }

    /*  Selects a piece
     *  When you click on a box, it takes in the mouseOVer position
     */
    private void SelectPiece(int x, int y) 
    {
        // tests for out of bounds
        if (x < 0 || x > 8 || y < 0 || y > 8)
            return;

        Piece p = pieces[x, y];
        Debug.Log("p.isWhite: " + p.isWhite);
        Debug.Log("isWhite: " + isWhite);
        if (p != null && p.isWhite == isWhite)
        { 
            
            if (forcedPieces.Count == 0)
            {
                selectedPiece = p;
                startDrag = mouseOver;
                // Debug.Log(selectedPiece.name);
            }
            else
            {
                // look for the pieces in the forcedPieces list
                if(forcedPieces.Find(fp => fp == p) == null)
                {
                    return;
                }

                selectedPiece = p;
                startDrag = mouseOver;
            }
        }
    }

    private void TryMove(int x1, int y1, int x2, int y2)
    {
        forcedPieces = ScanForPossibleMove();

        // Multiplayer Support
        startDrag = new Vector2(x1, y1);
        endDrag = new Vector2(x2, y2);
        selectedPiece = pieces[x1, y1];

        // Restricing the movement of the checkers piece

        // Checking if the piece is out of bounds
        if (x2 < 0 || x2 >= 8 || y2 < 0 || y2 >= 8)
        {
            if (selectedPiece != null)
            {
                // places piece back to original position
                MovePiece(selectedPiece, x1, y1);
            }
            startDrag = Vector2.zero;
            selectedPiece = null;
            return;
        }

        if (selectedPiece != null)
        {
            // If the piece has not moved
            if (endDrag == startDrag)
            {
                // places piece back to original position
                MovePiece(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;
                return;
            }
        }

        // Check if it is a valid move
        if (selectedPiece.ValidMove(pieces, x1, y1, x2, y2))
        {
            // Did we kill anything
            // Checks to see if this is a jump
            if (Mathf.Abs(x2 - x1) == 2)
            {
                Piece p = pieces[(x1 + x2) / 2, (y1 + y2) / 2];
                if (p != null)
                {
                    pieces[(x1 + x2) / 2, (y1 + y2) / 2] = null;
                    Destroy(p.gameObject);
                    hasKilled = true;
                }
            }

            // Were we supposed to kill anything?
            if(forcedPieces.Count != 0 && !hasKilled)
            {
                MovePiece(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;
                return;
            }
            pieces[x2, y2] = selectedPiece;
            pieces[x1, y1] = null;
            MovePiece(selectedPiece, x2, y2);

            EndTurn();
        }
        else
        {
            MovePiece(selectedPiece, x1, y1);
            startDrag = Vector2.zero;
            selectedPiece = null;
            return;
        }
    }

    private void EndTurn()
    {
        int x = (int)endDrag.x;
        int y = (int)endDrag.y;

        // Promotions
        if (selectedPiece != null)
        {
            if (selectedPiece.isWhite && !selectedPiece.isKing && y == 7)
            {
                selectedPiece.isKing = true;
                // need to replace the current gameobject with the king
                // currently do not have a king asset
                //selectedPiece.transform.Rotate(Vector3.right * 180);
            }
            else if (!selectedPiece.isWhite && !selectedPiece.isKing && y == 0)
            {
                selectedPiece.isKing = true;
                // need to replace the current gameobject with the king
                // currently do not have a king asset
                //selectedPiece.transform.Rotate(Vector3.right * 180);
            }
        }

        selectedPiece = null;
        startDrag = Vector2.zero;

        if(ScanForPossibleMove(selectedPiece, x, y).Count != 0 && hasKilled)
        {
            return;
        }

        isWhiteTurn = !isWhiteTurn;
        isWhite = !isWhite;
        Debug.Log("isWhiteTurn: " + isWhiteTurn);
        Debug.Log("isWhite: " + isWhite);
        hasKilled = false;
        CheckVictory();
    }

    private void CheckVictory()
    {
        var ps = FindObjectsOfType<Piece>();        
        bool hasWhite = false, hasBlack = false;
        foreach (Piece r in ps)
        {
            if (r.isWhite)
            {
                hasWhite = true;
            }
            else
            {
                hasBlack = true;
            }
        }

        if (!hasWhite)
        {
            Victory(false);
        }
        if (!hasBlack)
        {
            Victory(true);
        }
    }

    private void Victory(bool isWhite)
    {
        if (isWhite)
        {
            Debug.Log("White team has won");
        }
        else
        {
            Debug.Log("Black team has won");
        }
    }

    private List<Piece> ScanForPossibleMove(Piece p, int x, int y)
    {
        forcedPieces = new List<Piece>();

        if (pieces[x, y].IsForceToMove(pieces, x, y))
        {
            forcedPieces.Add(pieces[x, y]);
        }

        return forcedPieces;
    }

    private List<Piece> ScanForPossibleMove()
    {
        forcedPieces = new List<Piece>();

        // check all the pieeces
        for(int i = 0; i < 8; i++)
            for(int j = 0; j < 8; j++)
                if(pieces[i,j] != null && pieces[i,j].isWhite == isWhiteTurn)
                    if(pieces[i,j].IsForceToMove(pieces, i, j))
                        forcedPieces.Add(pieces[i, j]);

        return forcedPieces;
    }

    /*  generates the board at the beginning of the game     
     *  calls GeneratePiece funcitn to add the pieces to the board      */
    private void GenerateBoard()
    {
        // Generate white team
        for (int y = 0; y < 3; y++)
        {
            bool oddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                GeneratePiece((oddRow) ? x : x + 1, y);
            }
        }


        // Generate black team
        for (int y = 7; y > 4; y--)
        {
            bool oddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                // Generate our Piece
                GeneratePiece((oddRow) ? x : x + 1, y);
            }
        }
    }

    /*  adds the pieces for each team onto the board at the beginning of the game
    *   fills in the first 3 rows of black squares        */
    private void GeneratePiece(int x, int y)
    {
        bool isPieceWhite = (y > 3) ? false : true;
        GameObject go = Instantiate((isPieceWhite) ? whitePiecePrefab : blackPiecePrefab) as GameObject;
        go.transform.SetParent(transform);
        Piece p = go.GetComponent<Piece>();
        p.isWhite = ((isPieceWhite) ? true : false);
        pieces[x, y] = p;
        MovePiece(p, x, y);
    }

    /*  adjusts the position of the pieces to make sure that they are generated in the correct 
     *  position on the board       */
    private void MovePiece(Piece p, int x, int y)
    {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y)
            + boardOffset + pieceOffset;
    }
}