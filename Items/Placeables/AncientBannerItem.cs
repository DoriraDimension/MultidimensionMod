using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientBannerItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Banner");
			Tooltip.SetDefault("A ancient banner, it was was maybe used in ceremonial activity.");
			DisplayName.AddTranslation(GameCulture.German, "Uraltes Banner");
			Tooltip.AddTranslation(GameCulture.German, "Ein uraltes banner, es wurde vielleicht in zeremoniellen Aktivitäten verwendet.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(silver: 10);
			item.createTile = ModContent.TileType<Tiles.AncientBanner>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AncientCloth, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}