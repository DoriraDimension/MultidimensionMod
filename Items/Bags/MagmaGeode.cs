using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class MagmaGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Geode");
			Tooltip.SetDefault("A geode found in the underworld.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve underworld minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 24;
			Item.rare = ItemRarityID.Orange;
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
				player.QuickSpawnItem(source, ItemID.Hellstone, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.Obsidian, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ItemID.AshBlock, 50);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(source, ItemID.MagmaStone);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<OldMoltenBlade>());
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<OldMoltenGuard>());
			}
		}
	}
}