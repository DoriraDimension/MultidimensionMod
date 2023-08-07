using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class AtlanteanTrident : ModItem
	{
		int BlastCount = 0;
		public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 2, 10, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WaterStream;
			Item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 6; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			if (BlastCount == 4)
            {
			    Projectile.NewProjectile(source, position.X, position.Y, velocity.X * 2, velocity.Y * 2, ModContent.ProjectileType<SaltwaterBolt>(), damage, knockback, player.whoAmI);
            }

			return false;
		}

		public override bool? UseItem(Player player)
		{
			BlastCount += 1;
			if (BlastCount >= 5)
			{
				BlastCount = 0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OceanTrident>())
			.AddIngredient(ItemID.AquaScepter)
			.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}