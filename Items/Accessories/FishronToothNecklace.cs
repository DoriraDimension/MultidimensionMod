using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class FishronToothNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fishron Tooth Necklace");
			Tooltip.SetDefault("A necklace made from the Teeth of a great ocean abomination,\nas shown in depictions of the old sea civilisation, it was seen as a sign of strength.\nIncreases armor penetration by 12 and grants underwater breathing.");
			DisplayName.AddTranslation(GameCulture.German, "Fischron Zahn Halskette");
			Tooltip.AddTranslation(GameCulture.German, "Eine Halskette die aus den Zähnen einer großen Ozean Abscheuligkeit gemacht wurde,\nwie es in Abbildungen der alten Meeres Zivilisation gezeigt wird, es wurde als ein Zeichen der stärke angesehen.\nErhöht die Rüstungsdurchdringung um 12 und gewährt Unterwasseratmung.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 44;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 89);
			item.rare = ItemRarityID.Lime;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.armorPenetration += 12;
			player.gills = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ModContent.ItemType<SpiderFangNecklace>());
			modRecipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7);
			modRecipe.AddTile(18);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
