using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class Geode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode");
			Tooltip.SetDefault("A geode found in the caverns.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve cavern minerals");
			DisplayName.AddTranslation(GameCulture.German, "Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Untergrund gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Untergrund Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(14);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.SilverOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.TungstenOre, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ItemID.GoldOre, 20);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ItemID.PlatinumOre, 20);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(ItemID.IronOre, 20);
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(ItemID.LeadOre, 20);
			}
			else if (choice == 6)
			{
				player.QuickSpawnItem(ItemID.CopperOre, 20);
			}
			else if (choice == 7)
			{
			    player.QuickSpawnItem(ItemID.TinOre, 20);
			}
			else if (choice == 8)
			{
				player.QuickSpawnItem(ItemID.Amethyst, 5);
			}
			else if (choice == 9)
			{
				player.QuickSpawnItem(ItemID.Sapphire, 5);
			}
			else if (choice == 10)
			{
				player.QuickSpawnItem(ItemID.Topaz, 5);
			}
			else if (choice == 11)
			{
				player.QuickSpawnItem(ItemID.Diamond, 5);
			}
			else if (choice == 12)
			{
				player.QuickSpawnItem(ItemID.Emerald, 5);
			}
			else if (choice == 13)
			{
				player.QuickSpawnItem(ItemID.Ruby, 5);
			}
		}
	}
}