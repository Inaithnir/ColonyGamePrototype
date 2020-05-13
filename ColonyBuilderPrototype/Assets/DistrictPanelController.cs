using GameEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistrictPanelController : MonoBehaviour
{

    Text districtNameText;
    Text districtTypeText;
    Text districtPopText;
    Text districtPeasantsText;
    Text districtMerchantsText;
    Text districtEliteText;
    Text[] demographicsText;
    Button buildFarmButton;
    GameObject buildingSlotsPanel;



    public Sprite emptyBuildingSprite;
    public Sprite builtBuildingSprite;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        districtNameText = this.transform.Find("DistrictName").GetComponent<Text>();
        districtTypeText = this.transform.Find("DistrictType").GetComponent<Text>();
        districtPopText = this.transform.Find("DistrictPopulation").GetComponent<Text>();
        buildFarmButton = this.transform.Find("AddFarmButton").GetComponent<Button>();

        districtPeasantsText = this.transform.Find("PeasantPop").GetComponent<Text>();
        districtMerchantsText = this.transform.Find("MerchantPop").GetComponent<Text>();
        districtEliteText = this.transform.Find("ElitePop").GetComponent<Text>();

        buildingSlotsPanel = this.transform.Find("BuildingSlotsPanel").gameObject;

        demographicsText = new Text[3] { districtPeasantsText, districtMerchantsText, districtEliteText };

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void EnablePanel(District districtToDisplay) {

        districtNameText.text = districtToDisplay.DistrictName;
        districtTypeText.text = districtToDisplay.DistrictType.ToString();

        Population districtPop = districtToDisplay.DistrictPopulation;

        districtPopText.text = "Population: " + districtPop.CurrentPop.ToString();


        for (int i = 0; i < 3; i++) {
            demographicsText[i].text = districtPop.demographics[i].MyDemoType.ToString() + ": " +  districtPop.demographics[i].NumPeople.ToString();
        }

        List<Building> buildingList = districtToDisplay.GetBuildings();
        int buildingCounter = 0;
        foreach(Building building in buildingList) {
            buildingSlotsPanel.transform.GetChild(buildingCounter).GetComponent<Image>().sprite = builtBuildingSprite;
            buildingCounter++;
        }
        for (int i = buildingCounter; i < 10; i++) {
            buildingSlotsPanel.transform.GetChild(i).GetComponent<Image>().sprite = emptyBuildingSprite;
        }
        
        buildFarmButton.onClick.RemoveAllListeners();
        buildFarmButton.onClick.AddListener(() => { districtToDisplay.addBuilding(new Building(GameData.BuildType.Farm)); EnablePanel(districtToDisplay); });


        this.gameObject.SetActive(true);
    }

    public void DisablePanel() {
        buildFarmButton.onClick.RemoveAllListeners();


        this.gameObject.SetActive(true);
    }



}
