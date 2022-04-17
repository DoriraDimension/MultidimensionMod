using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldMoltenGuard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Molten Guard");
			Tooltip.SetDefault("A rusty and partly molten guard found inside a Magma Geode, who knows what it used to be.\nMaybe it can be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 34;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
