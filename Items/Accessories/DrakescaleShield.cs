using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class DrakescaleShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drakescale Shield");
			Tooltip.SetDefault("A shield reinforced with the scales of juvenile Ice Drakes.\nIncreases defense by 4 and damage reduction by 4% when in the Snow biome.");
			DisplayName.AddTranslation(GameCulture.German, "Drakenschuppen Schild");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schild, verstärkt mit Schuppen eines jungen Eis Draken.\nErhöht verteidigung um 4 und Schadensreduzierung um 4% wenn im Schnee Biom.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 24;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 2);
			item.rare = ItemRarityID.Green;
			item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow)
            {
				player.statDefense += 4;
				player.endurance += 0.04f;
            }

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 5);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}