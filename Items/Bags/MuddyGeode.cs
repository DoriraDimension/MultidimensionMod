using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class MuddyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Muddy Geode");
			Tooltip.SetDefault("A geode found in the Jungle.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Jungle minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Schlammige Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Dschungel gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Dschungel Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.Lime;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(2);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.ChlorophyteOre, 30);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.MudBlock, 50);
			}
		}
	}
}