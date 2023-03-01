using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class StormEelBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Storm Front Eel Banner");
			// Tooltip.SetDefault("The great storm eels, only active during storms, when the sea is harsh and unforgiving.\nMany people believe they are scouts, scouts of someone or something deep under the ocean,\nthat is why these creatures are seen as an omen of even worse to come");
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
			Item.placeStyle = 4;
		}
	}
}
