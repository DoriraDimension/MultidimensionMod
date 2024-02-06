using MultidimensionMod.Tiles.Biomes.ShroomForest;
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using Terraria.GameContent.Generation;
using static tModPorter.ProgressUpdate;

namespace MultidimensionMod.Biomes
{
    class SFGen : ModSystem
    {
        //Gen code is made possible by Ancients Awakened
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int BiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (BiomesIndex != -1)
            {
                tasks.Insert(BiomesIndex + 1, new PassLegacy("Scarlet Mycelium Forest", ShroomForestGen));
            }
        }

        private void ShroomForestGen(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spreading scarlet mycelium";
            float PlaceBiomeX = (int)(Main.maxTilesX / 2.5f);

            int e = (int)GenVars.worldSurfaceLow + 30;
            while (Main.tile[(int)PlaceBiomeX, e] != null && !Main.tile[(int)PlaceBiomeX, e].HasTile)
            {
                e++;
            }
            for (int l = (int)PlaceBiomeX - 25; l < (int)PlaceBiomeX + 25; l++)
            {
                for (int m = e - 6; m < e + 90; m++)
                {
                    if (Main.tile[l, m] != null && Main.tile[l, m].HasTile)
                    {
                        int type = Main.tile[l, m].TileType;
                        if (type == TileID.Cloud || type == TileID.RainCloud || type == TileID.Sunplate)
                        {
                            e++;
                            if (!Main.tile[l, m].HasTile)
                            {
                                e++;
                            }
                        }
                    }
                }
            }
            float PlaceBiomeY = e;

            ushort mycelium = (ushort)ModContent.TileType<Mycelium>(), stonePurification = (ushort)TileID.Stone;

            int biomeRadius = 300;

            Point originCenter = new((int)PlaceBiomeX, (int)PlaceBiomeY);
            // TILE CONVERSIONS
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Grass, TileID.CrimsonGrass, TileID.CorruptGrass }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(mycelium, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
{
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Crimstone, TileID.Ebonstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(stonePurification, true, true)
}));
        }
    }
}