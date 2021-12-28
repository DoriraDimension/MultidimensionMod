using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class RuneSilence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archrune of Silence");
			Tooltip.SetDefault("A rune stone imbued with the power of Archshadow Kimino, it grants her power to travel in absolute silence and ability to hit targets with ease.\nIncreases ranged damage by 10%, reduces enemy aggro and gives a chance to dodge attacks.\nAll projectiles have a chance to confuse enemies.\nYou can only equip one at a time, due to their immense power.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune der Stille");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft des Erzschattens Kimino, er gewährt ihre Kraft in absoluter Stille zu wandern und die Fähigkeit Ziele mir leichtigkeit zu treffen.\nErhöht Fernkampfschaden um 10%, reduziert enemy aggro und gibt eine chance Angriffen auszuweichen.\nAll Projektile haben eine chance Gegner zu verwirren.\nDu kannst nur einen auf einmal ausrüsten, wegen ihrer immensen Kraft.");
		}

		public override void SetDefaults()
		{
			item.width = 50;
			item.height = 50;
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
			player.GetModPlayer<MDPlayer>().KiminoRune = true;
			player.rangedDamage += 0.10f;
			player.aggro -= 500;
			player.blackBelt = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WeirdStone>());
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.DarkShard, 8);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}