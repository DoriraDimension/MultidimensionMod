using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SpooderLexicon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 5;
			Item.width = 46;
			Item.height = 44;
			Item.useTime = 44;
			Item.useAnimation = 44;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 1, 0, 0);
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
