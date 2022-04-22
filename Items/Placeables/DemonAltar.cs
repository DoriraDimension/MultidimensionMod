using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class DemonAltar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Altar");
			Tooltip.SetDefault("So you dont need to run to your local Corruption anymore.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 40);
			Item.createTile = ModContent.TileType<Tiles.PlacedDemonAltar>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.ShadowScale, 15)
			.AddIngredient(61, 30)
			.AddTile(26)
			.Register();
		}
	}
}