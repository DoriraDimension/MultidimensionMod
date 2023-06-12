using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class Cursemark : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 3;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(0, 1, 20, 0);
			Item.rare = ItemRarityID.Orange;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<Curse>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}
	}
}