using System;
using System.Collections.Generic;
using static GameEngine.GameData;



namespace GameEngine {
	public class MapTile {


		public int x { get; private set; }
		public int y { get; private set; }

		public bool occupied { get; private set; }

		public District OwningDistrict { get; private set; }

		public TileType MyType { get; private set; }


		public MapTile(int xlocation, int ylocation) {
			x = xlocation;
			y = ylocation;
			occupied = false;
			OwningDistrict = null;
			MyType = TileType.Grass;
		}





		public void setOwningDistrict(District district) {
			OwningDistrict = district;
			occupied = true;
		}

		public void setTileType(TileType type) {
			MyType = type;
		}
	}
}
