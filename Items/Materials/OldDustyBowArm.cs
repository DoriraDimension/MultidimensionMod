using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldDustyBowArm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Dusty Bow Arm (Bottom)");
			Tooltip.SetDefault("A rusty and dusty Bow Arm found inside a Sandstone Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alter verstaubter Bogenarm");
			Tooltip.AddTranslation(GameCulture.German, "Ein rostiger und verstaubter Bogenarm der in einer Sandstein Geode gefunden wurde, wer weiß was er mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 14;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
