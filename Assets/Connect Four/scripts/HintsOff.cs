using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsOff : MonoBehaviour
{
    public GameObject GC;

    Preferences pref;
    ConnectFour.GameController GCScript;

    // Start is called before the first frame update
    void Start()
    {
        pref = GC.GetComponent<Preferences>();
        GCScript = GC.GetComponent<ConnectFour.GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pref.hints == "0")
            GCScript.NoTutorial();
        //else if (pref.hints == "1")
            //GCScript.YesTutorial();
    }
}
