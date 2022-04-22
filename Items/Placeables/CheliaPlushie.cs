using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class CheliaPlushie : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shapeshifter Plushie (placeable)");
			Tooltip.SetDefault("A cuddly plushie that looks like a unknown friend of the Dimensional God.\nWhy is he selling these?");
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 54;
			Item.maxStack = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<Tiles.CheliaPlushiePlaced>();
		}
	}
}