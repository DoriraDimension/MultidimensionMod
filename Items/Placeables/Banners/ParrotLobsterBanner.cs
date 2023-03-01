using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class ParrotLobsterBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Parrot Lobster Banner");
			// Tooltip.SetDefault("Odd lobster species that lives near the shores, the have a beak which gives them their name.\nTheir meat is very tasty and can make a nice dish.");
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
			Item.placeStyle = 5;
		}
	}
}
