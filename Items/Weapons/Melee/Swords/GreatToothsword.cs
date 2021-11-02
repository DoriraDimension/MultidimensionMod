using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class GreatToothsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Great Toothsword");
			Tooltip.SetDefault("A big tooth on a stick acting as a blade, there is still flesh on it.");
			DisplayName.AddTranslation(GameCulture.German, "Groﬂes Zahnschwert");
			Tooltip.AddTranslation(GameCulture.German, "Ein groﬂer Zahn an einem Stock der wie eine Klinge funktioniert, da ist immer noch Fleisch an dem Zahn.");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.melee = true;
			item.width = 58;
			item.height = 68;
			item.useTime = 41;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(silver: 25);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TissueSample, 15);
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}