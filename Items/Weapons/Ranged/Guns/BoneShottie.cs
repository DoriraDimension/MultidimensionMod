using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class BoneShottie : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bone Shottie");
			// Tooltip.SetDefault("Spooky Scary Shotgun.");
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 22;
			Item.useTime = 52;
			Item.useAnimation = 52;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 11f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Bone, 34)
			.AddTile(300)
			.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 4;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));																												
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}