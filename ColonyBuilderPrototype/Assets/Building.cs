using System;
using System.Collections.Generic;

namespace GameEngine {


    class Building {



        public enum BuildingType : int {
            TestFarm = 0,
        }

        public BuildingType MyType { get; }

        Dictionary<Good.GoodList, float> baseConsumption;
        Dictionary<Good.GoodList, float> baseProduction;

        Dictionary<Good.GoodList, int> ConstructionCost;

        public int SpaceRequired { get; }

        



        //Constructor

            public Building(BuildingType buildingType) {

            MyType = buildingType;

            baseConsumption = new Dictionary<Good.GoodList, float>(); //these values have to be read in from a file somewhere
            baseConsumption = new Dictionary<Good.GoodList, float>(); //these values have to be read in from a file somewhere

            ConstructionCost = new Dictionary<Good.GoodList, int>();  //these values have to be read in from a file somewhere

            SpaceRequired = 1; //these values have to be read in from a file or enum somewhere


        }





        //methods


        

        public float getConsumed(Good.GoodList good) {
            if (baseConsumption.ContainsKey(good))
                return baseConsumption[good];

            return 0;
        }




        public float getProduced(Good.GoodList good) {
            if (baseProduction.ContainsKey(good))
                return baseProduction[good];

            return 0;
        }




        public List<Good.GoodList> getConsumptionList() {

            List<Good.GoodList> consumedGoods = new List<Good.GoodList>();

            foreach (KeyValuePair<Good.GoodList, float> goodPairs in baseConsumption)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);


            return consumedGoods;
        }




        public List<Good.GoodList> getProductionList() {

            List<Good.GoodList> producedGoods = new List<Good.GoodList>();

            foreach (KeyValuePair<Good.GoodList, float> goodPairs in baseProduction)
                if (goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);


            return producedGoods;
        }




        public Dictionary<Good.GoodList, int> getConstructionCost() {
            return ConstructionCost;
        }





        public void updateTick() {
            
        }



    }
}
