using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StarRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Rod");
			Tooltip.SetDefault("The power of the stars is on your side.");
			DisplayName.AddTranslation(GameCulture.German, "Sternenzepter");
			Tooltip.AddTranslation(GameCulture.German, "Die kraft der Sterne ist auf deiner seite.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.shootSpeed *= 0.65f;
			item.width = 26;
			item.height = 26;
			item.damage = 8;
			item.magic = true;
			item.noMelee = true;
			item.value = Item.sellPrice(copper: 67);
			item.mana = 4;
			item.rare = ItemRarityID.Blue;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<PoyoStar>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddRecipeGroup("Wood", 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}