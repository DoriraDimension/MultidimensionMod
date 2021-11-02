using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldStainedFleshStick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Stained Flesh Stick");
			Tooltip.SetDefault("A old piece of flesh stained with blood found inside a Blood Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alter befleckter Fleischstock");
			Tooltip.AddTranslation(GameCulture.German, "Ein altes Blutbeflecktes stück Fleisch der in einer Blut Geode gefunden wurde, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 22;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
