using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldMoltenBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Molten Blade");
			Tooltip.SetDefault("A rusty and partly molten blade found inside a Magma Geode, who knows what it used to be.\nMaybe it can be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 34;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
