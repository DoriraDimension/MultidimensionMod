﻿using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Walls;
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
using static Terraria.WorldGen;

namespace MultidimensionMod.Worldgen
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

            ushort mycelium = (ushort)ModContent.TileType<Mycelium>(), sand = (ushort)ModContent.TileType<MyceliumSandPlaced>(),
                sandstone = (ushort)ModContent.TileType<MyceliumSandstonePlaced>(), hardenedSand = (ushort)ModContent.TileType<MyceliumHardsandPlaced>(), 
                sporeStone = (ushort)ModContent.TileType<SporeStonePlaced>(), sandstoneWall = (ushort)ModContent.WallType<MyceliumSandstoneWallPlaced>(), hardenedSandWall = (ushort)ModContent.WallType<MyceliumHardsandWallPlaced>();
            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 300 : worldSize == 2 ? 260 : 180;

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
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sand, TileID.Crimsand, TileID.Ebonsand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.HardenedSand, TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(hardenedSand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sandstone, TileID.CorruptSandstone,TileID. CrimsonSandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sandstone, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Stone, TileID.Crimstone, TileID.Ebonstone }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(sporeStone, true, true)
            }));
            //Walls
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.HardenedSand}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(hardenedSandWall, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.Sandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(sandstoneWall, true)
            }));
        }

        public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 1; //unknown size, assume small
        }
    }
}