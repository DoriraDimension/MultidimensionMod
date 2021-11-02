using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class SandstoneGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Geode");
			Tooltip.SetDefault("A geode found in the desert.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve desert minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Sandstein Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche in der Wüste gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Wüsten Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(6);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.Amber, 5);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.Sandstone, 50);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ItemID.HardenedSand, 50);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ItemID.DesertFossil, 15);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldDustyBowMiddlePiece>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldDustyBowArm>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.AncientBattleArmorMaterial);
					}
				}
			}
		}
	}
}