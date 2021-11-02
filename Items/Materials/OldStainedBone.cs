using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldStainedBone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Stained Bone");
			Tooltip.SetDefault("A old bone stained with blood found inside a Blood Geode, who knows what it used to be.\nMaybe it can be repaired");
			DisplayName.AddTranslation(GameCulture.German, "Alter befleckter Knochen");
			Tooltip.AddTranslation(GameCulture.German, "Ein alter Blutbefleckter Knochen der in einer Blut Geode gefunden wurde, wer weiß was es mal war.\nKann vielleicht repariert werden.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Gray;
		}
	}
}
