using System;
using System.Collections.Generic;
using UnityEngine;

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





            colonyGoods.changeAmount(Good.GoodList.Food, 100);
        }










        //method

        public void addDistrict(District districtToAdd) {
            colonyDistricts.Add(districtToAdd);

            
        }        








        public void updateTick() {



            ColonyPopulation = 0;

            Dictionary<Good.GoodList, float> peopleConsumed = new Dictionary<Good.GoodList, float>();
            Dictionary<Good.GoodList, float> peopleProduced = new Dictionary<Good.GoodList, float>();
            Dictionary<Good.GoodList, float> buildingConsumed = new Dictionary<Good.GoodList, float>();
            Dictionary<Good.GoodList, float> buildingProduced = new Dictionary<Good.GoodList, float>();


            foreach (District district in colonyDistricts) {
                district.updateTick();


                ColonyPopulation += district.DistrictPopulation.CurrentPop;

                peopleConsumed = district.getPeopleConsumption();
                peopleProduced = district.getPeopleProduction();
                buildingConsumed = district.getBuildingConsumption();
                buildingProduced = district.getBuildingProduction();

                foreach(KeyValuePair<Good.GoodList, float> goodPair in peopleConsumed) {
                    colonyGoods.changeAmount(goodPair.Key,(int) Math.Round( goodPair.Value * globalPeopleConsMod));
                }
                foreach (KeyValuePair<Good.GoodList, float> goodPair in peopleProduced) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalPeopleProdMod));
                }
                foreach (KeyValuePair<Good.GoodList, float> goodPair in buildingConsumed) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalBuildingConsMod));
                }
                foreach (KeyValuePair<Good.GoodList, float> goodPair in buildingProduced) {
                    colonyGoods.changeAmount(goodPair.Key, (int)Math.Round(goodPair.Value * globalBuildingProdMod));
                }

            }






        }



        public GoodsManager getGoodsManager()
        {
            return colonyGoods;
        }

    }
}
