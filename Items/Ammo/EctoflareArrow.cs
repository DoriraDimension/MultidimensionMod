using MultidimensionMod.Projectiles.Ammo;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
	public class EctoflareArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ectoflare Arrow");
			Tooltip.SetDefault("A ghastly arrow infused with cursed souls. \nInflicts Ichor and Cursed Inferno");
			DisplayName.AddTranslation(GameCulture.German, "Ektoloder Pfeil");
			Tooltip.AddTranslation(GameCulture.German, "Ein gespenstischer Pfeil durchzogen mit verfluchten Seelen. \nVerursacht Ichor und Verfluchtes Inferno.");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.ranged = true;
			item.width = 18;
			item.height = 52;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = Item.sellPrice(copper: 24);
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<Projectiles.Ammo.EctoflareArrow>();
			item.shootSpeed = 5f;              
			item.ammo = AmmoID.Arrow;      
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 20);
			recipe.AddIngredient(ItemID.Ectoplasm);
			recipe.AddTile(134);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}
