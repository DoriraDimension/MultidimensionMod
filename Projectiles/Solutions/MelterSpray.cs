using MultidimensionMod.Dusts;
using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Solutions
{
	public class MelterSpray : Solution
	{
		public override int DustType => ModContent.DustType<MelterDust>();

		public override void Convert(int i, int j, int size = 4)
		{
			for (int k = i - size; k <= i + size; k++)
			{
				for (int l = j - size; l <= j + size; l++)
				{
					if (!WorldGen.InWorld(k, l, 1) || !(Math.Abs(l - j) < Math.Sqrt(size * size + size * size)))
					{
						continue;
					}

					int tileType = Main.tile[k, l].TileType;

					if (tileType == ModContent.TileType<ColdAsh>())
					{
						ConvertTile(k, l, (ushort)TileID.Ash);
					}
					else if (tileType == ModContent.TileType<AbyssalHellstonePlaced>())
					{
						ConvertTile(k, l, (ushort)TileID.Hellstone);
					}
					else if (tileType == ModContent.TileType<GlazedObsidianPlaced>())
					{
						ConvertTile(k, l, (ushort)TileID.Obsidian);
					}
					else if (tileType == ModContent.TileType<GlazedObsidianBrickPlaced>())
					{
						ConvertTile(k, l, (ushort)TileID.ObsidianBrick);
					}
					else if (tileType == ModContent.TileType<AbyssalHellstoneBrickPlaced>())
					{
						ConvertTile(k, l, (ushort)TileID.HellstoneBrick);
					}
					else if (tileType == ModContent.TileType<ColdAshGrass>())
					{
						ConvertTile(k, l, (ushort)TileID.AshGrass);
					}
					else if (tileType == ModContent.TileType<ColdAshVines>())
					{
						ConvertTile(k, l, (ushort)TileID.AshVines);
					}

                    int wallType = Main.tile[k, l].WallType;
					//no walls yet :(
				}
			}
		}
	}
}