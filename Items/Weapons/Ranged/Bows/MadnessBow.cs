using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class MadnessBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mindpiercing Madness");
			// Tooltip.SetDefault("A bow made from the flesh of creatures that attampted ascension\nFires two inaccurate shots that inflict madness");
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width =34;
			Item.height = 50;
			Item.useTime = 5;
			Item.reuseDelay = 40;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 24);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item75;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 34f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			{
				type = ModContent.ProjectileType<MadnessBolt>();
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 1; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
			.AddTile(16)
			.Register();
		}
	}
}