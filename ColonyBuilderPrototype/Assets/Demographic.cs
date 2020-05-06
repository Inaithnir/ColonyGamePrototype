using System;
using System.Collections.Generic;

namespace GameEngine {
    
    class Demographic {

       public enum DemoType : int { //if adjusted, make sure to change the type counter below and the appropriate production/consumption weight settings

            Peasant = 1,
            Merchant = 2,
            Elite = 3,
            Native = 4,

        }
        public const int NumDemoTypes = 4;

        public enum BaseTargetPopDefault : int {

            Peasant = 400,
            Merchant = 250,
            Elite = 150,
            Native = 0,

        }

        public DemoType MyDemoType { get; }
        public int NumPeople { get; }
        public int BaseTargetPop { get; }
        Dictionary<Good, float> goodConsumeWeights;
        Dictionary<Good, float> goodProduceWeights;

        Dictionary<Good, float> lastTickConsumed;
        Dictionary<Good, float> lastTickProduced;

        // constructors

        public Demographic(DemoType myType) {

            MyDemoType = myType;
            NumPeople = 100;
            BaseTargetPop = (int) myType;



            goodConsumeWeights = new Dictionary<Good, float>() {
                { new Good(Good.GoodList.Food), 0.1f },
            };



            goodProduceWeights = new Dictionary<Good, float>() {
                { new Good(Good.GoodList.Food), 0 },
            };
        }
        //TODO: constructor with forced NumPeople





        // methods
        
        public float calcConsumption(Good good) {

            float toReturn = 0;

            if (goodConsumeWeights.ContainsKey(good))
                toReturn = NumPeople * goodConsumeWeights[good];
            
            return toReturn;            
        }

        public float getLastConsumption(Good good) {
            if (lastTickConsumed.ContainsKey(good))
                return lastTickConsumed[good];

            return 0;

        }



        public float calcProduction(Good good) {

            float toReturn = 0;

            if (goodProduceWeights.ContainsKey(good))
                toReturn = NumPeople * goodProduceWeights[good];

            return toReturn;
        }

        public float getLastProduction(Good good) {
            if (lastTickProduced.ContainsKey(good))
                return lastTickProduced[good];

            return 0;

        }

        public List<Good> getConsumptionList() {

            List<Good> consumedGoods = new List<Good>();

            foreach(KeyValuePair<Good,float> goodPairs in lastTickConsumed)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);
            

            return consumedGoods;
        }

        public List<Good> getProductionList() {

            List<Good> producedGoods = new List<Good>();

            foreach (KeyValuePair<Good, float> goodPairs in lastTickProduced) 
                if(goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);
            

            return producedGoods;
        }





        public void updateTick() { //later this will need to take into account if there's enough to consume, update satisfaction, etc.

            //update lastTickConsumed
            foreach (KeyValuePair<Good, float> goodPair in goodConsumeWeights) {

                if (lastTickConsumed.ContainsKey(goodPair.Key))
                    lastTickConsumed[goodPair.Key] = NumPeople * goodPair.Value;

                else
                    lastTickConsumed.Add(goodPair.Key, NumPeople * goodPair.Value);
            }

            //update lastTickProduced
            foreach (KeyValuePair<Good, float> goodPair in goodProduceWeights) {

                if (lastTickProduced.ContainsKey(goodPair.Key))
                    lastTickProduced[goodPair.Key] = NumPeople * goodPair.Value;

                else
                    lastTickProduced.Add(goodPair.Key, NumPeople * goodPair.Value);
            }

        }

    }



}
