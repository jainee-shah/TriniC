using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8, 8];
    public GameObject whitePiecePrefab;     // stores the prefab for the white checkers piece
    public GameObject blackPiecePrefab;     // stores the prefab for the black checkers piece

    /*  board offset and piece offset use Vector3 to adjust the position of the checkers pieces
    *   makes sure that each team has the first three rows of black squares filled in       */
    private Vector3 boardOffset = new Vector3(-3.0f, 0.596f, -3.0f);    // board offset
    private Vector3 pieceOffset = new Vector3(-0.48f, 0, -0.55f);       // piece offset

    private Piece selectedPiece;

    private Vector2 mouseOver;
    private Vector2 startDrag;
    private Vector2 endDrag;

    private void Start()
    {
        GenerateBoard();
    }

    private void Update()
    {
        UpdateMouseOver();

        Debug.Log(mouseOver);

        // if it is player 1's turn
        {
            int x = (int)mouseOver.x;
            int y = (int)mouseOver.y;

            if (Input.GetMouseButtonDown(0))
            {
                SelectPiece(x, y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                //TryMove((int)startDrag.x, (int)startDrag.y,);
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
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            mouseOver.x = (int)(hit.point.x - boardOffset.x);
            mouseOver.y = (int)(hit.point.z - boardOffset.z);
        }
        else
        {
            mouseOver.x = -1;
            mouseOver.y = -1;
        }
    }

    /*
     */
    private void SelectPiece(int x, int y)
    {
        // tests for out of bounds
        if(x < 0 || x >= pieces.Length || y < 0 || y >= pieces.Length)
            return;

        Piece p = pieces[x, y];
        if(p != null)
        {
            selectedPiece = p;
            startDrag = mouseOver;
            Debug.Log(selectedPiece.name);
        }
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
             GeneratePiece((oddRow) ? x : x+1, y);
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