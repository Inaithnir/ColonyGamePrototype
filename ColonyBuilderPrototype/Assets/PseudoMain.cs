using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI;

public class PseudoMain : MonoBehaviour
{
    
    
    public Text outputField;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Good testGood = new Good(Good.GoodList.Food);

        outputField.text = testGood.Name.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
