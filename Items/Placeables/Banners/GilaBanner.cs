using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class GilaBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilania Banner");
			Tooltip.SetDefault("Big reptiles that live in the desert, their bite is venomous.\nThey will rest underground at day to escape the blazing desert sun and come out at night." +
                "\nDrops:\nVial of Venom 80%");
			DisplayName.AddTranslation(GameCulture.German, "Gilania Banner");
			Tooltip.AddTranslation(GameCulture.German, "Große Reptilien die in der Wüste leben, ihr Biss ist hoch Giftig.\nSie ruhen sich Tagsüber im Untergrund aus um der sengenden Wüstensonne zu enkommen und kommen nur Nachts raus.");
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
			item.placeStyle = 10;
		}
	}
}
