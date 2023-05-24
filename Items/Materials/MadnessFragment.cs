using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class MadnessFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 15);
			Item.rare = ItemRarityID.Green;
		}
	}
}