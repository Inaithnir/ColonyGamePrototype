using System;
using System.Collections.Generic;

namespace GameEngine {


    class GoodsManager {

        Dictionary<Good, int> pileOGoods;

        //constructor
        public GoodsManager(bool fullList) {

            pileOGoods = new Dictionary<Good, int>();
            
            if (fullList == true) {

                foreach(Good.GoodList goodType in Enum.GetValues(typeof(Good.GoodList))) 
                    pileOGoods.Add(new Good(goodType), 0);                            

            }
        }

        //methods


        /*
        * Method name: getAmount: get the amount of a good, if it exists, otherwise return 0.
        * Arguments:
        *    Good goodQuery - good that we need the amount of
        * Returns: int, the amount of the good (or 0 if doesnt exist)
        */
        public int getAmount(Good goodQuery) {
            if (pileOGoods.ContainsKey(goodQuery))
                return pileOGoods[goodQuery];
            else
                return 0;
        }

        /*
        * Method name: changeAmount: change the amount of a good by delta, or add it if it isnt in the list
        * Arguments:
        *    Good goodToChange - good that we need to change the amount of (or possibly add)
        *    int delta - the amount to change the value of the good by (or initialize with)
        * Returns: zip
        */
        public void changeAmount (Good goodToChange,int delta) {

            if (pileOGoods.ContainsKey(goodToChange))
                pileOGoods[goodToChange] += delta;
            else
                pileOGoods.Add(goodToChange,delta);

            return;
        }



    }
}
