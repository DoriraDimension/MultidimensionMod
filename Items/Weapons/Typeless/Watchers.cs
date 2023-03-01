using MultidimensionMod.Projectiles.Typeless;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class Watchers : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Watchers");
			// Tooltip.SetDefault("Grants the ability to fire a swarm of ever watching eyes.\nThe servants of the Eye of Judgement will some day become what their master is if given enough time.");
		}


		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Generic;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Eyeball>();
			Item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 1; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<EyeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}