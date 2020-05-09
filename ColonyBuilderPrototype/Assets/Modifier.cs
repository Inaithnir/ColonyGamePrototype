using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEngine.GameData;


namespace GameEngine {
	public class Modifier {

		public float Amount { get; }
		public String Name { get; private set; }
		public ModType ModAffects { get; }
		
	}
}