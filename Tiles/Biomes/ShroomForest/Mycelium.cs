using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class Mycelium : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.SpreadOverground[Type] = true;
            TileID.Sets.SpreadUnderground[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            DustType = ModContent.DustType<MushroomDust>();
			AddMapEntry(new Color(299, 35, 24));
		}

        public override void RandomUpdate(int i, int j)
        {
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Dirt, Type, false);
            if (Main.rand.NextBool(60))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Mushroom>(), mute: true, style: Main.rand.Next(5));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<Mushroom>(), Main.rand.Next(5), 0, -1, -1);
            }
            if (Main.rand.NextBool(5000))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<YoungMushroom>(), mute: true, style: Main.rand.Next(3));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<YoungMushroom>(), Main.rand.Next(5), 0, -1, -1);
            }
            if (Main.rand.NextBool(2500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<KingsCapPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<KingsCapPlaced>(), Main.rand.Next(5), 0, -1, -1);
            }
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Dirt, Type, false);
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = TileID.Dirt;
            }
        }

        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int random = -1, int direction = -1)
        {
            if (!TileObject.CanPlace(x, y, type, style, direction, out TileObject toBePlaced, false))
            {
                return false;
            }
            toBePlaced.random = random;
            if (TileObject.Place(toBePlaced) && !mute)
            {
                WorldGen.SquareTileFrame(x, y, true);
            }
            return false;
        }
    }
}