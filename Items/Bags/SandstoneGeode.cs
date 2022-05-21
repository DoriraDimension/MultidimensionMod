using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class SandstoneGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Geode");
			Tooltip.SetDefault("A geode found in the desert.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve desert minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			int choice = Main.rand.Next(6);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.Amber, 5);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.Sandstone, 50);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ItemID.HardenedSand, 50);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(source, ItemID.DesertFossil, 15);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.AncientBattleArmorMaterial);
					}
				}
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<OldDustyBow>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.AncientBattleArmorMaterial);
					}
				}
			}
		}
	}
}