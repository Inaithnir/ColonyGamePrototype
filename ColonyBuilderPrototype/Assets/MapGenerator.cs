using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using GameEngine;

public class MapGenerator : MonoBehaviour
{



    static Tilemap MyMap;
    public Tile tileSprite;
    public Tile hoverSprite;
    public Tile districtBuildingSprite;
    public List<Tile> districtSprites;
    public int MapWidth;
    public int MapHeight;
    int districtSpriteIndex;

    PseudoMain pseudomain;

    public bool PlacingDistrictSeed { get; private set; }

    Tile lastTile;
    public Vector3Int lastPos;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        districtSpriteIndex = 0;
        pseudomain = GameObject.Find("PseudoMain").GetComponent<PseudoMain>();
        MyMap = this.gameObject.GetComponentInChildren<Tilemap>();
        lastTile = null;
        lastPos = new Vector3Int(-1,-1,-1);
       
        for (int i = 0; i < MapHeight; i++) {
            for (int j = 0; j < MapWidth; j++) {
                MyMap.SetTile(new Vector3Int(j, i, 0), tileSprite);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlacingDistrictSeed == true) {
            Vector3Int tilemapPos = GetTileUnderMouse();
            if (tilemapPos.x >= 0 && tilemapPos.y>=0 && tilemapPos.x < MapWidth && tilemapPos.y < MapHeight) {
                //Debug.Log(tilemapPos);

                if (lastPos != tilemapPos) {
                    
                    MyMap.SetTile(lastPos, lastTile);
                    lastTile = MyMap.GetTile<Tile>(tilemapPos);
                    MyMap.SetTile(tilemapPos, hoverSprite);
                    lastPos = tilemapPos;
                    
                }


                


            }
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject()) {
                if (tilemapPos.x >= 0 && tilemapPos.y >= 0 && tilemapPos.x < MapWidth && tilemapPos.y < MapHeight && GameMap.ThisGameMap.getTileAt(tilemapPos.x,tilemapPos.y).occupied == false) {
                    District districtToAdd = pseudomain.BuildDistrict(tilemapPos);
                    districtToAdd.DistrictGrown += growDistrict;
                    districtToAdd.DistrictDone += finishDistrict;
                }
                else {
                    MyMap.SetTile(lastPos, lastTile);
                }



                lastTile = null;
                lastPos = new Vector3Int(-1, -1, -1);

                DeactivateDistrictBuildMode();
            }

        }
    }






    public void ActivateDistrictBuildMode() {
        PlacingDistrictSeed = true;
    }

    public void DeactivateDistrictBuildMode() {
        PlacingDistrictSeed = false;
    }


    public static Vector3Int GetTileUnderMouse() {
        Plane intersectPlane = new Plane(new Vector3(0, 0, 1), new Vector3(1, 0, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0f;
        if(intersectPlane.Raycast(ray,out enter)) {
            return MyMap.WorldToCell(ray.GetPoint(enter));
        }
        return new Vector3Int(-1,-1,-1);

    }

    public void changeTile(Vector3Int location, Tile tile) {
        MyMap.SetTile(location, tile);
    }

    public void growDistrict(object sender, DistrictGrownEventArgs e) {
        Vector3Int tileAddedLocation = new Vector3Int((int)e.tileCoords.X, (int)e.tileCoords.Y, 0);
        Debug.Log(tileAddedLocation);
        pseudomain.GameObjectDistrictMap.Add(tileAddedLocation, e.district);
        changeTile(tileAddedLocation, districtBuildingSprite);
    }

    public void finishDistrict(object sender, DistrictGrownEventArgs e) {
        List<MapTile> districtTiles = e.district.MyMapTiles;
        foreach(MapTile tile in districtTiles) {
            changeTile(new Vector3Int(tile.x, tile.y, 0), districtSprites[districtSpriteIndex]);
            
        }
        districtSpriteIndex++;
        if (districtSpriteIndex == districtSprites.Count)
            districtSpriteIndex = 0;
    }
}
