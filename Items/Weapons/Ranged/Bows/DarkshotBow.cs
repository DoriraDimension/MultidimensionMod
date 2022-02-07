using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class DarkshotBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkshot Bow");
			Tooltip.SetDefault("A dark matter bow from the dark edge of the cosmos.\nShoots 3 arrows at once.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkelschuss Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein dunkle materie Bogen vom dunklen teil des Kosmos.\nSchießt 3 Pfeile gleichzeitig.");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.ranged = true;
			item.width = 24;
			item.height = 30;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 7);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
				int nah = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Main.projectile[nah].noDropItem = true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}