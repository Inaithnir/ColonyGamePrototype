using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEngine.GameData;

namespace GameEngine {
    class Colony {

        GoodsManager colonyGoods;

        public static Colony PlayerColony { get; private set; }
        public String colonyName { get; }

        List<District> colonyDistricts;
        public int ColonyPopulation { get; private set; }


        public float globalPeopleProdMod;//To replace with dictionary of modifiers
        public float globalPeopleConsMod;//To replace with dictionary of modifiers
        public float globalBuildingProdMod;//To replace with dictionary of modifiers
        public float globalBuildingConsMod;//To replace with dictionary of modifiers



        //Constructor
        public Colony(String name) {

            PlayerColony = this;

            ColonyPopulation = 0;
            colonyDistricts = new List<District>();


            colonyGoods = new GoodsManager(true);



            

            colonyName = name;


            globalPeopleProdMod = 1;
            globalPeopleConsMod = 1;
            globalBuildingProdMod = 1;
            globalBuildingConsMod = 1;





            colonyGoods.changeAmount(GoodType.Food, 100); //TESTING PURPOSES
        }



        //method

        public void addDistrict(District districtToAdd) {
            colonyDistricts.Add(districtToAdd);
            ColonyPopulation += districtToAdd.DistrictPopulation.CurrentPop;
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
                    colonyGoods.changeAmount(goodPair.Key,goodPair.Value * globalPeopleConsMod);
                }
                foreach (KeyValuePair<GoodType, float> goodPair in peopleProduced) {
                    colonyGoods.changeAmount(goodPair.Key, goodPair.Value * globalPeopleProdMod);
                }
                foreach (KeyValuePair<GoodType, float> goodPair in buildingConsumed) {
                    colonyGoods.changeAmount(goodPair.Key, goodPair.Value * globalBuildingConsMod);
                }
                foreach (KeyValuePair<GoodType, float> goodPair in buildingProduced) {
                    colonyGoods.changeAmount(goodPair.Key, goodPair.Value * globalBuildingProdMod);
                }
            }
        }



        public GoodsManager getGoodsManager()
        {
            return colonyGoods;
        }

        public List<District> getDistrictList() {
            return colonyDistricts;
        }

    }
}
