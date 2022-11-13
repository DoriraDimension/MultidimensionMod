using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class DarkMatterClump : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Void Matter");
			Tooltip.SetDefault("The essence of Darklings.");
		}

		public override void SetDefaults() 
		{
			Item.width = 34;
			Item.height = 26;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 50);
			Item.rare = ItemRarityID.Orange;
		}
	}
}
