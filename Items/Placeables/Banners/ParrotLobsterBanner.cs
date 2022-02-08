using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class ParrotLobsterBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Parrot Lobster Banner");
			Tooltip.SetDefault("Odd lobster species that lives near the shores, the have a beak which gives them their name.\nTheir meat is very tasty and can make a nice dish." +
                "\nDrops:\nLobster Claw 30%");
			DisplayName.AddTranslation(GameCulture.German, "Papageien Hummer Banner");
			Tooltip.AddTranslation(GameCulture.German, "Seltsame Hummer Spezies die nahe der Küste lebt, sie haben einen Schnabel was ihnen ihren namen gibt.\nIhr Fleisch ist sehr lecker und kann ein gutes Abendessen sein");
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
			item.placeStyle = 5;
		}
	}
}
