using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld
{
	public class IceblossomSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.placeStyle = 0;
			Item.value = Item.sellPrice(0, 0, 0, 24);
			Item.rare = ItemRarityID.White;
			Item.createTile = ModContent.TileType<Iceblossom>();
		}
	}
}