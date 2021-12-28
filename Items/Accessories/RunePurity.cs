using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class RunePurity : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archrune of Purity");
			Tooltip.SetDefault("A rune stone imbued with the power of Archpurity Prisma, it grants her godly powers of purity.\nIncreases max HP by 50,life regen by 2 and grants the ability to fly.\nYou can only equip one at a time, due to their immense power.");
			DisplayName.AddTranslation(GameCulture.German, "Erzrune der Reinheit");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein durchtränkt mit der Kraft des Erzreinheit Prisma, er gewährt ihre göttlichen Kräfte der Reinheit.\nErhöht maximale Leben um 50, Lebensregeneration um 2 und gewährt die Fähigkeit zu Fliegen.\nDu kannst nur einen auf einmal ausrüsten, wegen ihrer immensen Kraft.");
		}

		public override void SetDefaults()
		{
			item.width = 102;
			item.height = 32;
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
			player.lifeRegen += 2;
			player.statLifeMax2 += 50;
			player.wingTimeMax = 180;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
	ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.50f;
			ascentWhenRising = 0.20f;
			maxCanAscendMultiplier = 2f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.100f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 3.0f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WeirdStone>());
			recipe.AddIngredient(ItemID.SoulofLight, 28);
			recipe.AddIngredient(ItemID.LightShard, 15);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}