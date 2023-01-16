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
			Tooltip.SetDefault("The physical incarnation of the nothingness outside our plain of existence. There are strange crystals stuck inside the mass.");
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
