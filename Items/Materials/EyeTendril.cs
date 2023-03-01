using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class EyeTendril : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 15);
			Item.rare = ItemRarityID.White;
		}
	}
}
