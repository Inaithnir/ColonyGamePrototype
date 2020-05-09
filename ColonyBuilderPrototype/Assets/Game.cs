﻿using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {

    class Game {

        Colony playerColony;





        public Game() {

            playerColony = new Colony("TestColony");


            playerColony.addDistrict(new District(DistrictTypes.Borough));
        }



        public void updateTick()
        {
            
            playerColony.updateTick();
        }


    }
}
