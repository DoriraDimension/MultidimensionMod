using MultidimensionMod.Dusts;
using MultidimensionMod.NPCs.MushBiomes;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using Terraria.DataStructures;
using MultidimensionMod.Items.Accessories;
using System.Collections.Generic;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.Enums;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushroomReed : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false; 
            Main.tileMergeDirt[Type] = false; 
            Main.tileBlockLight[Type] = false; 
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.OnlyInLiquid;
			TileObjectData.newTile.AnchorBottom = new Terraria.DataStructures.AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, 1, 0);
			TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<Mycelium>(), Type };
			TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Mycelium>(), Type };
			TileObjectData.addTile(Type);

            DustType = ModContent.DustType<MushroomDust>();
            HitSound = SoundID.Grass;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 10;
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			Tile tile = Framing.GetTileSafely(i, j -1);
			if (tile.HasTile && tile.TileType == Type) {
				WorldGen.KillTile(i, j - 1);
			}
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak) 
        {
            Tile tile = Framing.GetTileSafely(i, j); 
            Tile above = Framing.GetTileSafely(i, j-1);
            Tile below = Framing.GetTileSafely(i, j+1);

			//Check to see if it is a bud
            if(above.TileType!=Type&&below.HasTile&&below.TileType != Type)
            {
                tile.TileFrameX=(short)((i%2)*18);
            }

            //Check to see if it is an anchor
            if(above.TileType==Type&&below.HasTile&&below.TileType != Type)
            {
                tile.TileFrameX=(short)(((i%3)+2)*18);
            }
            //Check to see if it is a stem
            if(above.TileType==Type&&below.TileType == Type)
            {
                tile.TileFrameX=(short)(((i%5)+5)*18);
            }

            //check to see if it is a top

            if(above.TileType!=Type&&below.TileType == Type)
            {
                tile.TileFrameX=(short)(((i%3)+10)*18);
            }

			return false;
        }

        //PLEASE WORK
        public override void RandomUpdate(int i, int j)
		{
			Tile tile = Framing.GetTileSafely(i, j); 
            Tile above = Framing.GetTileSafely(i, j-1);
            Tile below = Framing.GetTileSafely(i, j+1);

			if (WorldGen.genRand.NextBool(15) && !below.HasTile && tile.LiquidType == LiquidID.Water) {
				WorldGen.PlaceTile(i, j - 1, Type, true, false);
			}
		}
    }
    public class MushroomAridReed : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false; 
            Main.tileMergeDirt[Type] = false; 
            Main.tileBlockLight[Type] = false; 
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.OnlyInLiquid;
			TileObjectData.newTile.AnchorBottom = new Terraria.DataStructures.AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, 1, 0);
			TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<MyceliumSandPlaced>(), Type };
			TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<MyceliumSandPlaced>(), Type };
			TileObjectData.addTile(Type);

            DustType = ModContent.DustType<MushroomDust>();
            HitSound = SoundID.Grass;
        }
    }
}