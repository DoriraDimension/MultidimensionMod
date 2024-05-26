using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

using MultidimensionMod.Walls;
using Terraria.Utilities;
using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using MultidimensionMod.Tiles.Ores;
using Terraria.IO;
using ReLogic.Content;
using Terraria.GameContent.Generation;
using MultidimensionMod.Tiles.Furniture.Razewood;

namespace MultidimensionMod.Worldgen
{
    public class DragonBiome : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int BiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (BiomesIndex != -1)
            {
                tasks.Insert(BiomesIndex + 1, new PassLegacy("The Dragon's Hoard", DragonHoardGen));
            }
        }
        float ChaosPositioningMultiplier = 1f;
        int ChaosPositioningPlacement = 1;
        public void DragonHoardGen(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Causing a volcano to sneeze";

            int e = (int)GenVars.worldSurfaceLow + 30;
            ChaosPositioningPlacement = Main.dungeonX < Main.maxTilesX / 2 ? 0 : 1;
            ChaosPositioningMultiplier = ChaosPositioningPlacement == 0 ? 2f : 4f;
            float PlaceBiomeX = (int)(Main.maxTilesX / 7f * ChaosPositioningMultiplier);
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
                        if (type == TileID.Cloud || type == TileID.RainCloud || type == TileID.Sunplate) //type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick
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
            float PlaceBiomeY = e - 50;

            Mod mod = ModContent.GetInstance<MultidimensionMod>();
            //--- Initial variable creation
            ushort Grass = (ushort)ModContent.TileType<InfernoGrass>(), Stone = (ushort)ModContent.TileType<TorchstonePlaced>(), Sand = (ushort)ModContent.TileType<TorchsandPlaced>(),
            Sandstone = (ushort)ModContent.TileType<TorchsandstonePlaced>(), HardenedSand = (ushort)ModContent.TileType<TorchsandHardenedPlaced>(), Ash = (ushort)ModContent.TileType<TorchAshPlaced>(), LivingWood = (ushort)ModContent.TileType<LivingRazewood>(),
            LivingLeaves = (ushort)ModContent.TileType<LivingRazeleaves>(), StoneWall = (ushort)ModContent.WallType<TorchstoneWallPlaced>(), SandstoneWall = (ushort)ModContent.WallType<TorchsandstoneWallPlaced>(), HardenedSandWall = (ushort)ModContent.WallType<TorchsandHardenedWallPlaced>(), GrassWall = (ushort)ModContent.WallType<InfernoGrassWall>();

            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 440 : worldSize == 2 ? 380 : 180;

            Point originCenter = new((int)PlaceBiomeX, (int)PlaceBiomeY);
            // TILE CONVERSIONS
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Grass, TileID.CrimsonGrass, TileID.CorruptGrass }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(Grass, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Stone, TileID.Crimstone, TileID.Ebonstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(Stone, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sand, TileID.Ebonsand, TileID.Crimsand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(Sand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.HardenedSand, TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(HardenedSand, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.Sandstone, TileID.CorruptSandstone,TileID. CrimsonSandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(Sandstone, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.SnowBlock, TileID.IceBlock}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(Ash, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.LivingWood }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(LivingWood, true, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyTiles(new ushort[]{ TileID.LeafBlock }),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new SetModTile(LivingLeaves, true, true)
            }));
            //Walls
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.HardenedSand, WallID.CorruptHardenedSand, WallID.CrimsonHardenedSand}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(HardenedSandWall, true)
            }));
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.Sandstone, WallID.CorruptSandstone, WallID.CrimsonSandstone}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(SandstoneWall, true)
            }));

            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>
            {
                //Volcano
                [new Color(255, 0, 0)] = ModContent.TileType<VolcanicRockPlaced>(), //Main material
                [new Color(88, 12, 39)] = ModContent.TileType<VolcanicRockDensePlaced>(), //Hardmode obstacle
                [new Color(144, 4, 97)] = ModContent.TileType<AwakenedRockPlaced>(), //Akuma room block
                [new Color(97, 20, 75)] = ModContent.TileType<VolcanicRockDensePlaced>(), //Broodmother and Ashe nests. Later replaced with the Nest Block
                [new Color(223, 170, 10)] = ModContent.TileType<IncineriteOre>(), // Ore scattered around
                //Pagoda
                [new Color(1, 0, 101)] = ModContent.TileType<PagodaBrickPlaced>(), //Pagoda tiles. Later replaced with a new block
                [new Color(0, 255, 0)] = ModContent.TileType<PagodaBrickPlaced>(), //Pagoda Floor. Later replaced with a new block
                [new Color(249, 249, 143)] = ModContent.TileType<PagodaFloorPlaced>(), //Pagoda floor tiles //Later replaced with a new block
                [new Color(0, 255, 187)] = ModContent.TileType<PagodaColumnPlaced>(), //Pagoda columns //Later replaced with a new block
                [new Color(45, 40, 40)] = ModContent.TileType<TorchAshPlaced>(), //Ash
                [new Color(133, 71, 49)] = ModContent.TileType<RazewoodPlaced>(), //Pagoda Bridge and support beams
                [new Color(255, 255, 0)] = ModContent.TileType<GildedTiles>(), //Pagoda roof. Later replaced with Gilded Tiles
                [new Color(150, 150, 150)] = -2, //turn into air
                [Color.Black] = -1 //don't touch when genning
            };

            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>
            {
                //Volcano
                [new Color(255, 0, 0)] = ModContent.WallType<VolcanicRockWallPlaced>(), //Main material
                [new Color(144, 4, 97)] = ModContent.WallType<AwakenedRockWallPlaced>(), //Akuma room
                [new Color(88, 12, 39)] = WallID.ObsidianBrick, //Akuma claw marks //Later replaced I guess
                [new Color(223, 170, 10)] = WallID.Lavafall, //Self explanatory
                //Pagoda
                [new Color(1, 0, 101)] = ModContent.WallType<PagodaBrickWallPlaced>(),
                [new Color(133, 71, 49)] = ModContent.WallType<RazewoodWallPlaced>(),
                [new Color(150, 150, 150)] = WallID.Glass, //glass
                [Color.Black] = -1 //don't touch when genning				
            };

            Texture2D clearTex = ModContent.Request<Texture2D>("MultidimensionMod/Worldgen/VolcanoClear", AssetRequestMode.ImmediateLoad).Value;
            Texture2D volcanoTex = ModContent.Request<Texture2D>("MultidimensionMod/Worldgen/Volcano", AssetRequestMode.ImmediateLoad).Value;
            Texture2D wallTex = ModContent.Request<Texture2D>("MultidimensionMod/Worldgen/VolcanoWalls", AssetRequestMode.ImmediateLoad).Value;
            Texture2D lavaTex = ModContent.Request<Texture2D>("MultidimensionMod/Worldgen/VolcanoLiquid", AssetRequestMode.ImmediateLoad).Value;
            Vector2 newOrigin = new Vector2(originCenter.X - 327, originCenter.Y - 30);
            WorldUtils.Gen(newOrigin.ToPoint(), new Shapes.Rectangle(654, 760), Actions.Chain(new GenAction[]
            {
                new Actions.SetLiquid(0, 0)
            }));
            GenUtils.InvokeOnMainThread(() =>
            {
                TexGen genDie = BaseWorldGenTex.GetTexGenerator(clearTex, colorToTile);
                Point newOrigine = new Point(originCenter.X, originCenter.Y - 30);
                int genXD = originCenter.X - (genDie.width / 2);
                int genYD = originCenter.Y - 80;
                genDie.Generate(genXD, genYD, true, true);

                TexGen gen = BaseWorldGenTex.GetTexGenerator(volcanoTex, colorToTile, wallTex, colorToWall, lavaTex);
                Point newOrigin = new Point(originCenter.X, originCenter.Y - 30); //biomeRadius);
                int genX = originCenter.X - (gen.width / 2);
                int genY = originCenter.Y - 80;
                gen.Generate(genX, genY, true, true);
            });
            Vector2 losOriginos = new(originCenter.X - (654 / 2), originCenter.Y - 80);
            Point volcanoPoint = losOriginos.ToPoint();
            //WorldGen.PlaceObject(originCenter.X - 91, originCenter.Y + 18, ModContent.TileType<OrnateBand>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 44, originCenter.Y - 308, ModContent.TileType<PagodaBell>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 28, originCenter.Y - 403, ModContent.TileType<SamuraiCorpse>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 51, originCenter.Y - 378, ModContent.TileType<RazewoodTablePlaced>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 51, originCenter.Y - 380, ModContent.TileType<AkumaText>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X - 207, originCenter.Y - 34, ModContent.TileType<PyrospherePlaced>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 284, originCenter.Y + 32, ModContent.TileType<DragonsGuardPlaced>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 50, originCenter.Y + 185, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 46, originCenter.Y + 185, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 41, originCenter.Y + 185, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 33, originCenter.Y + 185, ModContent.TileType<DragonEgg>(), mute: true);

            //WorldGen.PlaceObject(originCenter.X - 91, originCenter.Y + 18, ModContent.TileType<OrnateBand>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 44, originCenter.Y + 308, ModContent.TileType<PagodaBell>(), mute: true);
            //WorldGen.PlaceTile(volcanoPoint.X + 28, volcanoPoint.Y - 323, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 28, originCenter.Y - 323, ModContent.TileType<SamuraiCorpse>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 51, volcanoPoint.Y - 298, ModContent.TileType<RazewoodTablePlaced>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 51, volcanoPoint.Y - 300, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 51, originCenter.Y - 300, ModContent.TileType<AkumaText>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X - 207, volcanoPoint.Y + 46, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X - 207, originCenter.Y + 46, ModContent.TileType<PyrospherePlaced>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 284, volcanoPoint.Y + 112, ModContent.TileType<DragonEgg>(), mute: true);
            //WorldGen.PlaceObject(originCenter.X + 284, originCenter.Y + 112, ModContent.TileType<DragonsGuardPlaced>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 50, volcanoPoint.Y + 265, ModContent.TileType<DragonEgg>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 46, volcanoPoint.Y + 265, ModContent.TileType<DragonEgg>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 41, volcanoPoint.Y + 265, ModContent.TileType<DragonEgg>(), mute: true);
            WorldGen.PlaceObject(volcanoPoint.X + 33, volcanoPoint.Y + 265, ModContent.TileType<DragonEgg>(), mute: true);
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