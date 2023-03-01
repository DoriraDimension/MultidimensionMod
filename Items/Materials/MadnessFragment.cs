using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class MadnessFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 8);
			Item.rare = ItemRarityID.Green;
		}
	}
}