using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.RocketLaunchers
{
	public class Comprehension : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 84;
			Item.useTime = 70;
			Item.useAnimation = 70;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.NPCHit13;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrainRocket>();
			Item.shootSpeed = 15f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
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