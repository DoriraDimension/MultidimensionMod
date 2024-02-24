using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials
{
	public class AbyssalHellstoneBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 90, 0);
			Item.rare = ItemRarityID.Pink;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<AbyssalHellstoneBarPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AbyssalHellstone>(), 3)
            .AddTile(TileID.Furnaces)
            .Register();
		}
	}
}