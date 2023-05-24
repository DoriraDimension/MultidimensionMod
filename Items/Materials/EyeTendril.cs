using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class EyeTendril : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.White;
		}
	}
}
