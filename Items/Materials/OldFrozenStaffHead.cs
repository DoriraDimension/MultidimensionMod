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
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
