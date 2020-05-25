using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI;
using System.Globalization;
using System;
using UnityEngine.Tilemaps;

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
    public Dictionary<Vector3Int, District> GameObjectDistrictMap { get; private set; }

    GameMap gameMap;



    public GameObject districtPrefab; //for testing purposes
    int xloc = -8; //for testing purposes


    // Start is called before the first frame update
    void Awake()
    {
        testGame = new Game();
        PlayerColony = Colony.PlayerColony;
        tickCounter = 0;
        GameObjectDistrictMap = new Dictionary<Vector3Int, District>();
        gameMap = new GameMap(500, 500);
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




    public District BuildDistrict(Vector3Int location) {
        Debug.Log(GameMap.ThisGameMap.getTileAt(location.x, location.y));
        District districtToAdd = new District(GameData.DistrictTypes.GrowingBorough, GameMap.ThisGameMap.getTileAt(location.x,location.y), xloc.ToString());
        PlayerColony.addDistrict(districtToAdd);

        
        
        GameObjectDistrictMap.Add(location, districtToAdd);

        xloc+=2; //for testing purposes
        return districtToAdd;
    }



    public District getDistrict(Vector3Int districtPositiong) {
        return GameObjectDistrictMap[districtPositiong];
    }




}
