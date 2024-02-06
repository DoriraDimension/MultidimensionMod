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
                    else if (tileType == TileID.MushroomBlock)
                    {
                        ConvertTile(k, l, (ushort)ModContent.TileType<MushroomBlockPlaced>());
                    }

                    int wallType = Main.tile[k, l].WallType;
                    if (wallType == WallID.Mushroom)
                    {
                        ConvertWall(k, l, (ushort)ModContent.WallType<MushroomBlockWallPlaced>());
                    }
                }
            }
        }
    }
}