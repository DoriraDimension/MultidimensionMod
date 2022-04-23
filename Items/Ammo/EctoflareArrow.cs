using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
	public class EctoflareArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ectoflare Arrow");
			Tooltip.SetDefault("A ghastly arrow infused with cursed souls. \nInflicts Ichor and Cursed Inferno");
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 18;
			Item.height = 52;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(copper: 24);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.Ammo.EctoflareArrow>();
			Item.shootSpeed = 5f;              
			Item.ammo = AmmoID.Arrow;      
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.WoodenArrow, 150)
			.AddIngredient(ItemID.Ectoplasm)
			.AddTile(134)
			.Register();
		}
	}
}
