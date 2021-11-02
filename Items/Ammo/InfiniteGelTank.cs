using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
	public class InfiniteGelTank : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinite Gel Tank");
			Tooltip.SetDefault("A tank with integrated gel fabricator, you will never run out of gel anymore.");
			DisplayName.AddTranslation(GameCulture.German, "Undendlicher Gel Tank");
			Tooltip.AddTranslation(GameCulture.German, "Ein Tank mit integriertem Gel Fabrikator, dir wird jetzt niemals mehr das Gel ausgehen.");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Green;
			item.ammo = AmmoID.Gel;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 3996);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
