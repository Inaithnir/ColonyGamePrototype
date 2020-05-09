using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {


    class Building {


        public BuildingType MyType { get; }

        Dictionary<GoodType, float> baseConsumption;
        Dictionary<GoodType, float> baseProduction;

        Dictionary<GoodType, int> ConstructionCost;

        public int SpaceRequired { get; }

        



        //Constructor

            public Building(BuildingType buildingType) {

            MyType = buildingType;

            baseConsumption = new Dictionary<GoodType, float>(); //these values have to be read in from a file somewhere
            baseConsumption = new Dictionary<GoodType, float>(); //these values have to be read in from a file somewhere

            ConstructionCost = new Dictionary<GoodType, int>();  //these values have to be read in from a file somewhere

            SpaceRequired = 1; //these values have to be read in from a file or enum somewhere


        }





        //methods


        

        public float getConsumed(GoodType good) {
            if (baseConsumption.ContainsKey(good))
                return baseConsumption[good];

            return 0;
        }




        public float getProduced(GoodType good) {
            if (baseProduction.ContainsKey(good))
                return baseProduction[good];

            return 0;
        }




        public List<GoodType> getConsumptionList() {

            List<GoodType> consumedGoods = new List<GoodType>();

            foreach (KeyValuePair<GoodType, float> goodPairs in baseConsumption)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);


            return consumedGoods;
        }




        public List<GoodType> getProductionList() {

            List<GoodType> producedGoods = new List<GoodType>();

            foreach (KeyValuePair<GoodType, float> goodPairs in baseProduction)
                if (goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);


            return producedGoods;
        }




        public Dictionary<GoodType, int> getConstructionCost() {
            return ConstructionCost;
        }





        public void updateTick() {
            
        }



    }
}
