using System;
using System.Collections.Generic;
using System.Numerics;
using static GameEngine.GameData;


namespace GameEngine {
	public class GameMap {

		public int Height { get; private set; }
		public int Width { get; private set; }

		public static GameMap ThisGameMap { get; private set; }

		public Dictionary<Vector2, MapTile> MapTiles { get; private set; }




		public GameMap(int height, int width) {

			ThisGameMap = this;


			Height = height;
			Width = width;
			MapTiles = new Dictionary<Vector2, MapTile>();


			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					MapTile tile = new MapTile(i, j);

					MapTiles.Add(new Vector2(i, j), tile);
				}
			}

		}




		public MapTile getTileAt(int x, int y) {
			if (x < 0 || y < 0 || x > Width || y > Height) {
				return null; //return null if the requested tile (for some reason) is outside the actual play area
			}
			
			return MapTiles[new Vector2(x, y)];

		}

		public List<MapTile> getNeighbours(MapTile tile) {
			List<MapTile> neighbouringTiles = new List<MapTile>();
			int tileX = tile.x;
			int tileY = tile.y;


			//due to the hex coordinate system, the coordinates of neighbouring tiles depend on the row the tile is in (even or odd)

			if (tileY % 2 == 0) {
				neighbouringTiles.Add(getTileAt(tileX - 1, tileY - 1)); //lower left
				neighbouringTiles.Add(getTileAt(tileX, tileY - 1)); //lower right
				neighbouringTiles.Add(getTileAt(tileX - 1, tileY)); //left
				neighbouringTiles.Add(getTileAt(tileX + 1, tileY)); //right
				neighbouringTiles.Add(getTileAt(tileX - 1, tileY + 1)); //upper left
				neighbouringTiles.Add(getTileAt(tileX, tileY + 1)); //upper right
			}
			else {
				neighbouringTiles.Add(getTileAt(tileX, tileY - 1)); //lower left
				neighbouringTiles.Add(getTileAt(tileX + 1, tileY - 1)); //lower right
				neighbouringTiles.Add(getTileAt(tileX - 1, tileY)); //left
				neighbouringTiles.Add(getTileAt(tileX + 1, tileY)); //right
				neighbouringTiles.Add(getTileAt(tileX, tileY + 1)); //upper left
				neighbouringTiles.Add(getTileAt(tileX + 1, tileY + 1)); //upper right
			}

			neighbouringTiles.RemoveAll(item => item == null); //getTileAt returns null for invalid (out-of-bound) tiles, so remove these (this is typically at the map edge)

			return neighbouringTiles;

		}
	}
}
