using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class DarkMatterClump : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The essence of Darklings.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Materie Klumpen");
			Tooltip.AddTranslation(GameCulture.German, "Die Essenz von Dunkellingen.");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 18;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 50);
			item.rare = ItemRarityID.Orange;
		}
	}
}
