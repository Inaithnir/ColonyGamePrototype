using System;
using System.Collections;
using System.Collections.Generic;


namespace GameEngine {

    public static class GameData {

        //Good stuff
        public enum GoodType {
            Food = 100,
        }



        //Demographic stuff

        public enum DemoType  { //if adjusted, make sure to change the type counter below, the BaseTargetPop enum, and the appropriate production/consumption weight settings
            Peasant = 0,
            Merchant = 1,
            Elite = 2,
            Native = 3,
        }
        public const int NumDemoTypes = 4;

        public enum BaseTargetPop {
            Peasant = 400,
            Merchant = 250,
            Elite = 150,
            Native = 0,

        }


        //Building stuff
        public enum BuildType {
            TestFarm = 0,
            Farm = 100,
        }

        public enum BuildSize {
            TestFarm = 1,
            Farm = 1,
        }

        //District stuff

        public enum DistrictTypes {
            GrowingBorough = 0,
            Borough = 1,
            Farmlands = 2,
            Manufactories = 3
        }

        //Modifier stuff
        public enum ModType {
            Production = 1,
            Consumption = 2,

        }
    }
}
