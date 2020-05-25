using GameEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{



    PseudoMain pseudoMain;
    public Camera camera;
    public GameObject DistrictPanel;
    DistrictPanelController districtPanelController;
    
    // Start is called before the first frame update
        
    void Start()
    {
        pseudoMain = GameObject.Find("PseudoMain").GetComponent<PseudoMain>();
        districtPanelController = DistrictPanel.GetComponent<DistrictPanelController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            
            Vector3Int tileUnderMouse = MapGenerator.GetTileUnderMouse();
            if (EventSystem.current.IsPointerOverGameObject()) {
                Debug.Log("Clicked on the UI");
            }
            else if (pseudoMain.GameObjectDistrictMap.ContainsKey(tileUnderMouse)) {
                    District districtHit = pseudoMain.GameObjectDistrictMap[tileUnderMouse];
                    districtPanelController.EnablePanel(districtHit);
                
                Debug.Log(tileUnderMouse);
            }
            else
                DistrictPanel.SetActive(false);
                        
        }
    }
}


