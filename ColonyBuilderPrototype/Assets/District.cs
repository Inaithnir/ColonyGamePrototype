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

        Dictionary<Good.GoodList, float> peopleLastConsumed;
        Dictionary<Good.GoodList, float> peopleLastProduced;

        public float PeopleConsumpMod { get; private set; } //To replace with dictionary of modifiers
        public float PeopleProdMod { get; private set; } //To replace with dictionary of modifiers




        Dictionary<Good.GoodList, float> buildingLastConsumed;
        Dictionary<Good.GoodList, float> buildingLastProduced;

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

            peopleLastConsumed = new Dictionary<Good.GoodList, float>();
            peopleLastProduced = new Dictionary<Good.GoodList, float>();
            buildingLastConsumed = new Dictionary<Good.GoodList, float>();
            buildingLastProduced = new Dictionary<Good.GoodList, float>();


        }





        //methods
        public float calcPeopleConsumption(Good.GoodList goodType) {
            float peopleConsump = DistrictPopulation.calcConsumption(goodType) * PeopleConsumpMod; //To change to work with dictionary of modifiers
            return peopleConsump;
        }

        public float getLastPeopleConsumed(Good.GoodList goodType) {
            if (peopleLastConsumed.ContainsKey(goodType))
                return peopleLastConsumed[goodType];

            return 0;
        }



        public float calcPeopleProduced(Good.GoodList goodType) {
            float peopleProduced = DistrictPopulation.calcProduction(goodType) * PeopleProdMod; //To change to work with dictionary of modifiers
            return peopleProduced;
        }

        public float getLastPeopleProduced(Good.GoodList goodType) {
            if (peopleLastProduced.ContainsKey(goodType))
                return peopleLastProduced[goodType];

            return 0;
        }


        public float calcBuildingConsumption(Good.GoodList goodType) {
            float buildingConsump = 0;
            foreach (Building building in DistrictBuildings) {
                buildingConsump += building.getConsumed(goodType) * BuildingConsumpMod; //To change to work with dictionary of modifiers
            }
            return buildingConsump;
        }

        public float getLastBuildingConsumed(Good.GoodList goodType) {
            if (buildingLastConsumed.ContainsKey(goodType))
                return buildingLastConsumed[goodType];

            return 0;
        }



        public float calcBuildingProduced(Good.GoodList goodType) {
            float buildingProduced = 0;
            foreach (Building building in DistrictBuildings) {
                buildingProduced += building.getProduced(goodType) * BuildingProdMod; //To change to work with dictionary of modifiers
            }
            return buildingProduced;
        }

        public float getLastBuildingProduced(Good.GoodList goodType) {
            if (buildingLastProduced.ContainsKey(goodType))
                return buildingLastProduced[goodType];

            return 0;
        }



        public void addBuilding(Building buildingToAdd) {
            DistrictBuildings.Add(buildingToAdd);
        }


        public Dictionary<Good.GoodList, float> getPeopleProduction() {
            return peopleLastProduced;
        }
        public Dictionary<Good.GoodList, float> getPeopleConsumption() {
            return peopleLastConsumed;
        }
        public Dictionary<Good.GoodList, float> getBuildingProduction() {
            return buildingLastProduced;
        }
        public Dictionary<Good.GoodList, float> getBuildingConsumption() {
            return buildingLastConsumed;
        }




        public void updateTick() {


            DistrictPopulation.updateTick();

            


            List<Good.GoodList> peopleGoodConsList = DistrictPopulation.getConsumptionList();
            List<Good.GoodList> peopleGoodProdList = DistrictPopulation.getProductionList();




            foreach(Good.GoodList good in peopleGoodConsList) {
                if (peopleLastConsumed.ContainsKey(good) == false) {
                    peopleLastConsumed.Add(good, DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod);
                }
                else
                    peopleLastConsumed[good] = DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod;
            }


            foreach (Good.GoodList good in peopleGoodProdList) {
                if (peopleLastProduced.ContainsKey(good) == false) {
                    peopleLastProduced.Add(good, DistrictPopulation.getLastProduction(good) * PeopleProdMod);
                }
                else
                    peopleLastProduced[good] = DistrictPopulation.getLastProduction(good) * PeopleProdMod;
       
            }





            List<Good.GoodList> buildingGoodConsList = new List<Good.GoodList>();
            List<Good.GoodList> buildingGoodProdList = new List<Good.GoodList>();


            foreach (KeyValuePair<Good.GoodList, float> goodPair in buildingLastConsumed) {
                buildingLastConsumed[goodPair.Key] = 0;
            }
            foreach (KeyValuePair<Good.GoodList, float> goodPair in buildingLastProduced) {
                buildingLastProduced[goodPair.Key] = 0;
            }

            foreach (Building building in DistrictBuildings) { 

                building.updateTick();

                buildingGoodConsList.Clear();
                buildingGoodProdList.Clear();

                buildingGoodConsList.AddRange(building.getConsumptionList()); //The list you get from building SHOULD BE UNIQUE
                buildingGoodProdList.AddRange(building.getProductionList()); //The list you get from building SHOULD BE UNIQUE

                foreach (Good.GoodList good in buildingGoodConsList) {
                    if (buildingLastConsumed.ContainsKey(good) == false)
                        buildingLastConsumed.Add(good, building.getConsumed(good) * BuildingConsumpMod);
                    else
                        buildingLastConsumed[good] += building.getConsumed(good) * BuildingConsumpMod;
                }
                foreach (Good.GoodList good in buildingGoodProdList) {
                    if (buildingLastProduced.ContainsKey(good) == false)
                        buildingLastProduced.Add(good, building.getProduced(good) * BuildingProdMod);
                    else
                        buildingLastProduced[good] += building.getProduced(good) * BuildingProdMod;
                }



            }




        }






    }
}
