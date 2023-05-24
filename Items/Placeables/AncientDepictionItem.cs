using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientDepictionItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.createTile = ModContent.TileType<AncientDepiction>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<BrokenAncientDepictionItem>())
			.AddIngredient(ItemID.BeeWax)
			.AddIngredient(ItemID.SandstoneSlab, 5)
			.AddTile(TileID.HeavyWorkBench)
			.Register();
		}
	}
}