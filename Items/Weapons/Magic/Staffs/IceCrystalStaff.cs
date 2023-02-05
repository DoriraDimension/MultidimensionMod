using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class IceCrystalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Crystal Staff");
			Tooltip.SetDefault("A staff that was restored from old relics, it shoots 3 icicles that burst into smaller icicles.");
			Item.staff[Item.type] = true;
		}


		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 47;
			Item.useAnimation = 47;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 90);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Icicle>();
			Item.shootSpeed = 20f;
			Item.crit = 8;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 3 + Main.rand.Next(1);
			float rotation = MathHelper.ToRadians(10);
			position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f;
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<CoolingStaff>())
			.AddIngredient(ItemID.FrostCore)
			.AddIngredient(ModContent.ItemType<IceblossomItem>(), 2)
			.AddTile(134)
			.Register();
		}
	}
}