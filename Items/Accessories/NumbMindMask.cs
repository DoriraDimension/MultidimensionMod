using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class NumbMindMask : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 34);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[ModContent.BuffType<Madness>()] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<CerebroAlloy>(), 5)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}