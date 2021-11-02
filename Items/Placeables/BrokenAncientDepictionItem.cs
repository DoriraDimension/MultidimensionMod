using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class BrokenAncientDepictionItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Ancient Depiction");
			Tooltip.SetDefault("A big and heavy sandstone tablet, it seems to be broken and it's difficult to guess what it is showing.");
			DisplayName.AddTranslation(GameCulture.German, "Beschädigte Uralte Darstellung");
			Tooltip.AddTranslation(GameCulture.German, "Eine große und schwere Sandstein Tafel, sie scheint beschädigt zu sein und es ist schwer zu erraten was sie zeigt.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 20;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.createTile = ModContent.TileType<Tiles.BrokenAncientDepiction>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AncientDepictionItem>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}