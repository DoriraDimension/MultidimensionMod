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
			DisplayName.SetDefault("Eye Tendril");
			Tooltip.SetDefault("A tendril from the big eye.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(copper: 15);
			Item.rare = ItemRarityID.White;
		}
	}
}
