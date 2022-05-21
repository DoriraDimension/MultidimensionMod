using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldPetrifiedBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Petrified Blade");
			Tooltip.SetDefault("A blade that lost its fiery magic and turned to stone.\nWith some love and craftmanship it could be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 42;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
