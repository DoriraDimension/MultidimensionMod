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
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 28;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
