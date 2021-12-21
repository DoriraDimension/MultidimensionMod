using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ColdDesertShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Desert Shield");
			Tooltip.SetDefault("Combining both, desert and frost magic results in a strong protecting shield.\nIncreases defense by 6 and damage reduction by 4% when in the Desert or Snow biome.\nIncreases defense by 4 when under 50% life");
			DisplayName.AddTranslation(GameCulture.German, "Kalter Wüstenschild");
			Tooltip.AddTranslation(GameCulture.German, "Wenn Wüsten und Frost Magie kombiniert werden wird ein starker beschützender Schild erschaffen.\nErhöht verteidigung um 6 und Schadensreduzierung um 4% wenn im Wüsten oder Schnee Biom.\nErhöht Verteidigung um 4 wenn Leben ist unter 50%.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 24;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 34);
			item.rare = ItemRarityID.Green;
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow || player.ZoneDesert)
			{
				player.statDefense += 6;
				player.endurance += 0.04f;
			}
			if (player.statLife <= player.statLifeMax2 * 0.5)
			{
				player.statDefense += 4;
            }

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DrakescaleShield>());
			recipe.AddIngredient(ModContent.ItemType<DesertNecklace>());
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}