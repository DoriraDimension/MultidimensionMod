using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
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

namespace MultidimensionMod.Biomes
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
		}

		private void FrozenUnderworldGen(GenerationProgress progress, GameConfiguration configuration)
        {
			progress.Message = "Freezing Hell";
			float PlaceBiomeX = (int)(Main.maxTilesX / 7f);

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
			vines = (ushort)ModContent.TileType<ColdAshVines>();

			int biomeRadius = 675;

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
            {
				WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
				{
				new InWorld(),
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new Actions.SetLiquid(0, 0)
				}));
			}
			WorldUtils.Gen(originCenter, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[]
{
				new InWorld(),
				new Modifiers.OnlyTiles(new ushort[]{ 374 }), //Lava Dropper
				new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
				new Actions.ClearTile()
            }));
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