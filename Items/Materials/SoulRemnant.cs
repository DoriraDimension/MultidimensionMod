using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class SoulRemnant : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 0, 0, 1);
			Item.rare = ItemRarityID.White;
		}
	}
}