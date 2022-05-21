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
			Tooltip.SetDefault("A juicy piece of Fungi infested flesh, could be useful.\nIt's somewhat terrifying how these glowing mushrooms can infect every living thing if they arent careful enough,\nmaybe a problem that should be dealed with before it gets out of hand.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 8);
			Item.rare = ItemRarityID.Blue;
		}
	}
}
