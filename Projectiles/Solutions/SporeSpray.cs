using MultidimensionMod.Dusts;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Walls;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Solutions
{
    public class SporeSpray : Solution
    {
        public override int DustType => ModContent.DustType<MushroomDust>();

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

                    if (tileType == TileID.Grass)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<Mycelium>());
                    }
                    else if (tileType == TileID.Sand || tileType == TileID.Ebonsand || tileType == TileID.Crimsand || tileType == TileID.Pearlsand)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<MyceliumSandPlaced>());
                    }
                    else if (tileType == TileID.HardenedSand || tileType == TileID.CorruptHardenedSand || tileType == TileID.CrimsonHardenedSand || tileType == TileID.HallowHardenedSand)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<MyceliumHardsandPlaced>());
                    }
                    else if (tileType == TileID.Sandstone || tileType == TileID.CorruptSandstone || tileType == TileID.CrimsonSandstone || tileType == TileID.HallowSandstone)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<MyceliumSandstonePlaced>());
                    }
                    else if (tileType == TileID.Stone || tileType == TileID.Ebonstone || tileType == TileID.Crimstone || tileType == TileID.Pearlstone)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<SporeStonePlaced>());
                    }
                    else if (tileType == TileID.MushroomBlock)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<MushroomBlockPlaced>());
                    }

                    int wallType = Main.tile[k, l].WallType;
                    if (wallType == WallID.HardenedSand || tileType == WallID.CorruptHardenedSand || tileType == WallID.CrimsonHardenedSand || tileType == WallID.HallowHardenedSand)
                    {
                        ConvertWall(k, l, (ushort)ModContent.WallType<MyceliumHardsandWallPlaced>());
                    }
                    if (wallType == WallID.Sandstone || tileType == WallID.CorruptSandstone || tileType == WallID.CrimsonSandstone || tileType == WallID.HallowSandstone)
                    {
                        ConvertWall(k, l, (ushort)ModContent.WallType<MyceliumSandstoneWallPlaced>());
                    }
                    else if (wallType == WallID.Mushroom)
                    {
                        ConvertWall(k, l, (ushort)ModContent.WallType<MushroomBlockWallPlaced>());
                    }
                }
            }
        }
    }
}