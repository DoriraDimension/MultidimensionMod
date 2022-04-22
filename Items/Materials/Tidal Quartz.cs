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
			Tooltip.SetDefault("A gem found inside of oceanic creatures.\nThe unique minerals and bacteria inside the Terrarian oceans have a interesting effect on some animals,\nas they form a light blue quartz like gem inside their bodies.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(silver: 18);
			Item.rare = ItemRarityID.Yellow;
		}
	}
}
