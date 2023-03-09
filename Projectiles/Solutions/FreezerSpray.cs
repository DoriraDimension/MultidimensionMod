using MultidimensionMod.Dusts;
using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Solutions
{
	public class FreezerSpray : Solution
	{
		public override int DustType => ModContent.DustType<FreezerDust>();

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

					if (tileType == TileID.Ash)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<ColdAsh>());
					}
					else if (tileType == TileID.Hellstone)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<AbyssalHellstonePlaced>());
					}
					else if (tileType == TileID.Obsidian)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<GlazedObsidianPlaced>());
					}
					else if (tileType == TileID.ObsidianBrick)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<GlazedObsidianBrickPlaced>());
					}
					else if (tileType == TileID.HellstoneBrick)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<AbyssalHellstoneBrickPlaced>());
					}
					else if (tileType == TileID.AshGrass)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<ColdAshGrass>());
					}
					else if (tileType == TileID.AshVines)
					{
						ConvertTile(k, l, (ushort)ModContent.TileType<ColdAshVines>());
					}

					int wallType = Main.tile[k, l].WallType;
				}
			}
		}
	}
}