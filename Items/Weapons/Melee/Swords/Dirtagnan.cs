using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Dirtagnan : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("D'irtagnan");
			Tooltip.SetDefault("Stab with the power of dirt.");
			DisplayName.AddTranslation(GameCulture.German, "D'irtagnan");
			Tooltip.AddTranslation(GameCulture.German, "Steche zu mit der Kraft des Drecks.");
		}

		public override void SetDefaults()
		{
			item.damage = 6;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 10;
			item.useStyle = 3;
			item.knockBack = 1.5f;
			item.value = Item.sellPrice(copper: 7);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 10;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 100);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 100);
			recipe.AddIngredient(ItemID.LeadBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}