using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged.Flamethrowers;
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

		public override void Load()
		{
			DimensiumEuronen = CustomCurrencyManager.RegisterCurrency(new MDCurrency(ModContent.ItemType<Dimensium>(), 999L));
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
				bossChecklist.Call(
					"AddBoss",
					5.5f,
					new List<int> { ModContent.NPCType<NPCs.Boss.Smiley.Smiley>() },
					this, // Mod
					"Smiley",
					(Func<bool>)(() => MDWorld.downedSmiley),
					ModContent.ItemType<Items.Summons.UnknownEmoji>(),
					new List<int> { ModContent.ItemType<Items.Vanity.SmileyMask>(), ModContent.ItemType<Items.Placeables.Trophies.SmileyTrophy>() },
					new List<int> { ModContent.ItemType<Items.Accessories.ShadowEmoji>(), ModContent.ItemType<Items.Materials.DarkMatterClump>(), ModContent.ItemType<Items.Weapons.Melee.Swords.LonelySword>(), ModContent.ItemType<Items.Weapons.Ranged.Guns.DarkMatterLauncher>(), ModContent.ItemType<Items.Weapons.Magic.Other.SmileySmile>(), ModContent.ItemType<Items.Weapons.Summon.DarkRebels>(), ModContent.ItemType<Items.Vanity.LonelyWarriorsVisor>(), ModContent.ItemType<Items.Vanity.DarkCloak>(), ModContent.ItemType<Items.Pets.CuteEmoji>(), ModContent.ItemType<Items.Souls.SmileySoulshard>() },
					"Use a Unknown Emoji at night",
					"Smiley vanishes into the darkness, seeking another strong being"
				);
			}
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
					ModContent.ItemType<Iris>()
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
					ModContent.ItemType<Spazmelter>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "Plantera", new List<int>
				{
					ModContent.ItemType<BlackRoseScarf>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "DukeFishron", new List<int>
				{
					ModContent.ItemType<TidalQuartz>(),
					ModContent.ItemType<TyphoonDragon>()
				});
				MultidimensionMod.AddLoot(bossChecklist, "Solar Eclipse", new List<int>
				{
					ModContent.ItemType<EclipseReaper>()
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

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<MDPlayer>().ZoneColdHell)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/FrozenUnderworld");
				priority = MusicPriority.BiomeHigh;
			}
		}
	}
}