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
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 14;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
