using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class AstralTitansEyeJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Titan's Eye Jewel");
			Tooltip.SetDefault("A jewel made to look like the eyes of the creation titan.\nDecreases the duration of the Potion Sickness debuff to 45 seconds and increases life regen by 2. \nIncreases invincibility time and rains down stars after getting hit.");
			DisplayName.AddTranslation(GameCulture.German, "Augenjuwel des Astral Titanen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Juwel gemacht um wie die Augen des Schöpfungstitanen auszusehen. \nVerringert die dauer der Tränkekrankheit zu 45 Sekunden und erhöht Lebenregeneration um 2. \nVerlängert Unverwundbarkeit und es regnen sterne vom Himmel when getroffen.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 36;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pStone = true;
			player.starCloak = true;
			player.longInvince = true;
			player.lifeRegen += 2;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(860);
			recipe.AddIngredient(862);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 2);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}