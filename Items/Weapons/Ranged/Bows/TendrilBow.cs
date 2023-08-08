using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class TendrilBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 9f;
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
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}