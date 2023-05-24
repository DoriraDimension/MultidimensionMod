using MultidimensionMod.Projectiles.Summon.Whips;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class Tentacle : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 123;
			Item.width = 58;
			Item.height = 56;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.DefaultToWhip(ModContent.ProjectileType<TentacleWhip>(), 45, 2, 4);
			Item.shootSpeed = 8;

		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 6;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(22));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}
