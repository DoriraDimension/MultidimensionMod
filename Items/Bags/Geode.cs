using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class Geode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ore Geode");
			Tooltip.SetDefault("A geode found in the caverns.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve cavern minerals");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 24;
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
			int choice = Main.rand.Next(8);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.SilverOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.TungstenOre, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ItemID.GoldOre, 20);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(source, ItemID.PlatinumOre, 20);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(source, ItemID.IronOre, 20);
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(source, ItemID.LeadOre, 20);
			}
			else if (choice == 6)
			{
				player.QuickSpawnItem(source, ItemID.CopperOre, 20);
			}
			else if (choice == 7)
			{
			    player.QuickSpawnItem(source, ItemID.TinOre, 20);
			}
		}
	}
}