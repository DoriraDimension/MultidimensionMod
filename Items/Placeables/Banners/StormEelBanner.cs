using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class StormEelBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Front Eel Banner");
			Tooltip.SetDefault("The great storm eels, only active during storms, when the sea is harsh and unforgiving.\nMany people believe they are scouts, scouts of someone or something deep under the ocean,\nthat is why these creatures are seen as an omen of even worse to come." +
                "\nDrops:\nStorm Hide 50%\nThunderbubble Bow 20%\nEel Mask 10%\nTidal Quartz 1-3 100%");
			DisplayName.AddTranslation(GameCulture.German, "Sturmfront Aal Banner");
			Tooltip.AddTranslation(GameCulture.German, "Die großen Sturmaale, nur aktiv während eines Sturms, wenn die See rau und tödlich ist.\nViele Leute glauben das sie späher sind, Späher für jemanden ode retwas tief unter dem Ozean,\ndas ist der Grund warum diese Kreaturen als ein Omen für noch schlimmeres angesehen werden.");
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
			item.placeStyle = 4;
		}
	}
}
