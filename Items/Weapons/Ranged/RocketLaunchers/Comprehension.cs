using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.RocketLaunchers
{
	public class Comprehension : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comprehension");
			Tooltip.SetDefault("Shoots 3 brain rockets that explode into a big invisible shockwave, the shockwave will cause braindamage and confuse enemies that are hit by it.\nWhen the brain had a moment in which its mind ascended for just a brief moment, it glimpsed past the abyss into the eternal void.\nWhatever it saw in these mere seconds, it broke the brain.");
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 84;
			Item.useTime = 70;
			Item.useAnimation = 70;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 6);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.NPCHit13;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrainRocket>();
			Item.shootSpeed = 15f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<BrainSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}