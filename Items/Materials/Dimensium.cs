using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Dimensium : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensuim");
			Tooltip.SetDefault("The most common dimensional energy in form of a crystal, mostly found when a being crosses the dimensional wall through an unstable rift.");
			DisplayName.AddTranslation(GameCulture.German, "Dimensium");
			Tooltip.AddTranslation(GameCulture.German, "Die häufigste dimensionale Energie in Form eines Kristalls, meisten gefunden wenn ein Wesen die Dimensionswand durch einen instabilen Riss durchquert.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.maxStack = 999;
			item.rare = ItemRarityID.Green;
		}
	}
}
