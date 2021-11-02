using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldFrozenRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Frozen Rod");
			Tooltip.SetDefault("A rusty and frozen rod found inside a Frozen Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alte gefrorene Stange");
			Tooltip.AddTranslation(GameCulture.German, "Eine rostige und gefrorene Stange die in einer Gefrorenen Geode gefunden wurde, wer weiß was sie mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
