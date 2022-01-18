using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class HealthyCap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healthy Cap");
			Tooltip.SetDefault("A healthy mushroom filled with healing potion liquid.\nIncreases max HP by 35.");
			DisplayName.AddTranslation(GameCulture.German, "Gesunde Kappe");
			Tooltip.AddTranslation(GameCulture.German, "Ein gesunder Pilz der mit Heiltrank Flüssigkeit gefüllt ist.\nErhöht die maximalen Lebenspunkte um 35.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 2);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 35;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Mushroom, 20);
			modRecipe.AddIngredient(ItemID.HealingPotion, 1);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
