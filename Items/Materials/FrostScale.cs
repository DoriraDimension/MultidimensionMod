using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class FrostScale : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Scale");
			Tooltip.SetDefault("The scale of a juvenile ice drake, its cold and soft.\nIce Drake nest underground until they become too big for the small ice caves.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 32);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{

		}
	}
}
