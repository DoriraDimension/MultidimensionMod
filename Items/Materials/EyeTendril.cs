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
			Tooltip.SetDefault("A tendril from the big eye.");
			DisplayName.AddTranslation(GameCulture.German, "Augen Tentakel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Tentakel von dem großen Auge.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 15);
			item.rare = ItemRarityID.White;
		}
	}
}
