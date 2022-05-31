using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class Sharanga2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Bow, Sharan");
			Tooltip.SetDefault("A long lost bow, forgotten in ancient times.\nConverts Wooden Arrows into Cursed Arrows");
		}

		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 52;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 7;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.ShadowFlameBow)
			.AddIngredient(ModContent.ItemType<Blight2>(), 10)
			.AddIngredient(ItemID.Ectoplasm, 5)
			.AddTile(134)
			.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX2 = velocity.X * 1.5f;
			float speedY2 = velocity.Y * 1.5f;
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.CursedArrow;
			}
			int nah = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.CursedArrow, damage, knockback, player.whoAmI);
			Main.projectile[nah].noDropItem = true;
			return true;
		}
	}
}
