using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientDepictionItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Depiction");
			// Tooltip.SetDefault("A big and heavy sandstone tablet, it depicts a bird found in old desert legends, a bird of judgement.");
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
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<Tiles.AncientDepiction>();
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