using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class RuneKnowledge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archrune of Knowledge");
			Tooltip.SetDefault("A rune stone imbued with the power of Archdevil Shinoro, it grants his immense magical knowledge and control over mana.\nIncreases magic damage by 10%, mana regen by 2 and max mana by 50, all projectiles inflict Shadow Flame.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune des Wissens");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft des Erzteufels Shinoro, es  gewährt sein immenses Wissen und Kontrolle über Mana.\nErhöht Magieschaden um 10%, mana regeneration um 2 und maximales Mana um 50, alle Projektile verursachen Schattenflammen.");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 46;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Cyan;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().ShinoroRune = true;
			player.magicDamage += 0.10f;
			player.manaRegen += 2;
			player.statManaMax2 += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WeirdStone>());
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.Book, 15);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}