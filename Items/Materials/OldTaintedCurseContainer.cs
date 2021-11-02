using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldTaintedCurseContainer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Tainted Curse Container");
			Tooltip.SetDefault("A rusty container filled with cursed flames, it is found in Decay Geodes and covered in rotten flesh, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Verdorbener Fluch Behälter");
			Tooltip.AddTranslation(GameCulture.German, "Ein rostiger Behälter der mit verfluchten Flammen gefüllt ist, er wurde in einer Verwesungs Geode gefunden und ist in verottetes Fleisch gehüllt, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 16;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
