using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class CreationMedaillon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creation Medaillon");
			Tooltip.SetDefault("The creation Titan's medaillon, very powerful and full of energy.\nIncreases all damage by 10% and crit chance by 10%.\nDecreases the duration of the Potion Sickness debuff to 45 seconds and increases life regen by 2.\nIncreases invincibility time and rains down stars after getting hit. \nGives a variety of additional stat bonuses.");
			DisplayName.AddTranslation(GameCulture.German, "Schöpfungs Medaillon");
			Tooltip.AddTranslation(GameCulture.German, "Das Medaillon des Schöpfungstitanen, sehr mächtig und voll mit Energie. \nErhöht allen schaden und Kritische Trefferchance um 10% \nVerringert die dauer der Tränkekrankheit zu 45 Sekunden und erhöht Lebenregeneration um 2. \nVerlängert Unverwundbarkeit und es regnen sterne vom Himmel when getroffen. \nGibt ein paar weitere stat erhöhungen.");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 15);
			item.rare = ItemRarityID.Yellow;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		    player.pStone = true;
		    player.starCloak = true;
		    player.longInvince = true;
		    player.lifeRegen += 2;
			player.allDamage += 0.10f;
		    player.meleeCrit += 10;
			player.rangedCrit += 10;
			player.magicCrit += 10;
			player.thrownCrit += 10;
			player.meleeSpeed += 0.10f;
			player.statDefense += 7;
			player.pickSpeed += 0.15f;
			player.moveSpeed += 0.10f;
			player.minionKB += 0.005f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstralTitansEyeJewel>());
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.CelestialStone);
;			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}