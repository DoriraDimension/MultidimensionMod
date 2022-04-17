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
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
