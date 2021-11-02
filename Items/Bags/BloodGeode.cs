using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class BloodGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Geode");
			Tooltip.SetDefault("A geode found in the Crimson.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Crimson minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Blut Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Purpur gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Purpur Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 20;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(4);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.CrimtaneOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.CrimstoneBlock, 50);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldStainedBone>());
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldStainedFleshStick>());
			}
		}
	}
}