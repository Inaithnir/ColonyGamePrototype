using System;
using System.Collections.Generic;

namespace GameEngine {


    class District {

        public enum DistrictList : int {
            GrowingBorough = 0,
            Borough = 1,
            Farmlands = 2,
            Manufactories = 3
        }

        public DistrictList DistrictType { get; }
        public Population DistrictPopulation {get; }
        public List<Building> DistrictBuildings { get; }
        //Some kind of list with local modifiers
        //Public Policy DistrictPolicy {get;}

        Dictionary<Good, float> peopleLastConsumed;
        Dictionary<Good, float> peopleLastProduced;

        public float PeopleConsumpMod { get; private set; } //To replace with dictionary of modifiers
        public float PeopleProdMod { get; private set; } //To replace with dictionary of modifiers




        Dictionary<Good, float> buildingLastConsumed;
        Dictionary<Good, float> buildingLastProduced;

        public float BuildingConsumpMod { get; private set; } //To replace with dictionary of modifiers
        public float BuildingProdMod { get; private set; } //To replace with dictionary of modifiers






        //Constructor

        public District(DistrictList typeIn) {

            DistrictType = typeIn;

            if ((int)typeIn ==0 || (int)typeIn ==1)
                DistrictPopulation = new Population();

            DistrictBuildings = new List<Building>();

            PeopleConsumpMod = 1;
            PeopleProdMod = 1;

            BuildingConsumpMod = 1;
            BuildingProdMod = 1;

            peopleLastConsumed = new Dictionary<Good, float>();
            peopleLastProduced = new Dictionary<Good, float>();
            buildingLastConsumed = new Dictionary<Good, float>();
            buildingLastProduced = new Dictionary<Good, float>();


        }





        //methods
        public float calcPeopleConsumption(Good goodType) {

            
            float peopleConsump = DistrictPopulation.calcConsumption(goodType)*PeopleConsumpMod; //To change to work with dictionary of modifiers

            return peopleConsump;
        
        }

        public float calcPeopleProduced(Good goodType) {

            float peopleProduced = DistrictPopulation.calcProduction(goodType) * PeopleProdMod; //To change to work with dictionary of modifiers

            return peopleProduced;


        }


        public float calcBuildingConsumption(Good goodType) {


            float buildingConsump = 0;

            foreach (Building building in DistrictBuildings) {
                buildingConsump += building.calcConsumption(goodType)*BuildingConsumpMod; //To change to work with dictionary of modifiers
            }

            return buildingConsump;

        }

        public float calcBuildingProduced(Good goodType) {

            float buildingProduced = 0;

            foreach (Building building in DistrictBuildings) {
                buildingProduced += building.calcProduction(goodType) * BuildingProdMod; //To change to work with dictionary of modifiers
            }

            return buildingProduced;

        }





        public void updateTick() {



        }






    }
}
