using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Mushmatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushmatter");
			Tooltip.SetDefault("A juicy piece of Fungi infested flesh, could be useful.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 32;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 8);
			item.rare = ItemRarityID.Blue;
		}
	}
}
