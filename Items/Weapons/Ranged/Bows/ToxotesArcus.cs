using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class ToxotesArcus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxotes Arcus");
			Tooltip.SetDefault("A bow created from old blueprints found at the shores. The ancient depictions show it being used to hunt ocean creatures for food.\nShoots a burst of 4 arrows.");
			DisplayName.AddTranslation(GameCulture.German, "Toxotes Arcus");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen wie er benutzt wurde um Ozeankreaturen für essen zu jagen.\nSchießt 4 Pfeil hintereinnander.");
		}

		public override void SetDefaults()
		{
			item.damage = 54;
			item.ranged = true;
			item.width = 28;
			item.height = 46;
			item.useTime = 5;
			item.reuseDelay = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 9;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float speedX2 = speedX * 1.0f;
			float speedY2 = speedY * 1.0f;
			int nah = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[nah].noDropItem = true;
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6);
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
