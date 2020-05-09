using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEngine.GameData;


namespace GameEngine {
	public class Modifier {

		public float Amount { get; }
		public String Name { get; private set; }

		public enum Affects {
			Production = 1,
			Consumption = 2
		}

		public Affects ModAffects { get; }
		public bool IsGlobal { get; private set; }


		
	}
}