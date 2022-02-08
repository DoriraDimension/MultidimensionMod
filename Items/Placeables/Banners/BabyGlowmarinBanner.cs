using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class BabyGlowmarinBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baby Glowmarin Banner");
			Tooltip.SetDefault("These small adorable fish are from another dimension, they reproduce really fast.\nIts small glow organs are already developed and work fine.");
			DisplayName.AddTranslation(GameCulture.German, "Baby Leuchtmarin Banner");
			Tooltip.AddTranslation(GameCulture.German, "Diese kleinen niedlichen Fische sind aus einer anderen Dimension, sie vermehren sich sehr schnell.\nSeine kleinen Leuchtorgane sind schon entwickelt und funktionieren gut.");
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
			item.placeStyle = 6;
		}
	}
}
