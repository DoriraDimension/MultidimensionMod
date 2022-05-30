using System.Collections.Generic;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Staffs;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Potions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class SusPackage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Gift");
			Tooltip.SetDefault("A weird package that you found next to you, it contains some useful beginner items");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.Mod == "Terraria" && item.Name == "ItemName")
				{
					item.OverrideColor = MDRarity.Dorira;
				}
			}
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			player.QuickSpawnItem(source, ModContent.ItemType<WoodenBat>());
			player.QuickSpawnItem(source, ItemID.CopperBow);
			player.QuickSpawnItem(source, ItemID.WoodenArrow, 75);
			player.QuickSpawnItem(source, ModContent.ItemType<StarRod>());
			player.QuickSpawnItem(source, ItemID.ManaCrystal);
			player.QuickSpawnItem(source, ItemID.SlimeStaff);
			player.QuickSpawnItem(source, ItemID.CopperHammer);
			player.QuickSpawnItem(source, ItemID.Torch, 30);
			player.QuickSpawnItem(source, ItemID.RecallPotion, 5);
			player.QuickSpawnItem(source, ModContent.ItemType<CalamityRing>());
			switch (player.name)
			{
				case "Dorira":
				case "Marco":
				case "Dorito":
				case "Karl":
				case "Silverking":
					player.QuickSpawnItem(source, ModContent.ItemType<EleanoraBodypillowItem>());
					player.QuickSpawnItem(source, ModContent.ItemType<October1Item>());
					break;

				case "Eleanora":
				case "EleanoraKitti":
				case "Ellie":
				case "Sunclaw":
					player.QuickSpawnItem(source, ModContent.ItemType<EleanoraPlushie>());
					player.QuickSpawnItem(source, ModContent.ItemType<October1Item>());
					break;

				case "PhiaKitti":
				case "Dust":
					player.QuickSpawnItem(source, ItemID.Bass, 999);
					player.QuickSpawnItem(source, ItemID.Worm);
					break;

				case "Teiteira":
				case "Fat":
				case "YuukiSimp":
					player.QuickSpawnItem(source, ItemID.SugarCookie, 5);
					player.QuickSpawnItem(source, ItemID.Holly);
					player.QuickSpawnItem(source, ItemID.Ale);
					break;

				case "Rage":
				case "Josh":
					player.QuickSpawnItem(source, ModContent.ItemType<MegaDemondrug>(), 10);
					break;

				case "Cotton":
				case "Dynosaur":
				case "Crabbane":
					player.QuickSpawnItem(source, ModContent.ItemType<MegaDemondrug>(), 10);
					player.QuickSpawnItem(source, ItemID.PinkDye, 3);
					player.QuickSpawnItem(source, ItemID.PinkPaint, 999);
					break;

				case "Tim":
				case "Illuminatim":
					player.QuickSpawnItem(source, ModContent.ItemType<Rambam>());
					break;

				case "Clint":
					player.QuickSpawnItem(source, ItemID.IronHammer);
					player.QuickSpawnItem(source, ModContent.ItemType<Geode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<FrozenGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<SandstoneGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<BloodGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<DecayGeode>(), 3);
					break;
			}
		}
	}
}