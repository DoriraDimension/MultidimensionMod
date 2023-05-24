using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class LonelyWarriorsVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
		}
	}
}