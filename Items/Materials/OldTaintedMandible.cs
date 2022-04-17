using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldTaintedMandible : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Tainted Mandible");
			Tooltip.SetDefault("A old rusty mandible found in a Decay Geode that is covered in rotten flesh, who knows what it used to be.\nMaybe it can be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 18;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
