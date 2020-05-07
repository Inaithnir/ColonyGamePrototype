using System;
using System.Collections.Generic;
using static GameEngine.GameData;

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

        Dictionary<GoodType, float> peopleLastConsumed;
        Dictionary<GoodType, float> peopleLastProduced;

        public float PeopleConsumpMod { get; private set; } //To replace with dictionary of modifiers
        public float PeopleProdMod { get; private set; } //To replace with dictionary of modifiers




        Dictionary<GoodType, float> buildingLastConsumed;
        Dictionary<GoodType, float> buildingLastProduced;

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

            peopleLastConsumed = new Dictionary<GoodType, float>();
            peopleLastProduced = new Dictionary<GoodType, float>();
            buildingLastConsumed = new Dictionary<GoodType, float>();
            buildingLastProduced = new Dictionary<GoodType, float>();


        }





        //methods
        public float calcPeopleConsumption(GoodType goodType) {
            float peopleConsump = DistrictPopulation.calcConsumption(goodType) * PeopleConsumpMod; //To change to work with dictionary of modifiers
            return peopleConsump;
        }

        public float getLastPeopleConsumed(GoodType goodType) {
            if (peopleLastConsumed.ContainsKey(goodType))
                return peopleLastConsumed[goodType];

            return 0;
        }



        public float calcPeopleProduced(GoodType goodType) {
            float peopleProduced = DistrictPopulation.calcProduction(goodType) * PeopleProdMod; //To change to work with dictionary of modifiers
            return peopleProduced;
        }

        public float getLastPeopleProduced(GoodType goodType) {
            if (peopleLastProduced.ContainsKey(goodType))
                return peopleLastProduced[goodType];

            return 0;
        }


        public float calcBuildingConsumption(GoodType goodType) {
            float buildingConsump = 0;
            foreach (Building building in DistrictBuildings) {
                buildingConsump += building.getConsumed(goodType) * BuildingConsumpMod; //To change to work with dictionary of modifiers
            }
            return buildingConsump;
        }

        public float getLastBuildingConsumed(GoodType goodType) {
            if (buildingLastConsumed.ContainsKey(goodType))
                return buildingLastConsumed[goodType];

            return 0;
        }



        public float calcBuildingProduced(GoodType goodType) {
            float buildingProduced = 0;
            foreach (Building building in DistrictBuildings) {
                buildingProduced += building.getProduced(goodType) * BuildingProdMod; //To change to work with dictionary of modifiers
            }
            return buildingProduced;
        }

        public float getLastBuildingProduced(GoodType goodType) {
            if (buildingLastProduced.ContainsKey(goodType))
                return buildingLastProduced[goodType];

            return 0;
        }



        public void addBuilding(Building buildingToAdd) {
            DistrictBuildings.Add(buildingToAdd);
        }


        public Dictionary<GoodType, float> getPeopleProduction() {
            return peopleLastProduced;
        }
        public Dictionary<GoodType, float> getPeopleConsumption() {
            return peopleLastConsumed;
        }
        public Dictionary<GoodType, float> getBuildingProduction() {
            return buildingLastProduced;
        }
        public Dictionary<GoodType, float> getBuildingConsumption() {
            return buildingLastConsumed;
        }




        public void updateTick() {


            DistrictPopulation.updateTick();

            


            List<GoodType> peopleGoodConsList = DistrictPopulation.getConsumptionList();
            List<GoodType> peopleGoodProdList = DistrictPopulation.getProductionList();




            foreach(GoodType good in peopleGoodConsList) {
                if (peopleLastConsumed.ContainsKey(good) == false) {
                    peopleLastConsumed.Add(good, DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod);
                }
                else
                    peopleLastConsumed[good] = DistrictPopulation.getLastConsumption(good) * PeopleConsumpMod;
            }


            foreach (GoodType good in peopleGoodProdList) {
                if (peopleLastProduced.ContainsKey(good) == false) {
                    peopleLastProduced.Add(good, DistrictPopulation.getLastProduction(good) * PeopleProdMod);
                }
                else
                    peopleLastProduced[good] = DistrictPopulation.getLastProduction(good) * PeopleProdMod;
       
            }





            List<GoodType> buildingGoodConsList = new List<GoodType>();
            List<GoodType> buildingGoodProdList = new List<GoodType>();


            List<GoodType> iterateKeys = new List<GoodType>(buildingLastConsumed.Keys);

            foreach (GoodType goodPair in iterateKeys) {
                buildingLastConsumed[goodPair] = 0;
            }


            iterateKeys.Clear();
            iterateKeys.AddRange(buildingLastProduced.Keys);
            foreach (GoodType goodPair in iterateKeys) {
                buildingLastProduced[goodPair] = 0;
            }

            foreach (Building building in DistrictBuildings) { 

                building.updateTick();

                buildingGoodConsList.Clear();
                buildingGoodProdList.Clear();

                buildingGoodConsList.AddRange(building.getConsumptionList()); //The list you get from building SHOULD BE UNIQUE
                buildingGoodProdList.AddRange(building.getProductionList()); //The list you get from building SHOULD BE UNIQUE

                foreach (GoodType good in buildingGoodConsList) {
                    if (buildingLastConsumed.ContainsKey(good) == false)
                        buildingLastConsumed.Add(good, building.getConsumed(good) * BuildingConsumpMod);
                    else
                        buildingLastConsumed[good] += building.getConsumed(good) * BuildingConsumpMod;
                }
                foreach (GoodType good in buildingGoodProdList) {
                    if (buildingLastProduced.ContainsKey(good) == false)
                        buildingLastProduced.Add(good, building.getProduced(good) * BuildingProdMod);
                    else
                        buildingLastProduced[good] += building.getProduced(good) * BuildingProdMod;
                }



            }




        }






    }
}
