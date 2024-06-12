using MultidimensionMod.NPCs.Critters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Critters
{
	internal class BabyGlowmarinItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 34;
			Item.height = 22;
			Item.makeNPC = 360;
			Item.noUseGraphic = true;
			Item.CloneDefaults(ItemID.GlowingSnail);
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.bait = 30;
			Item.makeNPC = (short)ModContent.NPCType<BabyGlowmarin>();
		}
	}
}