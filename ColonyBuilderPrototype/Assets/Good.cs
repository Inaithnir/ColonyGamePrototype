using System;
using System.Collections.Generic;

namespace GameEngine {



    class Good {

        public enum GoodList : int {
            Food = 100,
            Coins = 200,
        }

        public static Dictionary<GoodList, float[]> ConsumeWeights = new Dictionary<GoodList, float[]>() {

            { GoodList.Food, new float[Population.NumPopTypes] {2.0f, 3.0f, 5.0f} },
            { GoodList.Coins, new float[Population.NumPopTypes] {0f, 0f, 0f} },

        };

        public GoodList Name { get; }
        public String Description {get; }
        public float BaseValue { get; set; }
        public float[] ConsumpWeights { get; }



        public Good(GoodList nameIn) {
            this.Name = nameIn;
        }

        
    }

    

}
