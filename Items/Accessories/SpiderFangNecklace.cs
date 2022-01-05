using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class SpiderFangNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Fang Necklace");
			Tooltip.SetDefault("A necklace made of spider fangs.\nIncreases armor penetration by 9.");
			DisplayName.AddTranslation(GameCulture.German, "Spinnenzahn Halskette");
			Tooltip.AddTranslation(GameCulture.German, "Eine halskette aus Spinnenzähnen.\nErhöht die Rüstungsdurchdringung um 9.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 23);
			item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.armorPenetration += 9;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(3212);
			modRecipe.AddIngredient(ItemID.SpiderFang, 10);
			modRecipe.AddTile(18);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
