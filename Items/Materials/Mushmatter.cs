using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Mushmatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 30);
			Item.rare = ItemRarityID.Green;
		}
	}
}
