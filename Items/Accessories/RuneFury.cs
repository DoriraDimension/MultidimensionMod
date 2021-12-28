using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class RuneFury : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archrune of Fury");
			Tooltip.SetDefault("A rune stone imbued with the power of Archtyrant Ignaen, it grants his all burning fury for the cost of defense and life regen.\nIncreases crit chance by 15% and makes immune to On Fire! and fire blocks, but reduces defense by 10 and life regen by 1.\nAll projectiles inflict Blazing Suffering.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune des Zorns");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft des Erztyrannen Ignaen, es gewährt seinen alles verbrennenden Zorn reduziert aber Verteidigung und Lebensregeneration.\nErhöht Kritische Trefferchance um 15% und macht immun gegen In Brand Stehend! und Feuerblöcke, reduziert aber Verteidigung um 10 und Lebensregeneration um 1.\nAlle Projektile verursachen Loderndes Leiden.");
		}

		public override void SetDefaults()
		{
			item.width = 58;
			item.height = 60;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Cyan;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().IgnaenRune = true;
			player.meleeCrit += 15;
			player.rangedCrit += 15;
			player.magicCrit += 15;
			player.thrownCrit += 15;
			player.statDefense -= 10;
			player.lifeRegen -= 1;
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WeirdStone>());
			recipe.AddIngredient(ItemID.RagePotion, 5);
			recipe.AddIngredient(ItemID.Hellstone, 35);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}