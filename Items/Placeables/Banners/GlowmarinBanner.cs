using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class GlowmarinBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Glowmarin Banner");
			Tooltip.SetDefault("A fish from another dimension, they have glowing organs all over their body, suggesting that they originally lived in deeper waters." +
                "\nDrops:\nGlowing Kelp Hook 15%\nOceanic Glowshard 15%\nGlowseed 35%");
			DisplayName.AddTranslation(GameCulture.German, "Jenseitiger Leuchtmarin Banner");
			Tooltip.AddTranslation(GameCulture.German, "Ein Fisch aus einer ander Dimension, sie haben Leuchtorgane üverall an ihrem Körper, was darauf hindeutet das sie eigentlich in tieferen Gewässern gelebt haben.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 3);
			item.createTile = ModContent.TileType<MonsterBanner>();
			item.placeStyle = 3;
		}
	}
}