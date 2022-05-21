using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldFrozenStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Frozen Staff");
			Tooltip.SetDefault("A frozen staff that has lost its magic abilities.\nWith some love and craftmanship it could be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
