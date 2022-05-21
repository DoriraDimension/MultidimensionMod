using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldStainedScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Stained Scythe");
			Tooltip.SetDefault("A old scythe made out of flesh, stained with blood.\nWith some love and craftmanship it could be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 38;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
