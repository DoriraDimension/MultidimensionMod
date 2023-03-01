using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class StarvingLarva : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starving Larva");
			Tooltip.SetDefault("You recover 5HP on enemy kills.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ModContent.RarityType<BossSoulItem>();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().StarvingLarva = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<WormSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}