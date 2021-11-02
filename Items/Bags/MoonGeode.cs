using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class MoonGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Geode");
			Tooltip.SetDefault("A geode found in the space layer after the lord of the moon fell.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Luminite.");
			DisplayName.AddTranslation(GameCulture.German, "Mond Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Weltraum gefunden wurde nachdem der Lord des Mondes gefallen war. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Luminit zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.rare = ItemRarityID.Red;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(1);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.LunarOre, 40);
			}
		}
	}
}