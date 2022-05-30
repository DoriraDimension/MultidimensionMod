using MultidimensionMod.Items.Materials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace MultidimensionMod
{
	public class MultidimensionMod : Mod
	{
		internal static MultidimensionMod Instance;

		internal bool vanillaLoaded = true;

		public static int DimensiumEuronen;

		public override void Load()
		{
			DimensiumEuronen = CustomCurrencyManager.RegisterCurrency(new MDCurrency(ModContent.ItemType<Dimensium>(), 999L, "Dimensium"));
		}

		public override void AddRecipeGroups()
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
	}
}