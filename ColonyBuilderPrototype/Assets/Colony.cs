using System;
using System.Collections.Generic;

namespace GameEngine {
    class Colony {

        GoodsManager colonyGoods;
        List<District> colonyDistricts;
        Population totalPopulation;



        //Constructor
        public Colony() {

            colonyDistricts = new List<District>();

            colonyGoods = new GoodsManager(true);



        }




    }
}
