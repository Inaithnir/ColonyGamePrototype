using System;
using System.Collections;
using System.Collections.Generic;


namespace GameEngine {

    public static class GameData {

        //Good stuff
        public enum GoodType {
            Food = 100,
            Wood = 200
        }



        //Demographic stuff

        public enum DemoType { //if adjusted, make sure to change the type counter below, the BaseTargetPop enum, and the appropriate production/consumption weight settings
            Peasant = 0,
            Merchant = 1,
            Elite = 2,
            Native = 3,
        }
        public const int NumDemoTypes = 4;

        public enum BaseTargetPop {
            Peasant = 100,
            Merchant = 250,
            Elite = 400,
            Native = 0,

        }

        public static Dictionary<GoodType, float[]> PeopleConsumptionWeights = new Dictionary<GoodType, float[]>() {
            {GoodType.Food,     new float[]{-0.01f, -0.03f, -0.05f, -0.02f} },
            {GoodType.Wood,     new float[]{-0.005f, -0.01f, -0.02f, -0.01f} },
        };

        public static Dictionary<GoodType, float[]> PeopleProductionWeights = new Dictionary<GoodType, float[]>() {
            {GoodType.Food,     new float[]{0,0,0,0} },

        };

        //Building stuff
        public enum BuildType {
            Farm = 100,
            CharcoalBurner = 200,
        }

        public enum BuildSize {
            Farm = 1,
        }

        public static Dictionary<BuildType, GoodType[]> BuildingGoodsConsumed = new Dictionary<BuildType, GoodType[]>() {
            {BuildType.Farm,            new GoodType[]{ } },
            {BuildType.CharcoalBurner,  new GoodType[]{GoodType.Wood } }

        };

        public static Dictionary<BuildType, float[]> BuildingConsumptionWeights = new Dictionary<BuildType, float[]>() {
            {BuildType.Farm,            new float[]{ } },
            {BuildType.CharcoalBurner,  new float[]{0.5f} }
        };

        public static Dictionary<BuildType, GoodType[]> BuildingGoodsProduced = new Dictionary<BuildType, GoodType[]>() {
            {BuildType.Farm,            new GoodType[]{ GoodType.Food} },
            {BuildType.CharcoalBurner,  new GoodType[]{} }

        };

        public static Dictionary<BuildType, float[]> BuildingProductionWeights = new Dictionary<BuildType, float[]>() {
            {BuildType.Farm,            new float[]{5f } },
            {BuildType.CharcoalBurner,  new float[]{} }
        };

        public static Dictionary<BuildType, GoodType[]> BuildingConstructionGoods = new Dictionary<BuildType, GoodType[]> {
            {BuildType.Farm,            new GoodType[]{GoodType.Wood} }
        };

        public static Dictionary<BuildType, int[]> BuildingConstructionAmounts = new Dictionary<BuildType, int[]> {
            {BuildType.Farm,            new int[]{100} }
        };
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




        //Map Stuff
        public enum TileType {
            Grass = 1,
            Forest = 2,
            River = 3,
            Mountain = 4,
            Sea = 5
        }
    }
}
