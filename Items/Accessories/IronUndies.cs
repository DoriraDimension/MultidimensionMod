using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class IronUndies : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 16;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}
	}
}