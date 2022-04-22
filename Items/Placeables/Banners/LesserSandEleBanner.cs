using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class LesserSandEleBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Sand Elemental Banner");
			Tooltip.SetDefault("They are actually crystalized mana surrounded by sand, it's unclear yet if they were brought to life naturally or through magic experiments.\nThey will react hostile against every human that enters a desert.\nDuring sandstorms they become even more active and travel to the surface, sometimes following Sand Elementals.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 3);
			Item.createTile = ModContent.TileType<MonsterBanner>();
			Item.placeStyle = 9;
		}
	}
}
