using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldFrozenStaffHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Frozen Staff Head");
			Tooltip.SetDefault("A rusty and frozen staff head found inside a Frozen Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alter gefrorener Stabkopf");
			Tooltip.AddTranslation(GameCulture.German, "Ein rostiger und gefrorener Stabkopf der in einer Gefrorenen Geode gefunden wurde, wer weiß was er mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
