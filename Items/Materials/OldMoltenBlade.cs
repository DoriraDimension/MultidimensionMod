using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldMoltenBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Molten Blade");
			Tooltip.SetDefault("A rusty and partly molten blade found inside a Magma Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alte Geschmolzene Klinge");
			Tooltip.AddTranslation(GameCulture.German, "Eine rostige und teilweils geschmolzene Klinge die in einer Magma Geode gefunden wurde, wer weiß was sie mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 34;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
