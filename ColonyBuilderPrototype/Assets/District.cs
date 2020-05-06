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
            float peopleConsump = DistrictPopulation.calcConsumption(goodType) * PeopleConsumpMod; //To change to work with dictionary of modifiers
            return peopleConsump;
        }

        public float getLastPeopleConsumed(Good goodType) {
            if (peopleLastConsumed.ContainsKey(goodType))
                return peopleLastConsumed[goodType];

            return 0;
        }



        public float calcPeopleProduced(Good goodType) {
            float peopleProduced = DistrictPopulation.calcProduction(goodType) * PeopleProdMod; //To change to work with dictionary of modifiers
            return peopleProduced;
        }

        public float getLastPeopleProduced(Good goodType) {
            if (peopleLastProduced.ContainsKey(goodType))
                return peopleLastProduced[goodType];

            return 0;
        }


        public float calcBuildingConsumption(Good goodType) {
            float buildingConsump = 0;
            foreach (Building building in DistrictBuildings) {
                buildingConsump += building.getConsumed(goodType) * BuildingConsumpMod; //To change to work with dictionary of modifiers
            }
            return buildingConsump;
        }

        public float getLastBuildingConsumed(Good goodType) {
            if (buildingLastConsumed.ContainsKey(goodType))
                return buildingLastConsumed[goodType];

            return 0;
        }



        public float calcBuildingProduced(Good goodType) {
            float buildingProduced = 0;
            foreach (Building building in DistrictBuildings) {
                buildingProduced += building.getProduced(goodType) * BuildingProdMod; //To change to work with dictionary of modifiers
            }
            return buildingProduced;
        }

        public float getLastBuildingProduced(Good goodType) {
            if (buildingLastProduced.ContainsKey(goodType))
                return buildingLastProduced[goodType];

            return 0;
        }



        public void addBuilding(Building buildingToAdd) {
            DistrictBuildings.Add(buildingToAdd);
        }








        public void updateTick() {


            DistrictPopulation.updateTick();

            


            List<Good> peopleGoodConsList = DistrictPopulation.getConsumptionList();
            List<Good> peopleGoodProdList = DistrictPopulation.getProductionList();




            foreach(Good good in peopleGoodConsList) {
                if (peopleLastConsumed.ContainsKey(good) == false) {
                    peopleLastConsumed.Add(good, DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod);
                }
                else
                    peopleLastConsumed[good] = DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod;
            }


            foreach (Good good in peopleGoodProdList) {
                if (peopleLastProduced.ContainsKey(good) == false) {
                    peopleLastProduced.Add(good, DistrictPopulation.getLastProduction(good) * PeopleProdMod);
                }
                else
                    peopleLastProduced[good] = DistrictPopulation.getLastProduction(good) * PeopleProdMod;
       
            }





            List<Good> buildingGoodConsList = new List<Good>();
            List<Good> buildingGoodProdList = new List<Good>();


            foreach (KeyValuePair<Good, float> goodPair in buildingLastConsumed) {
                buildingLastConsumed[goodPair.Key] = 0;
            }
            foreach (KeyValuePair<Good, float> goodPair in buildingLastProduced) {
                buildingLastProduced[goodPair.Key] = 0;
            }

            foreach (Building building in DistrictBuildings) { 

                building.updateTick();

                buildingGoodConsList.Clear();
                buildingGoodProdList.Clear();

                buildingGoodConsList.AddRange(building.getConsumptionList()); //The list you get from building SHOULD BE UNIQUE
                buildingGoodProdList.AddRange(building.getProductionList()); //The list you get from building SHOULD BE UNIQUE

                foreach (Good good in buildingGoodConsList) {
                    if (buildingLastConsumed.ContainsKey(good) == false)
                        buildingLastConsumed.Add(good, building.getConsumed(good) * BuildingConsumpMod);
                    else
                        buildingLastConsumed[good] += building.getConsumed(good) * BuildingConsumpMod;
                }
                foreach (Good good in buildingGoodProdList) {
                    if (buildingLastProduced.ContainsKey(good) == false)
                        buildingLastProduced.Add(good, building.getProduced(good) * BuildingProdMod);
                    else
                        buildingLastProduced[good] += building.getProduced(good) * BuildingProdMod;
                }



            }




        }






    }
}
