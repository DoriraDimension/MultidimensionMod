using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class RuneTaint : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archrune of Taint");
			Tooltip.SetDefault("A rune stone imbued with the power of Archvoid Kusho, it grants her power to taint other lifeforms with abyssal energy.\nIncreases Summon damage by 10%, increases life regen by 3 when below 20% health.\nAll projectiles inflict slow.\nYou can only equip one at a time, due to their immense power.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune des Verderbens");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft der Erzleere Kusho, er gewährt ihre Kraft alle Lebensformen mit abgründiger Energie zu verseuchen.\nErhöht Beschörungsschaden um 10%, erhöht Lebensregeneration wenn unter 20% Maximale Leben.\nAlle projectile verursachen Verlangsamung.\nDu kannst nur einen auf einmal ausrüsten, wegen ihrer immensen Kraft.");
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
			player.GetModPlayer<MDPlayer>().KushoRune = true;
			player.minionDamage += 0.10f;
			if (player.statLife <= player.statLifeMax2 * 0.2)
            {
				player.lifeRegen += 3;
            }
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WeirdStone>());
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 20);
			recipe.AddIngredient(ItemID.DarkShard, 4);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}