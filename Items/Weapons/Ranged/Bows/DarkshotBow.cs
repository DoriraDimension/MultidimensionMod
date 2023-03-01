using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class DarkshotBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Darkshot Bow");
			// Tooltip.SetDefault("A dark matter bow from the dark edge of the cosmos.\nShoots 3 arrows at once.");
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 7);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(6));
				int nah = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
				Main.projectile[nah].noDropItem = true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
			.AddTile(26)
			.Register();
		}
	}
}