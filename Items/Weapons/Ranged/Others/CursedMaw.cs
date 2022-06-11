using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class CursedMaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Maw");
			Tooltip.SetDefault("A grotesque weapon, almost seems to be alive...\nShoots 3 beams of cursed energy.");
		}

		public override void SetDefaults()
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.reuseDelay = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<CursedRay>();
			Item.shootSpeed = 10f;
			Item.crit = 4;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(20));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RottenChunk, 20)
			.AddIngredient(ItemID.CursedFlame, 8)
			.AddTile(134)
			.Register();
		}
	}
}
