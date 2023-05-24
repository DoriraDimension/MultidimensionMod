using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class RoyalBelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.jumpSpeedBoost += 0.50f;
			Player.jumpHeight += 10;
		}
	}
}