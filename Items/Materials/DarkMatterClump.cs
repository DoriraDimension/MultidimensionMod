using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class DarkMatterClump : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Matter Clump");
			Tooltip.SetDefault("The essence of Darklings.\nDarklings are made of pure dark matter, they fled their home together with a new leader to escape their former master.");
		}

		public override void SetDefaults() 
		{
			Item.width = 20;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(copper: 50);
			Item.rare = ItemRarityID.Orange;
		}
	}
}
