using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class ToxotesArcus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxotes Arcus");
			Tooltip.SetDefault("A bow created from old blueprints found at the shores. The ancient depictions show it being used to hunt ocean creatures for food.\nShoots a burst of 4 arrows.");
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 46;
			Item.useTime = 5;
			Item.reuseDelay = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 9;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX2 = velocity.X * 1.0f;
			float speedY2 = velocity.Y * 1.0f;
			int nah = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Main.projectile[nah].noDropItem = true;
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6)
			.AddIngredient(ItemID.HallowedBar, 13)
			.AddTile(134)
			.Register();
		}
	}
}
