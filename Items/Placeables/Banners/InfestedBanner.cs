using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class InfestedBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infested Abomination Banner");
			Tooltip.SetDefault("It was possibly once human but is now just a disgusting thing, these weird creatures are hosts to a local species of rot loving flies.\nThey drip green stinky goo everywhere they walk and spit disgusting liquid with every movement of their mouth." +
                "\nDrops:\nRotten Chunk 50%\nThe Fly 3%\nInfested Abomination Mask 3%");
			DisplayName.AddTranslation(GameCulture.German, "Befallene Abscheuligkeit Banner");
			Tooltip.AddTranslation(GameCulture.German, "Ein Fisch aus einer ander Dimension, sie haben Leuchtorgane üverall an ihrem Körper, was darauf hindeutet das sie eigentlich in tieferen Gewässern gelebt haben.\nSie tropfen grünen stinkended Glibber überall wo sie langgehen und spucken wiederliche Flüssigkeit mit jeder bewegung ihres Mundes.");
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
			item.placeStyle = 1;
		}
	}
}
