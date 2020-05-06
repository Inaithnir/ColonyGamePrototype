using System;
using System.Collections.Generic;

namespace GameEngine {


    class Building {



        public enum BuildingType : int {
            TestFarm = 0,
        }

        public BuildingType MyType { get; }

        Dictionary<Good, float> baseConsumption;
        Dictionary<Good, float> baseProduction;

        Dictionary<Good, int> ConstructionCost;

        public int SpaceRequired { get; }

        



        //Constructor

            public Building(BuildingType buildingType) {

            MyType = buildingType;

            baseConsumption = new Dictionary<Good, float>(); //these values have to be read in from a file somewhere
            baseConsumption = new Dictionary<Good, float>(); //these values have to be read in from a file somewhere

            ConstructionCost = new Dictionary<Good, int>();  //these values have to be read in from a file somewhere

            SpaceRequired = 1; //these values have to be read in from a file or enum somewhere


        }





        //methods


        

        public float getConsumed(Good good) {
            if (baseConsumption.ContainsKey(good))
                return baseConsumption[good];

            return 0;
        }




        public float getProduced(Good good) {
            if (baseProduction.ContainsKey(good))
                return baseProduction[good];

            return 0;
        }




        public List<Good> getConsumptionList() {

            List<Good> consumedGoods = new List<Good>();

            foreach (KeyValuePair<Good, float> goodPairs in baseConsumption)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);


            return consumedGoods;
        }




        public List<Good> getProductionList() {

            List<Good> producedGoods = new List<Good>();

            foreach (KeyValuePair<Good, float> goodPairs in baseProduction)
                if (goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);


            return producedGoods;
        }




        public Dictionary<Good,int> getConstructionCost() {
            return ConstructionCost;
        }





        public void updateTick() {
            
        }



    }
}
