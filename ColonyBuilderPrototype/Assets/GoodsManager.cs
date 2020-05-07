﻿using System;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

namespace GameEngine {


    class GoodsManager {

        Dictionary<Good, int> pileOGoods;
        Dictionary<Good.GoodList, Good> goodTable;

        //constructor
        public GoodsManager(bool fullList) {

            pileOGoods = new Dictionary<Good, int>();
            goodTable = new Dictionary<Good.GoodList, Good>();
            
            if (fullList == true) {

                foreach(Good.GoodList goodType in Enum.GetValues(typeof(Good.GoodList)))
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
        public int getAmount(Good.GoodList goodQuery) {
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
        public void changeAmount (Good.GoodList goodToChange,int delta) {
            Good matchGood = goodTable[goodToChange];
            if (pileOGoods.ContainsKey(matchGood))
                pileOGoods[matchGood] += delta;
            else
                pileOGoods.Add(matchGood,delta);

            Debug.Log("Good " + goodToChange.ToString() + " changed by " + delta);
            return;
        }


        public Good getGood(Good.GoodList goodToGet)
        {
            if (goodTable.ContainsKey(goodToGet))
                return goodTable[goodToGet];
            else
                return null;
        }

        public override String ToString()
        {
            String stringToReturn = "";
            foreach(KeyValuePair<Good,int> goodPair in pileOGoods)
            {
                stringToReturn += goodPair.Key.Name + " " + goodPair.Key.Description + " with amount " + goodPair.Value;
            }

            return stringToReturn;

        }




    }
}
