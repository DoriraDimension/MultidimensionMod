using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class MagmaGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Geode");
			Tooltip.SetDefault("A geode found in the underworld.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve underworld minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Magma Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche in der Unterwelt gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Unterwelt Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 24;
			item.rare = ItemRarityID.Orange;
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
				player.QuickSpawnItem(ItemID.Hellstone, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.Obsidian, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ItemID.AshBlock, 50);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ItemID.MagmaStone);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldMoltenBlade>());
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldMoltenGuard>());
			}
		}
	}
}