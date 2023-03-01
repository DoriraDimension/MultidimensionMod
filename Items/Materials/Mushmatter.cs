using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Mushmatter : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 8);
			Item.rare = ItemRarityID.Blue;
		}
	}
}
