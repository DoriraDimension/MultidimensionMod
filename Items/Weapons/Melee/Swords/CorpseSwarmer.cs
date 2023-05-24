using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CorpseSwarmer : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 68;
			Item.useTime = 70;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 2, 30, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DecayFlyFriendly>();
			Item.shootSpeed = 8f;
			Item.crit = 4;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX2 = velocity.X + (float)Main.rand.Next(-10, 11) * 0.40f;
			float speedY2 = velocity.Y + (float)Main.rand.Next(-10, 11) * 0.40f;
			Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, type, damage, knockback, player.whoAmI);
			if (Main.rand.NextBool(6))
			{
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<BigFly>(), (int)((double)damage * 1.5), (int)((double)knockback * 0.2), player.whoAmI);
			}

			for (int i = 0; i < 2; i++)
			{
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				Projectile.NewProjectileDirect(source, position, newVelocity, Item.shoot, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			for (int numero = 0; numero < 2; numero++)
			{
				Vector2 value = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				value.Normalize();
				value *= (float)Main.rand.Next(10, 201) * 0.01f;
				Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), player.Center.X, player.Center.Y, value.X, value.Y, ModContent.ProjectileType<DecayFlyFriendly>(), (int)((double)Item.damage * 0.3), hit.Knockback, player.whoAmI);
			}
			target.AddBuff(BuffID.Confused, 120);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TheFly>())
			.AddIngredient(ItemID.BeeKeeper)
			.AddRecipeGroup(Recipes.Adamantitanium, 3)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}