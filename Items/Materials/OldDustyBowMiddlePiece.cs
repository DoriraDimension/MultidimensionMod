using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldDustyBowMiddlePiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Dusty Bow Arm (Top)");
			Tooltip.SetDefault("A rusty and dusty center piece of a bow found inside a Sandstone Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Altes verstaubtes Bogen Mittelstück");
			Tooltip.AddTranslation(GameCulture.German, "Ein rostiges und verstaubtes Bogen Mittelstück das in einer Sandstein Geode gefunden wurde, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 28;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
