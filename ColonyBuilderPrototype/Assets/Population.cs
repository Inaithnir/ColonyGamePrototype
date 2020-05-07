using System;
using System.Collections.Generic;

namespace GameEngine {
    class Population {

        public int CurrentPop { get; private set; }
        Demographic[] demographics;

        Dictionary<Good.GoodList, float> lastTickTotConsumed;
        Dictionary<Good.GoodList, float> lastTickTotProduced;




        //constructors
        public Population() {

            CurrentPop = 0;

            demographics = new Demographic[3];

            for (int i=0; i<3; i++) {
                demographics[i] = new Demographic((Demographic.DemoType)(i + 1));
                CurrentPop += demographics[i].NumPeople;
            }
            
            lastTickTotConsumed = new Dictionary<Good.GoodList, float>();
            lastTickTotProduced = new Dictionary<Good.GoodList, float>();
            
        }



        //Methods

        public float calcConsumption(Good.GoodList good) {
            float totalConsumption = 0;

            foreach(Demographic demographic in demographics) {
                totalConsumption += demographic.calcConsumption(good);
            }
            
            return totalConsumption;
            
        }

        public float getLastConsumption(Good.GoodList good) {
            if (lastTickTotConsumed.ContainsKey(good))
                return lastTickTotConsumed[good];

            return 0;
        }




        public float calcProduction(Good.GoodList good) {
            float totalProduction = 0;

            foreach (Demographic demographic in demographics) {
                totalProduction += demographic.calcProduction(good);
            }

            return totalProduction;

        }

        public float getLastProduction(Good.GoodList good) {
            if (lastTickTotProduced.ContainsKey(good))
                return lastTickTotProduced[good];

            return 0;
        }


        public List<Good.GoodList> getConsumptionList() {

            List<Good.GoodList> consumedGoods = new List<Good.GoodList>();

            foreach (KeyValuePair<Good.GoodList, float> goodPairs in lastTickTotConsumed)
                if (goodPairs.Value != 0)
                    consumedGoods.Add(goodPairs.Key);


            return consumedGoods;
        }




        public List<Good.GoodList> getProductionList() {

            List<Good.GoodList> producedGoods = new List<Good.GoodList>();

            foreach (KeyValuePair<Good.GoodList, float> goodPairs in lastTickTotProduced)
                if (goodPairs.Value != 0)
                    producedGoods.Add(goodPairs.Key);


            return producedGoods;
        }













        public void updateTick() {

            //First, reset all consumption and production values to zero
            foreach(KeyValuePair<Good.GoodList, float> goodPair in lastTickTotConsumed) {
                lastTickTotConsumed[goodPair.Key] = 0;
            }
            foreach (KeyValuePair<Good.GoodList, float> goodPair in lastTickTotProduced) {
                lastTickTotProduced[goodPair.Key] = 0;
            }


            //Reset population to zero

            CurrentPop = 0;





            //Loop over each demographic and add their consumption/production for each good
            foreach (Demographic demographic in demographics) {

                demographic.updateTick();

                List<Good.GoodList> goodsConsumptionList = demographic.getConsumptionList();
                List<Good.GoodList> goodsProductionList = demographic.getProductionList();



                foreach(Good.GoodList good in goodsConsumptionList) {
                    if (lastTickTotConsumed.ContainsKey(good) == false)//if good is not yet in, add it
                        lastTickTotConsumed.Add(good, demographic.getLastConsumption(good));
                    else
                        lastTickTotConsumed[good] += demographic.getLastConsumption(good);
                }

                foreach (Good.GoodList good in goodsProductionList) {
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
