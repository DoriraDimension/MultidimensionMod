using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class CalamityRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamity Ring");
			Tooltip.SetDefault("The eye of a black dragon.\nAll damage you receive is doubled.");
			DisplayName.AddTranslation(GameCulture.German, "Ring des Unheils");
			Tooltip.AddTranslation(GameCulture.German, "Das Auge eines Schwarzen Drachen. \nJeder erhaltene Schaden ist verdoppelt.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 24;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 0);
			item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 1f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}