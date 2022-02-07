using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class TendrilBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tendril Bow");
			Tooltip.SetDefault("Made with the tendrils of the big eye.\nHas a chance to shoot a small eyeball that deals 50% more damage.");
			DisplayName.AddTranslation(GameCulture.German, "Tentakel Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ist aus den Tentakeln des großen Auges gemacht worden.\nHat eine chance einen kleinen Augapfel zu schießen.");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 24;
			item.height = 30;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 3);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(7))
			{
				float speedX2 = speedX * 0.5f;
				float speedY2 = speedY * 0.5f;
				Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<Eyeball>(), (int)((double)damage * 1.5), knockBack, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EyeTendril>(), 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}