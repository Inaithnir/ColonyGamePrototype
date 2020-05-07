using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {



    class Good {


        public GoodType Name { get; }
        //public String Description { get;  }
        public float BaseValue { get; set; }
        

        
        public Good(GoodType nameIn) {
            this.Name = nameIn;
            //Description = "";
        }

        
    }

    

}
