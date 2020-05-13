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
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (EventSystem.current.IsPointerOverGameObject()) {
                Debug.Log("Clicked on the UI");
            }
            else if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                GameObject gameObjectHit = objectHit.gameObject;
                if (pseudoMain.GameObjectDistrictMap.ContainsKey(gameObjectHit)) {
                    District districtHit = pseudoMain.GameObjectDistrictMap[gameObjectHit];
                    districtPanelController.EnablePanel(districtHit);
                }
                Debug.Log(hit);
            }
            else
                DistrictPanel.SetActive(false);
            
        }
    }
}
