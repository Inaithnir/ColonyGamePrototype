using System;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using static GameEngine.GameData;

namespace GameEngine {


    class GoodsManager {

        Dictionary<Good, float> pileOGoods;
        Dictionary<GoodType, Good> goodTable;

        //constructor
        public GoodsManager(bool fullList) {

            pileOGoods = new Dictionary<Good, float>();
            goodTable = new Dictionary<GoodType, Good>();
            
            if (fullList == true) {

                foreach(GoodType goodType in Enum.GetValues(typeof(GoodType)))
                {
                    Good goodToAdd = new Good(goodType);
                    pileOGoods.Add(goodToAdd, 0);
                    goodTable.Add(goodType, goodToAdd);
                }
                    

            }
        }

        //methods


        /*
        * Method name: getAmount: get the amount of a good, if it exists, otherwise return 0.
        * Arguments:
        *    Good goodQuery - good that we need the amount of
        * Returns: int, the amount of the good (or 0 if doesnt exist)
        */
        public float getAmount(GoodType goodQuery) {
            Good matchGood = goodTable[goodQuery];
            if (pileOGoods.ContainsKey(matchGood))
                return pileOGoods[matchGood];
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
        public void changeAmount (GoodType goodToChange,float delta) {
            Good matchGood = goodTable[goodToChange];
            if (pileOGoods.ContainsKey(matchGood))
                pileOGoods[matchGood] += delta;
            else
                pileOGoods.Add(matchGood,delta);
            return;
        }


        public Good getGood(GoodType goodToGet)
        {
            if (goodTable.ContainsKey(goodToGet))
                return goodTable[goodToGet];
            else
                return null;
        }

        public override String ToString()
        {
            String stringToReturn = "";
            foreach(KeyValuePair<Good, float> goodPair in pileOGoods)
            {
                stringToReturn += goodPair.Key.Name + " with amount " + goodPair.Value;
            }

            return stringToReturn;

        }




    }
}
