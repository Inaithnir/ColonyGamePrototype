using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {
    class Population {

        public int CurrentPop { get; private set; }
        Demographic[] demographics;

        Dictionary<GoodType, float> lastTickTotConsumed;
        Dictionary<GoodType, float> lastTickTotProduced;




        //constructors
        public Population() {

            CurrentPop = 0;

            demographics = new Demographic[3];

            for (int i=0; i<3; i++) {
                demographics[i] = new Demographic((Demographic.DemoType)(i + 1));
                CurrentPop += demographics[i].NumPeople;
            }
            
            lastTickTotConsumed = new Dictionary<GoodType, float>();
            lastTickTotProduced = new Dictionary<GoodType, float>();
            
        }



        //Methods

        public float calcConsumption(GoodType good) {
            float totalConsumption = 0;

            foreach(Demographic demographic in demographics) {
                totalConsumption += demographic.calcConsumption(good);
            }
            
            return totalConsumption;
            
        }

        public float getLastConsumption(GoodType good) {
            if (lastTickTotConsumed.ContainsKey(good))
                return lastTickTotConsumed[good];

            return 0;
        }




        public float calcProduction(GoodType good) {
            float totalProduction = 0;

            foreach (Demographic demographic in demographics) {
                totalProduction += demographic.calcProduction(good);
            }

            return totalProduction;

        }

        public float getLastProduction(GoodType good) {
            if (lastTickTotProduced.ContainsKey(good))
                return lastTickTotProduced[good];

            return 0;
        }


        public List<GoodType> getConsumptionList() {

            List<GoodType> consumedGoods = new List<GoodType>();

            foreach (KeyValuePair<GoodType, float> goodPairs in lastTickTotConsumed)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);


            return consumedGoods;
        }




        public List<GoodType> getProductionList() {

            List<GoodType> producedGoods = new List<GoodType>();

            foreach (KeyValuePair<GoodType, float> goodPairs in lastTickTotProduced)
                if (goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);


            return producedGoods;
        }













        public void updateTick() {

            //First, reset all consumption and production values to zero
            foreach(KeyValuePair<GoodType, float> goodPair in lastTickTotConsumed) {
                lastTickTotConsumed[goodPair.Key] = 0;
            }
            foreach (KeyValuePair<GoodType, float> goodPair in lastTickTotProduced) {
                lastTickTotProduced[goodPair.Key] = 0;
            }


            //Reset population to zero

            CurrentPop = 0;





            //Loop over each demographic and add their consumption/production for each good
            foreach (Demographic demographic in demographics) {

                demographic.updateTick();

                List<GoodType> goodsConsumptionList = demographic.getConsumptionList();
                List<GoodType> goodsProductionList = demographic.getProductionList();



                foreach(GoodType good in goodsConsumptionList) {
                    if (lastTickTotConsumed.ContainsKey(good) == false)//if good is not yet in, add it
                        lastTickTotConsumed.Add(good, demographic.getLastConsumption(good));
                    else
                        lastTickTotConsumed[good] += demographic.getLastConsumption(good);
                }

                foreach (GoodType good in goodsProductionList) {
                    if (lastTickTotProduced.ContainsKey(good) == false)//if good is not yet in, add it
                        lastTickTotProduced.Add(good, demographic.getLastProduction(good));
                    else
                        lastTickTotProduced[good] += demographic.getLastProduction(good);
                }












                //TODO: Growh/shrink population and update total Population



                CurrentPop += demographic.NumPeople;



            }





        }







    }
}
