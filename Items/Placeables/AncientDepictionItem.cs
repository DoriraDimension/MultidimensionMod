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
			DisplayName.SetDefault("Ancient Depiction");
			Tooltip.SetDefault("A big and heavy sandstone tablet, it seems to show something that the people who made it worshipped.");
			DisplayName.AddTranslation(GameCulture.German, "Uralte Darstellung");
			Tooltip.AddTranslation(GameCulture.German, "Eine große und schwere Sandstein Tafel, sie scheint etwas zu zeigen das die Leute die sie gemacht haben verehrten.");
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
			item.createTile = ModContent.TileType<Tiles.AncientDepiction>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BrokenAncientDepictionItem>());
			recipe.AddIngredient(ItemID.BeeWax);
			recipe.AddIngredient(ItemID.SandstoneSlab, 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}