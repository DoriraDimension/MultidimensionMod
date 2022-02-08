using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class TridentBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Trident Banner");
			Tooltip.SetDefault("A trident that moves on its own, basically a remnant of the old Sea civilisation.\nNow that their owners are gone they aimlessly roam the ocean with no purpose." +
                "\nDrops:\nNazar 1%\nOld Sea Crown 4%");
			DisplayName.AddTranslation(GameCulture.German, "Magischer Dreizack Banner");
			Tooltip.AddTranslation(GameCulture.German, "Ein Dreizack der sich von alleine bewegt, im grunde genommen ein überrest der alten Meeres Zivilisation.\nNun da ihre besitzer fort sind, durchstreifen sie Ziellos den Ozean.");
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
			item.placeStyle = 2;
		}
	}
}
