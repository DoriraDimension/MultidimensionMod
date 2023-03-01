using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientDragonSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Dragon Skull");
			// Tooltip.SetDefault("A dragon skull from old times, it is no longer cursed.");
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<Tiles.AncientDragonSkullPlaced>();
		}
	}
}