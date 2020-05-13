using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI;
using System.Globalization;
using System;

public class PseudoMain : MonoBehaviour
{
    //Remove below when implementing the actual TimeManager
    public class OnTickEventArgs : EventArgs {
        public int tick;
    }
    private int tickCounter;
    public static event EventHandler<OnTickEventArgs> OnTick;
    //Remove above when implementing the actual TimeManager




    Game testGame;
    Colony PlayerColony;
    public Dictionary<GameObject, District> GameObjectDistrictMap { get; private set; }



    public GameObject districtPrefab; //for testing purposes
    int xloc = -8; //for testing purposes


    // Start is called before the first frame update
    void Awake()
    {
        testGame = new Game();
        PlayerColony = Colony.PlayerColony;
        tickCounter = 0;
        GameObjectDistrictMap = new Dictionary<GameObject, District>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            tickCounter++;
            testGame.updateTick();
            Debug.Log("Tick done!");
            if (OnTick != null) {
                OnTick(this, new OnTickEventArgs { tick = tickCounter });
            }
        }
        
    }




    public void BuildDistrict() {
        District districtToAdd = new District(GameData.DistrictTypes.Borough,xloc.ToString());
        PlayerColony.addDistrict(districtToAdd);

        GameObject districtObject = Instantiate<GameObject>(districtPrefab, new Vector3(xloc, 0, 0), Quaternion.identity);
        districtObject.name = "District " + xloc;
        GameObjectDistrictMap.Add(districtObject, districtToAdd);

        xloc+=2; //for testing purposes
    }



    public District getDistrict(GameObject districtObject) {
        return GameObjectDistrictMap[districtObject];
    }
}
