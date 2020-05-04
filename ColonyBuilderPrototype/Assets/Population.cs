using System;
using System.Collections.Generic;

namespace GameEngine {
    class Population {

        public enum PopType : int { //NOTE: if adding or removing a PopType, change NumPopTypes below AND weight arrays in Good.cs
            Peasant = 1,
            Merchant = 2,
            Elite = 3
        }
        public const int NumPopTypes = 3;


        public int CurrentPop { get; }
        public int[] PopDistro { get; }
        
        //constructors
        public Population() {

            CurrentPop = 0;
            PopDistro = new int[NumPopTypes];

            for (int i = 0; i < NumPopTypes; i++)
                PopDistro[i] = 0;

        }

        public Population(int[] popDist) {

            if (popDist.Length != NumPopTypes)
                throw new System.ArgumentException("popDist length does not match PopType enum length.", "popDist");

            PopDistro = new int[NumPopTypes];

            for (int i = 0; i < NumPopTypes; i++) {
                CurrentPop += popDist[i];
                PopDistro[i] = popDist[i];
            }

        }

        //Methods

        public float calcConsumption(Good good) {

            float[] thisWeight = Good.ConsumeWeights[good.Name];
            float toReturn = 0f;

            return toReturn;
        }
    }
}
