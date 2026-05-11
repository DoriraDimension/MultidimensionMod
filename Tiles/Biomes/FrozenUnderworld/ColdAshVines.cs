using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class ColdAshVines : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileCut[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileNoFail[Type] = true;
            TileID.Sets.IsVine[Type] = true;
            DustType = DustID.Smoke;
			HitSound = SoundID.Grass;
			AddMapEntry(new Color(60, 99, 181));
		}

		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (WorldGen.genRand.NextBool(2)&& Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].cordage)
			{
				Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2((float)(i * 16) + 8f, (float)(j * 16) + 8f), 2996);
			}
		}

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);
            int type = -1;
            if (tileAbove.HasTile && tileAbove.Slope != SlopeType.SlopeUpLeft && tileAbove.Slope != SlopeType.SlopeUpRight)
            {
                type = tileAbove.TileType;
            }

            if (type == ModContent.TileType<ColdAshGrass>() || type == Type)
            {
                return true;
            }

            WorldGen.KillTile(i, j);
            return true;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tileBelow = Framing.GetTileSafely(i, j + 1);
            if (WorldGen.genRand.NextBool(15) && !tileBelow.HasTile && tileBelow.LiquidType != LiquidID.Lava)
            {
                bool placeVine = false;
                int yTest = j;
                while (yTest > j - 10)
                {
                    Tile testTile = Framing.GetTileSafely(i, yTest);
                    if (testTile.Slope != SlopeType.Solid)
                    {
                        break;
                    }
                    else if (!testTile.HasTile || testTile.TileType != ModContent.TileType<ColdAshGrass>())
                    {
                        yTest--;
                        continue;
                    }
                    placeVine = true;
                    break;
                }
                if (placeVine)
                {
                    tileBelow.TileType = Type;
                    tileBelow.HasTile = true;
                    WorldGen.SquareTileFrame(i, j + 1, true);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, i, j + 1, 3, TileChangeType.None);
                    }
                }
            }
        }
    }
}