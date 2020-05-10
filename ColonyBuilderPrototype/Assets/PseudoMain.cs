using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI; 

public class PseudoMain : MonoBehaviour
{
    
    
    public Text outputField;

    Game testGame;
    
    
    // Start is called before the first frame update
    void Start()
    {
        testGame = new Game();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            testGame.updateTick();
            Debug.Log("Tick done!");
        }

    }
}
