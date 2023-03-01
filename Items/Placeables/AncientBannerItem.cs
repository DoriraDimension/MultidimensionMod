using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientBannerItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Banner");
			// Tooltip.SetDefault("A ancient banner, its made of worn cloth and probably not ideal as furniture.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(silver: 10);
			Item.createTile = ModContent.TileType<Tiles.AncientBanner>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.AncientCloth, 5)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}