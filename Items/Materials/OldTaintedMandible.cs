using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldTaintedMandible : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Tainted Mandible");
			Tooltip.SetDefault("A old rusty mandible found in a Decay Geode that is covered in rotten flesh, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Verdorbener Kiefer");
			Tooltip.AddTranslation(GameCulture.German, "Ein alter rostiger Kiefer der in einer Verwesungs Geode gefunden wurde und in verottetes Fleisch gehüllt ist, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 18;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
