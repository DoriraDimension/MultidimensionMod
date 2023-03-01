using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldTaintedGun : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 52;
			Item.height = 22;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
