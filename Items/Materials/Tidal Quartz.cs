using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class TidalQuartz : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tidal Quartz");
			Tooltip.SetDefault("A gem found inside of oceanic creatures.");
			DisplayName.AddTranslation(GameCulture.German, "Gezeiten Quartz");
			Tooltip.AddTranslation(GameCulture.German, "Ein seltener Edelstein welcher in ozeanischen Kreaturen gefunden wird.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 18);
			item.rare = ItemRarityID.Yellow;
		}
	}
}
