using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class MadnessFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Madness");
			Tooltip.SetDefault("A fragment of a fragment LOL.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 8);
			Item.rare = ItemRarityID.Green;
		}
	}
}