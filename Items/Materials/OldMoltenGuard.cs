using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldMoltenGuard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Molten Guard");
			Tooltip.SetDefault("A rusty and partly molten guard found inside a Magma Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alte Geschmolzener Griff");
			Tooltip.AddTranslation(GameCulture.German, "Ein rostiger und teilweils geschmolzener Schwertgriff der in einer Magma Geode gefunden wurde, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 34;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
