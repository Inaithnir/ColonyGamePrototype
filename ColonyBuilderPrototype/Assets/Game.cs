using System;
using System.Collections.Generic;
using static GameEngine.GameData;

namespace GameEngine {

    class Game {

        Colony playerColony;
        public static Game CurrentGame { get; private set; }
        List<District> ColonyDistricts = new List<District>();



        public Game() {
            CurrentGame = this;




            playerColony = new Colony("TestColony");
            ColonyDistricts = playerColony.getDistrictList();

        }



        public void updateTick()
        {
            
            playerColony.updateTick();
        }


    }
}
