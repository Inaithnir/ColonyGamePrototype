using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {
    
    public class Demographic {

        

        public DemoType MyDemoType { get; }
        public int NumPeople { get; }
        public BaseTargetPop MyBaseTargetPop { get; }
        Dictionary<GoodType, float> goodConsumeWeights;
        Dictionary<GoodType, float> goodProduceWeights;

        Dictionary<GoodType, float> lastTickConsumed;
        Dictionary<GoodType, float> lastTickProduced;

        // constructors

        public Demographic(DemoType myType, int NumPeopleIn = 0) {

            MyDemoType = myType;
            NumPeople = NumPeopleIn;
            MyBaseTargetPop = (BaseTargetPop)Enum.Parse(typeof(BaseTargetPop), MyDemoType.ToString("g"));

            goodConsumeWeights = new Dictionary<GoodType, float>();
            foreach(KeyValuePair<GoodType, float[]> goodPair in PeopleConsumptionWeights) {
                goodConsumeWeights.Add(goodPair.Key, goodPair.Value[(int)MyDemoType]);
            }

            goodProduceWeights = new Dictionary<GoodType, float>();
            foreach (KeyValuePair<GoodType, float[]> goodPair in PeopleProductionWeights) {
                goodProduceWeights.Add(goodPair.Key, goodPair.Value[(int)MyDemoType]);
            }

            lastTickConsumed = new Dictionary<GoodType, float>();
            lastTickProduced = new Dictionary<GoodType, float>();
        }

        
        //TODO: constructor with forced NumPeople





        // methods

        public float calcConsumption(GoodType good) {

            float toReturn = 0;

            if (goodConsumeWeights.ContainsKey(good))
                toReturn = NumPeople * goodConsumeWeights[good];
            
            return toReturn;            
        }

        public float getLastConsumption(GoodType good) {
            if (lastTickConsumed.ContainsKey(good))
                return lastTickConsumed[good];

            return 0;

        }



        public float calcProduction(GoodType good) {

            float toReturn = 0;

            if (goodProduceWeights.ContainsKey(good))
                toReturn = NumPeople * goodProduceWeights[good];

            return toReturn;
        }

        public float getLastProduction(GoodType good) {
            if (lastTickProduced.ContainsKey(good))
                return lastTickProduced[good];

            return 0;

        }

        public List<GoodType> getConsumptionList() {

            List<GoodType> consumedGoods = new List<GoodType>();

            foreach(KeyValuePair<GoodType, float> goodPairs in lastTickConsumed)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);
            

            return consumedGoods;
        }

        public List<GoodType> getProductionList() {

            List<GoodType> producedGoods = new List<GoodType>();

            foreach (KeyValuePair<GoodType, float> goodPairs in lastTickProduced) 
                if(goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);
            

            return producedGoods;
        }





        public void updateTick() { //later this will need to take into account if there's enough to consume, update satisfaction, etc.



            //update lastTickConsumed
            foreach (KeyValuePair<GoodType, float> goodPair in goodConsumeWeights) {

                if (lastTickConsumed.ContainsKey(goodPair.Key))
                    lastTickConsumed[goodPair.Key] = NumPeople * goodPair.Value;

                else
                    lastTickConsumed.Add(goodPair.Key, NumPeople * goodPair.Value);
            }


            //update lastTickProduced
            foreach (KeyValuePair<GoodType, float> goodPair in goodProduceWeights) {

                if (lastTickProduced.ContainsKey(goodPair.Key))
                    lastTickProduced[goodPair.Key] = NumPeople * goodPair.Value;

                else
                    lastTickProduced.Add(goodPair.Key, NumPeople * goodPair.Value);
            }



            

        }

    }



}
