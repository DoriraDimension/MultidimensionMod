using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
//using MultidimensionMod.Items.Weapons.Meele.Boomerangs;
//using MultidimensionMod.Items.Weapons.Meele.Broadswords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod
{
	public class MultidimensionMod : Mod
	{
		internal static MultidimensionMod Instance;

		internal bool vanillaLoaded = true;

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

		public override void AddRecipes()
		{
			Recipes.AddAccessorieRecipes(this);
			Recipes.AddWeaponRecipes(this);
			Recipes.AddToolRecipes(this);
			Recipes.AddTileRecipes(this);
			Recipes.AddConsumablesRecipes(this);
			Recipes.AddMaterialRecipes(this);
			Recipes.AddAnkhCharmMatsRecipes(this);
			Recipes.AddCellPhoneMatsRecipes(this);
			Recipes.AddTransmutationRecipes(this);
		}

		private static void AddLoot(Mod bossChecklist, string bossName, List<int> loot = null, List<int> collection = null)
		{
			MultidimensionMod.AddLoot(bossChecklist, "Terraria", bossName, loot, collection);
		}

		private static void AddLoot(Mod bossChecklist, string mod, string bossName, List<int> loot = null, List<int> collection = null)
		{
			if (loot != null)
			{
				bossChecklist.Call("AddToBossLoot", mod, bossName, loot);
			}
			if (collection != null)
			{
				bossChecklist.Call("AddToBossCollection", mod, bossName, collection);
			}
		}

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				MultidimensionMod.AddLoot(bossChecklist, "KingSlime", new List<int>
				{
					ModContent.ItemType<RoyalBelt>(),
				});
				MultidimensionMod.AddLoot(bossChecklist, "EyeofCthulhu", new List<int>
				{
					ModContent.ItemType<EyeTendril>(),
					ModContent.ItemType<EyeoftheNightwalker>(),
					//ModContent.ItemType<Iris>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "SkeletronHead", new List<int>
				{
					ItemID.BoneKey,
					ItemID.Bone
				});
				MultidimensionMod.AddLoot(bossChecklist, "WallofFlesh", new List<int>
				{
					ItemID.FleshBlock
				});
				MultidimensionMod.AddLoot(bossChecklist, "TheTwins", new List<int>
				{
					ModContent.ItemType<Retilazor>(),
					//ModContent.ItemType<Spazmelter>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "Plantera", new List<int>
				{
					ModContent.ItemType<BlackRoseScarf>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "DukeFishron", new List<int>
				{
					ModContent.ItemType<TidalQuartz>(),
					//ModContent.ItemType<TyphoonDragon>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "Solar Eclipse", new List<int>
				{
					//ModContent.ItemType<EclipseReaper>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "Frost Moon", new List<int>
				{
					ItemID.BluePresent,
					ItemID.YellowPresent,
					ItemID.GreenPresent
				});
				MultidimensionMod.AddLoot(bossChecklist, "SantaNK1", new List<int>
				{
					ItemID.BluePresent,
					ItemID.YellowPresent,
					ItemID.GreenPresent
				});
				MultidimensionMod.AddLoot(bossChecklist, "Pumpkin Moon", new List<int>
				{
					ItemID.GoodieBag,
				});
				MultidimensionMod.AddLoot(bossChecklist, "Pumpking", new List<int>
				{
					ItemID.GoodieBag,
				});
				MultidimensionMod.AddLoot(bossChecklist, "Martian Madness", new List<int>
				{
					ItemID.CompanionCube,
				});
				MultidimensionMod.AddLoot(bossChecklist, "MartianSaucer", new List<int>
				{
					ItemID.CompanionCube,
				});
			}
		}
	}
}