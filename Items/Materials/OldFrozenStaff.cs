using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Materials
{
	public class OldFrozenStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 36;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 0, 0, 40);
			Item.rare = ItemRarityID.Gray;
		}
	}
}
