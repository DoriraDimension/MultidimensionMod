using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldTaintedCurseContainer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Tainted Curse Container");
			Tooltip.SetDefault("A rusty container filled with cursed flames, it is found in Decay Geodes and covered in rotten flesh, who knows what it used to be.\nMaybe it can be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 16;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
