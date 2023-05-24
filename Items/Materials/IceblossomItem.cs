using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials
{
	public class IceblossomItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 9999;
			Item.width = 12;
			Item.height = 14;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.White;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.UseSound = SoundID.Item2;
			Item.consumable = true;
			Item.buffType = 47; //Frozen
			Item.buffTime = 900;
		}
	}
}