using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class CheliaPlushiePlaceable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shapeshifter Plushie");
			Tooltip.SetDefault("A cuddly plushie that looks like a unknown friend of the Dimensional God.\nWhy is he selling these?");
			DisplayName.AddTranslation(GameCulture.German, "Gestaltwandlerin Plüschtier");
			Tooltip.AddTranslation(GameCulture.German, "Ein kuschliges Plüschtier das wie ein unbekannter Freund des dimensionalen Gottess aussieht.\nWarum verkauft er die?");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 54;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(gold: 1);
			item.createTile = ModContent.TileType<Tiles.CheliaPlushiePlaced>();
		}
	}
}