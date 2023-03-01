using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class MandibleMetalBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Antlion Mandible Bow");
			// Tooltip.SetDefault("A bow that was restored from old relics, its is made of Antlion Mandibles.\nShoots two Mandibles.");
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 34;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 34);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 2;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5));
				int nah = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Mandible>(), damage, knockback, player.whoAmI);
				Main.projectile[nah].noDropItem = true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldDustyBow>())
			.AddIngredient(ItemID.AntlionMandible, 2)
			.AddTile(377)
			.Register();
		}
	}
}