using MultidimensionMod.Projectiles.Melee.Flails;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Flails
{
	// Example Advanced Flail is a complete adaption of Ball O' Hurt. The Projectile has the complete code needed to customize all aspects of the flail. See ExampleFlail for a simpler example that is less customizable. 
	public class SufferingFlesh : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
		}

		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45; 
			Item.useTime = 45; 
			Item.knockBack = 5.5f;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item1; 
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 30, 0);
			Item.DamageType = DamageClass.MeleeNoSpeed; 
			Item.shoot = ModContent.ProjectileType<SufferingFleshBall>();
			Item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BallOHurt)
				.AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
				.AddIngredient(ModContent.ItemType<Blight2>())
				.AddIngredient(ModContent.ItemType<Dimensium>(), 6)
				.AddTile(ModContent.TileType<DimensionalForge>())
				.Register();

			CreateRecipe()
	            .AddIngredient(ItemID.TheMeatball)
	            .AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
	            .AddIngredient(ModContent.ItemType<Blight2>())
	            .AddIngredient(ModContent.ItemType<Dimensium>(), 6)
	            .AddTile(ModContent.TileType<DimensionalForge>())
	            .Register();
		}
	}
}