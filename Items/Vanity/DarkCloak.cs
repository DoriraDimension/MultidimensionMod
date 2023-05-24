using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Front)]
	public class DarkCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 46;
			Item.accessory = true;
			Item.vanity = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 0, 0);
		}
	}
}
