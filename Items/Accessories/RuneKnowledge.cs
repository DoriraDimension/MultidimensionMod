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
			Tooltip.SetDefault("A rune stone imbued with the power of Archdevil Shinoro, it grants his immense magical knowledge and control over mana.\nIncreases magic damage by 10%, mana regen by 2 and max mana by 50.\nAll projectiles inflict Shadow Flame.\nYou can only equip one at a time, due to their immense power.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune des Wissens");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft des Erzteufels Shinoro, es  gewährt sein immenses Wissen und Kontrolle über Mana.\nErhöht Magieschaden um 10%, mana regeneration um 2 und maximales Mana um 50.\nAlle Projektile verursachen Schattenflammen.\nDu kannst nur einen auf einmal ausrüsten, wegen ihrer immensen Kraft.");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 46;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Cyan;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (player.GetModPlayer<MDPlayer>().RaitolgurRune || player.GetModPlayer<MDPlayer>().KushoRune || player.GetModPlayer<MDPlayer>().IgnaenRune || player.GetModPlayer<MDPlayer>().ShinoroRune || player.GetModPlayer<MDPlayer>().PrismaRune || player.GetModPlayer<MDPlayer>().KiminoRune || player.GetModPlayer<MDPlayer>().KegakumoRune)
			{
				return false;
			}
			return true;
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