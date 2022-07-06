using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class TendrilBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tendril Bow");
			Tooltip.SetDefault("Made with the tendrils of the big eye.\nHas a chance to shoot a small eyeball that deals 50% more damage.");
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.NextBool(7))
			{
				float speedX2 = velocity.X * 0.5f;
				float speedY2 = velocity.Y * 0.5f;
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<Eyeball>(), (int)((double)damage * 1.5), knockback, player.whoAmI);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<EyeTendril>(), 5)
			.AddTile(16)
			.Register();
		}
	}
}