using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class AtlanteanTrident : ModItem
	{
		int WaveTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Atlantean Trident");
			Tooltip.SetDefault("fdjpydsfhgpsdfughaofidjüaefogip.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 43;
			Item.useAnimation = 43;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(copper: 34);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WaterStream;
			Item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 6;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			if (WaveTimer == 2)
            {
			    Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Wave>(), damage, knockback, player.whoAmI);
            }

			return false;
		}

		public override bool? UseItem(Player player)
		{
			WaveTimer += 1;
			if (WaveTimer >= 3)
			{
				WaveTimer = 0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OceanTrident>())
			.AddIngredient(ItemID.AquaScepter)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}