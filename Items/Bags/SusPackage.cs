using System.Collections.Generic;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class SusPackage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Gift");
			Tooltip.SetDefault("A weird package that you found next to you, it contains some useful beginner items");
			DisplayName.AddTranslation(GameCulture.German, "Mysteriöses Geschenk");
			Tooltip.AddTranslation(GameCulture.German, "Ein seltsames Paket das du neben dir gefunden hast, es enthält ein paar nützliche Anfänger gegenstände.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 99;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Dorira;
				}
			}
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<WoodenBat>());
			player.QuickSpawnItem(ItemID.CopperBow);
			player.QuickSpawnItem(ItemID.WoodenArrow, 75);
			player.QuickSpawnItem(ItemID.WandofSparking);
			player.QuickSpawnItem(ItemID.ManaCrystal);
			player.QuickSpawnItem(ItemID.SlimeStaff);
			player.QuickSpawnItem(ItemID.CopperHammer);
			player.QuickSpawnItem(ItemID.Torch, 30);
			player.QuickSpawnItem(ItemID.RecallPotion, 5);
			player.QuickSpawnItem(ModContent.ItemType<CalamityRing>());
			player.QuickSpawnItem(ModContent.ItemType<Dimensium>(), 3);
			switch (player.name)
			{
				case "Dorira":
				case "Marco":
				case "Dorito":
				case "Karl":
				case "Silverking":
					player.QuickSpawnItem(ModContent.ItemType<DataMiner>());
					player.QuickSpawnItem(ModContent.ItemType<EleanoraBodypillow>());
					player.QuickSpawnItem(ModContent.ItemType<October1Item>());
					break;

				case "Eleanora":
				case "EleanoraKitti":
				case "Ellie":
				case "Sunclaw":
					player.QuickSpawnItem(ModContent.ItemType<EleanorasBat>());
					player.QuickSpawnItem(ModContent.ItemType<EleanoraPlushie>());
					player.QuickSpawnItem(ModContent.ItemType<October1Item>());
					break;

				case "PhiaKitti":
				case "Dust":
					player.QuickSpawnItem(ModContent.ItemType<FishCleaver>());
					player.QuickSpawnItem(ItemID.Bass, 999);
					player.QuickSpawnItem(ItemID.Worm);
					break;

				case "Teiteira":
				case "Fat":
				case "YuukiSimp":
					player.QuickSpawnItem(ItemID.SugarCookie, 5);
					player.QuickSpawnItem(ItemID.Holly);
					player.QuickSpawnItem(ItemID.Ale);
					break;

				case "Rage":
				case "Josh":
					player.QuickSpawnItem(ModContent.ItemType<BlackDragonBow>());
					player.QuickSpawnItem(ModContent.ItemType<MegaDemondrug>(), 10);
					player.QuickSpawnItem(ItemID.BreakerBlade);
					break;

				case "Cotton":
				case "Dynosaur":
				case "Crabbane":
					player.QuickSpawnItem(ModContent.ItemType<BlackDragonBow>());
					player.QuickSpawnItem(ModContent.ItemType<MegaDemondrug>(), 10);
					player.QuickSpawnItem(ItemID.PinkDye, 3);
					player.QuickSpawnItem(ItemID.PinkPaint, 999);
					break;

				case "Tim":
				case "Illuminatim":
					player.QuickSpawnItem(ModContent.ItemType<Rambam>());
					break;

				case "Clint":
					player.QuickSpawnItem(ItemID.IronHammer);
					player.QuickSpawnItem(ModContent.ItemType<Geode>(), 3);
					player.QuickSpawnItem(ModContent.ItemType<FrozenGeode>(), 3);
					player.QuickSpawnItem(ModContent.ItemType<SandstoneGeode>(), 3);
					player.QuickSpawnItem(ModContent.ItemType<BloodGeode>(), 3);
					player.QuickSpawnItem(ModContent.ItemType<DecayGeode>(), 3);
					break;
			}
		}
	}
}