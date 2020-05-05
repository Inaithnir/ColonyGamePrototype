using System;
using System.Collections.Generic;

namespace GameEngine {



    class Good {

        public enum GoodList : int {
            Food = 100,
        }

        public GoodList Name { get; }
        public String Description {get; }
        public float BaseValue { get; set; }
        public float[] ConsumpWeights { get; }

        
        public Good(GoodList nameIn) {
            this.Name = nameIn;
        }

        
    }

    

}
