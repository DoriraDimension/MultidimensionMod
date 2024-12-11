using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
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
using static tModPorter.ProgressUpdate;

namespace MultidimensionMod.Worldgen
{
    class FUGen : ModSystem
    {
		//Gen code is made possible by Ancients Awakened
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{
			int BiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
			if (BiomesIndex != -1)
			{
				tasks.Insert(BiomesIndex + 1, new PassLegacy("Frozen Underworld", FrozenUnderworldGen));
			}
            if (BiomesIndex != -1)
            {
                tasks.Insert(BiomesIndex + 1, new PassLegacy("Frozen Underworld lava removal", RemoveLavaOnlyInHell));
            }
        }

		private void FrozenUnderworldGen(GenerationProgress progress, GameConfiguration configuration)
        {
            int worldSize = GetWorldSize();
            float biomePlacement = worldSize == 3 ? 12.5f : worldSize == 2 ? 8.5f : 8.5f;
            progress.Message = "Freezing Hell";
			float PlaceBiomeX = (int)(Main.maxTilesX / biomePlacement);

			int e = Main.UnderworldLayer;
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

			ushort ash = (ushort)ModContent.TileType<ColdAsh>(), hellstone = (ushort)ModContent.TileType<AbyssalHellstonePlaced>(), hellstoneBrick = (ushort)ModContent.TileType<AbyssalHellstoneBrickPlaced>(),
            obsidianBrick = (ushort)ModContent.TileType<GlazedObsidianBrickPlaced>(), lava = (ushort)ModContent.TileType<SolidMagmaPlaced>(), grass = (ushort)ModContent.TileType<ColdAshGrass>(), 
			vines = (ushort)ModContent.TileType<ColdAshVines>(), hellstoneBrickWalls = (ushort)ModContent.WallType<AbyssalHellstoneBrickWallPlaced>();
            int biomeRadius = worldSize == 3 ? 1000 : worldSize == 2 ? 800 : 600;

            Point originCenter = new((int)PlaceBiomeX, (int)PlaceBiomeY);
			// TILE CONVERSIONS
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
			{
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ TileID.Ash }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new SetModTile(ash, true, true)
			}));
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
			{
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ TileID.Hellstone }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new SetModTile(hellstone, true, true)
			}));
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
			{
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[] { TileID.HellstoneBrick }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new SetModTile(hellstoneBrick, true, true)
			}));
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ TileID.ObsidianBrick }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
 				new SetModTile(obsidianBrick, true, true)
            }));
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ TileID.AshVines }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
 				new SetModTile(vines, true, true)
            }));
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ TileID.AshGrass }),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
 				new SetModTile(grass, true, true)
            }));
            if (Main.maxTilesY <= 100)
            {
                WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
                {
                    new InWorld(),
                    new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                    new Actions.SetLiquid(0, 0),
                    new SetModTile(lava, true, true)
                }));
            }
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ 374 }), //Lava Dropper
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new Actions.ClearTile()
            }));
            //Walls
            WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
            {
                new InWorld(),
                new Modifiers.OnlyWalls(new ushort[]{ WallID.HellstoneBrick}),
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new PlaceModWall(hellstoneBrickWalls, true)
            }));

            /*int radiusLeft = (int)(Center.X / 16f - radius);
            int radiusRight = (int)(Center.X / 16f + radius);
            int radiusUp = (int)(Center.Y / 16f - radius);
            int radiusDown = (int)(Center.Y / 16f + radius);
            if (radiusLeft < 15) { radiusLeft = 15; }
            if (radiusRight > Main.maxTilesX - 15) { radiusRight = Main.maxTilesX - 15; }
            if (radiusUp < 15) { radiusUp = 15; }
            if (radiusDown > Main.maxTilesY - 15) { radiusDown = Main.maxTilesY - 15; }

            float distRad = radius * 16f;
            for (int x1 = radiusLeft; x1 <= radiusRight; x1++)
            {
                for (int y1 = radiusUp; y1 <= radiusDown; y1++)
                {
                    double dist = Vector2.Distance(new Vector2(x1 * 16f + 8f, y1 * 16f + 8f), Center);
                    if (!WorldGen.InWorld(x1, y1, 0)) continue;
                    if (dist < distRad && Framing.GetTileSafely(x1, y1) != null)
                    {
                        Framing.GetTileSafely(i, j).LiquidAmount = 0;
                        Framing.GetTileSafely(i, j).ClearTile();
                        WorldGen.PlaceTile(i, j, TileIDthing);
                    }
                }
            }*/
        }

		private void RemoveLavaOnlyInHell(GenerationProgress progress, GameConfiguration configuration)
		{
            int worldSize = GetWorldSize();
            float biomePlacement = worldSize == 3 ? 14.5f : worldSize == 2 ? 9f : 8.5f;
            progress.Message = "Getting rid of lava";
            float PlaceBiomeX = (int)(Main.maxTilesX / biomePlacement);

            int e = Main.UnderworldLayer;
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

            ushort lava = (ushort)ModContent.TileType<SolidMagmaPlaced>();

            int lavaWidth = worldSize == 3 ? 2000 : worldSize == 2 ? 1600 : 1250;
            int lavaHeight = 300;
			int petrifiedH = 100;
			int petrifiedW = 1300;

            Point originCenter = new((int)PlaceBiomeX - 675, (int)PlaceBiomeY);
			Point originCenter2 = new((int)PlaceBiomeX, (int)PlaceBiomeY + 100);
            // TILE CONVERSIONS
            WorldUtils.Gen(originCenter, new Shapes.Rectangle(lavaWidth, lavaHeight), Actions.Chain(new GenAction[]
            {
            new InWorld(),
			new Modifiers.HasLiquid(liquidType:1),
            new Actions.SetLiquid(0, 0),
			new SetModTile(lava, true, true)
            }));
           /* WorldUtils.Gen(originCenter2, new Shapes.Rectangle(petrifiedH, petrifiedW), Actions.Chain(new GenAction[]
            {
            new InWorld(),
            new SetModTile(lava, true, true)
            }));*/
        }

        public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 1; //unknown size, assume small
        }
    }
	public class GenUtils
	{
		public static void ObjectPlace(Point Origin, int x, int y, int TileType, int style = 0, int direction = -1)
		{
			WorldGen.PlaceObject(Origin.X + x, Origin.Y + y, TileType, true, style, 0, -1, direction);
			NetMessage.SendObjectPlacement(-1, Origin.X + x, Origin.Y + y, TileType, style, 0, -1, direction);
		}
		public static void ObjectPlace(int x, int y, int TileType, int style = 0, int direction = -1)
		{
			WorldGen.PlaceObject(x, y, TileType, true, style, 0, -1, direction);
			NetMessage.SendObjectPlacement(-1, x, y, TileType, style, 0, -1, direction);
		}
		public static void InvokeOnMainThread(Action action)
		{
			if (!AssetRepository.IsMainThread)
			{
				ManualResetEvent evt = new(false);

				Main.QueueMainThreadAction(() =>
				{
					action();
					evt.Set();
				});

				evt.WaitOne();
			}
			else
				action();
		}
	}

	public class InWorld : GenAction
	{
		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			if (x < 0 || x > Main.maxTilesX || y < 0 || y > Main.maxTilesY)
				return Fail();
			return UnitApply(origin, x, y, args);
		}
	}
}