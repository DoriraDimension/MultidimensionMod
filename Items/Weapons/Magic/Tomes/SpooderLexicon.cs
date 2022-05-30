using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SpooderLexicon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arachnophobia");
			Tooltip.SetDefault("An entire book on how to defeat the fear of spiders, wait... WHY ARE THERE SPIDERS IN THIS BOOK?!\nShoots homing spiders and rarely a high velocity Albino Spider that deals double damage.");
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 5;
			Item.width = 36;
			Item.height = 32;
			Item.useTime = 48;
			Item.useAnimation = 48;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item83;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Spooder>();
			Item.shootSpeed = 9f;
			Item.crit = 8;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.NextBool(10))
			{
				float speedX2 = velocity.X * 2.0f;
				float speedY2 = velocity.Y * 2.0f;
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<Weeeeeeeee>(), (int)((double)damage * 2.0), knockback, player.whoAmI);
			}
			return true;
		}
	}
}
