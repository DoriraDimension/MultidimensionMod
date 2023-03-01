using MultidimensionMod.Items.Materials;
using MultidimensionMod.Biomes;
using MultidimensionMod.UI;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.UI;
using Terraria.Localization;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using MonoMod.Cil;


namespace MultidimensionMod
{
	public class MultidimensionMod : Mod
	{
		internal static MultidimensionMod Instance;

		internal bool vanillaLoaded = true;

		public static int DimensiumEuronen;

		public static float FUTransition { get; set; }

		public override void Load()
		{
			DimensiumEuronen = CustomCurrencyManager.RegisterCurrency(new MDCurrency(ModContent.ItemType<Dimensium>(), 999L, "Dimensium"));
			//IL.Terraria.Player.UpdateBiomes += NoHeap;
			//IL.Terraria.Liquid.Update += Evaporation;
		}

		public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´VilePowder", new int[]
			{
					ItemID.ViciousPowder,
					ItemID.VilePowder
			});
			RecipeGroup.RegisterGroup("EvilPowders", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´GoldBar", new int[]
			{
					ItemID.GoldBar,
					ItemID.PlatinumBar
			});
			RecipeGroup.RegisterGroup("GoldBars", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´IceBlock", new int[]
			{
					ItemID.IceBlock,
					ItemID.PurpleIceBlock,
					ItemID.RedIceBlock,
					ItemID.PinkIceBlock
			});
			RecipeGroup.RegisterGroup("IceBlocks", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´SandBlock", new int[]
			{
					ItemID.SandBlock,
					ItemID.EbonsandBlock,
					ItemID.CrimsandBlock,
					ItemID.PearlsandBlock
			});
			RecipeGroup.RegisterGroup("SandBlocks", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´CobaltBar", new int[]
			{
					ItemID.CobaltBar,
					ItemID.PalladiumBar
			});
			RecipeGroup.RegisterGroup("CobaltBars", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´ShadowScale", new int[]
			{
					ItemID.ShadowScale,
					ItemID.TissueSample
			});
			RecipeGroup.RegisterGroup("EvilSample", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " ´AdamantiteBar", new int[]
			{
					ItemID.AdamantiteBar,
					ItemID.TitaniumBar
			});
			RecipeGroup.RegisterGroup("AdamantiteBars", group);
		}

		//Heat Distortion and Evaporation IL's were made possible by The Depths mod <3 (Im dumb and cant make it work right now)
		//private void NoHeap(ILContext il)
		//{
		//	var c = new ILCursor(il);
		//	try
		//	{
		//		c.GotoNext(MoveType.After,
		//			i => i.MatchLdstr("HeatDistortion"),
		//			i => i.MatchLdsfld<Main>("UseHeatDistortion"));

		//		c.EmitDelegate((bool useHeatDistortion) => {
		//			if ()
		//			{
		//				return false;
		//			}
		//			return useHeatDistortion;
		//		});
		//	}
		//	catch (Exception e)
		//	{
		//		Logger.Error(e.Message);
		//	}
		//}

		//private void Evaporation(ILContext il)
		//{
		//	var c = new ILCursor(il);
		//	try
		//	{
		//		int b = 0;
		//		int tile = 0;
		//		c.GotoNext(MoveType.After,
		//			i => i.MatchLdloca(out tile),
		//			i => i.MatchCall<Tile>("get_liquid"),
		//			i => i.MatchDup(),
		//			i => i.MatchLdindU1(),
		//			i => i.MatchLdloc(out b),
		//			i => i.MatchSub(),
		//			i => i.MatchConvU1(),
		//			i => i.MatchStindI1());

		//		c.Index -= 3;
		//		c.Emit(OpCodes.Ldloca_S, (byte)tile);
		//		c.EmitDelegate((byte num, ref Tile liqTile) => {
		//			if ( && liqTile.LiquidType == LiquidID.Water)
		//			{
		//				return (byte)0;
		//			}
		//			return num;
		//		});
		//	}
		//	catch (Exception e)
		//	{
		//		Logger.Error(e.Message);
		//	}
		//}
	}

	public class MDSystem : ModSystem
	{
		public static MDSystem Instance { get; private set; }
		public MDSystem()
		{
			Instance = this;
		}
		public bool Initialized;

		public UserInterface TitleUILayer;
		public TitleCard TitleCardUIElement;

		public override void Load()
		{
			if (!Main.dedServ)
			{
				TitleUILayer = new UserInterface();
				TitleCardUIElement = new TitleCard();
				TitleUILayer.SetState(TitleCardUIElement);
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			layers.Insert(layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text")), new LegacyGameInterfaceLayer("GUI Menus",
				delegate
				{
					return true;
				}, InterfaceScaleType.UI));
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				AddInterfaceLayer(layers, TitleUILayer, TitleCardUIElement, MouseTextIndex + 3, TitleCard.Showing, "Title Card");
			}
		}

		public static void AddInterfaceLayer(List<GameInterfaceLayer> layers, UserInterface userInterface, UIState state, int index, bool visible, string customName = null) //Code created by Scalie
		{
			string name;
			if (customName == null)
			{
				name = state.ToString();
			}
			else
			{
				name = customName;
			}
			layers.Insert(index, new LegacyGameInterfaceLayer("MultidimensionMod: " + name,
				delegate
				{
					if (visible)
					{
						userInterface.Update(Main._drawInterfaceGameTime);
						state.Draw(Main.spriteBatch);
					}
					return true;
				}, InterfaceScaleType.UI));
		}
	}
}