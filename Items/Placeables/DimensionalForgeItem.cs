using MultidimensionMod.Rarities;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class DimensionalForgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ModContent.RarityType<DoriraRarity>();
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.createTile = ModContent.TileType<DimensionalForge>();
		}
	}
}