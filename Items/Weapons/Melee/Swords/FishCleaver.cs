using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fish Cleaver");
			Tooltip.SetDefault("Fish -Phiakitti 2021.");
			DisplayName.AddTranslation(GameCulture.German, "Fisch Beil");
			Tooltip.AddTranslation(GameCulture.German, "Fish -Phiakitti 2021.");
		}

		public override void SetDefaults()
		{
			item.damage = 61;
			item.melee = true;
			item.width = 86;
			item.height = 86;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 70);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.crit = 8;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BreakerBlade);
			recipe.AddIngredient(ItemID.Bass, 3);
			recipe.AddIngredient(ItemID.AtlanticCod, 3);
			recipe.AddIngredient(ItemID.PrincessFish, 3);
			recipe.AddIngredient(ItemID.RedSnapper, 3);
			recipe.AddIngredient(ItemID.Trout, 3);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}