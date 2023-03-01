using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class VikingRelic : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 46);
			Item.rare = ItemRarityID.Green;
		}
	}
}
