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

    Slider SatSlider;
    Slider HeaSlider;
    Slider SecSlider;
    Slider OppSlider;

    Text SatValueText;
    Text HeaValueText;
    Text SecValueText;
    Text OppValueText;

    Text HappText;


    public Sprite emptyBuildingSprite;
    public Sprite builtBuildingSprite;

    District displayDistrict;
    Population districtPop;


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

        SatSlider = this.transform.Find("SatSlider").GetComponent<Slider>();
        HeaSlider = this.transform.Find("HeaSlider").GetComponent<Slider>();
        SecSlider = this.transform.Find("SecSlider").GetComponent<Slider>();
        OppSlider = this.transform.Find("OppSlider").GetComponent<Slider>();

        SatValueText = this.transform.Find("SatValueText").GetComponent<Text>();
        SecValueText = this.transform.Find("SecValueText").GetComponent<Text>();
        HeaValueText = this.transform.Find("HeaValueText").GetComponent<Text>();
        OppValueText = this.transform.Find("OppValueText").GetComponent<Text>();

        buildingSlotsPanel = this.transform.Find("BuildingSlotsPanel").gameObject;

        demographicsText = new Text[3] { districtPeasantsText, districtMerchantsText, districtEliteText };

        HappText = this.transform.Find("HappText").GetComponent<Text>();

        this.gameObject.SetActive(false);

        PseudoMain.OnTick += updatePanelEvent;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (this.gameObject.activeSelf) {
            for (int i = 0; i < 3; i++) {
                districtPop.demographics[i].Health = (int) (HeaSlider.value * 100) ;
                districtPop.demographics[i].Oppression = (int)(OppSlider.value * 100);
                districtPop.demographics[i].Security = (int)(SecSlider.value * 100);
                districtPop.demographics[i].Satisfaction = (int)(SatSlider.value * 100);
                HeaValueText.text = ((int)(HeaSlider.value * 100)).ToString() ;
                SecValueText.text = ((int)(SecSlider.value * 100)).ToString();
                SatValueText.text = ((int)(SatSlider.value * 100)).ToString();
                OppValueText.text = ((int)(OppSlider.value * 100)).ToString();
            }
        }
        */
    }



    public void EnablePanel(District districtToDisplay) {

        displayDistrict = districtToDisplay;



        this.gameObject.SetActive(true);
        updatePanel();


        
    }

    public void DisablePanel() {
        buildFarmButton.onClick.RemoveAllListeners();


        this.gameObject.SetActive(true);
    }

    public void updatePanel() {
        if (this.gameObject.activeSelf) {
            districtNameText.text = displayDistrict.DistrictName;
            districtTypeText.text = displayDistrict.DistrictType.ToString();

            districtPop = displayDistrict.DistrictPopulation;

            districtPopText.text = "Population: " + districtPop.CurrentPop.ToString();


            for (int i = 0; i < 3; i++) {
                demographicsText[i].text = districtPop.demographics[i].MyDemoType.ToString() + ": " + districtPop.demographics[i].NumPeople.ToString();
                HappText.text = districtPop.demographics[i].TargetPop.ToString();
            }

            List<Building> buildingList = displayDistrict.GetBuildings();
            int buildingCounter = 0;
            foreach (Building building in buildingList) {
                buildingSlotsPanel.transform.GetChild(buildingCounter).GetComponent<Image>().sprite = builtBuildingSprite;
                buildingCounter++;
            }
            for (int i = buildingCounter; i < 10; i++) {
                buildingSlotsPanel.transform.GetChild(i).GetComponent<Image>().sprite = emptyBuildingSprite;
            }

            buildFarmButton.onClick.RemoveAllListeners();
            buildFarmButton.onClick.AddListener(() => { displayDistrict.addBuilding(new Building(GameData.BuildType.Farm)); EnablePanel(displayDistrict); });
        }
    }

    public void updatePanelEvent(object sender, PseudoMain.OnTickEventArgs e) {
        updatePanel();
    }

}
