using MultidimensionMod.Items.Materials;
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
			Tooltip.SetDefault("Made with the tendrils of the big eye.");
			DisplayName.AddTranslation(GameCulture.German, "Tentakel Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ist aus den Tentakeln des großen Auges gemacht worden.");
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EyeTendril>(), 12);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}