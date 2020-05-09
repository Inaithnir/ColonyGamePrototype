using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEngine.GameData;

namespace GameEngine {
    class Colony {

        GoodsManager colonyGoods;
        public String colonyName { get; }

        List<District> colonyDistricts;
        public int ColonyPopulation { get; private set; }


        public float globalPeopleProdMod;//To replace with dictionary of modifiers
        public float globalPeopleConsMod;//To replace with dictionary of modifiers
        public float globalBuildingProdMod;//To replace with dictionary of modifiers
        public float globalBuildingConsMod;//To replace with dictionary of modifiers



        //Constructor
        public Colony(String name) {

            colonyDistricts = new List<District>();

            colonyGoods = new GoodsManager(true);







            ColonyPopulation = 0;

            colonyName = name;


            globalPeopleProdMod = 1;
            globalPeopleConsMod = 1;
            globalBuildingProdMod = 1;
            globalBuildingConsMod = 1;





            colonyGoods.changeAmount(GoodType.Food, 100);
        }










        //method

        public void addDistrict(District districtToAdd) {
            colonyDistricts.Add(districtToAdd);

            
        }        








        public void updateTick() {



            ColonyPopulation = 0;

            Dictionary<GoodType, float> peopleConsumed = new Dictionary<GoodType, float>();
            Dictionary<GoodType, float> peopleProduced = new Dictionary<GoodType, float>();
            Dictionary<GoodType, float> buildingConsumed = new Dictionary<GoodType, float>();
            Dictionary<GoodType, float> buildingProduced = new Dictionary<GoodType, float>();


            foreach (District district in colonyDistricts) {
                district.updateTick();


                ColonyPopulation += district.DistrictPopulation.CurrentPop;

                peopleConsumed = district.getPeopleConsumption();
                peopleProduced = district.getPeopleProduction();
                buildingConsumed = district.getBuildingConsumption();
                buildingProduced = district.getBuildingProduction();

                foreach(KeyValuePair<GoodType, float> goodPair in peopleConsumed) {
                    colonyGoods.changeAmount(goodPair.Key,(int) Math.Round( goodPair.Value * globalPeopleConsMod));
                }
                foreach (KeyValuePair<GoodType, float> goodPair in peopleProduced) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalPeopleProdMod));
                }
                foreach (KeyValuePair<GoodType, float> goodPair in buildingConsumed) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalBuildingConsMod));
                }
                foreach (KeyValuePair<GoodType, float> goodPair in buildingProduced) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalBuildingProdMod));
                }

            }






        }



        public GoodsManager getGoodsManager()
        {
            return colonyGoods;
        }


        public void applyModifier(Modifier modifierToApply, object objectToApplyTo) {
            if (objectToApplyTo.GetType() == typeof(Building) || objectToApplyTo.GetType() == typeof(Demographic)) {

               






            }
            else
                throw new ArgumentException("Incorrect modifier application object defined: make sure it is either Demographic or Building!");
        }

    }
}
