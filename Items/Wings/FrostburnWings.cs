using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class FrostburnWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(130, 6f, 2.5f);
		}

		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.40f;
			ascentWhenRising = 0.10f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.100f;
		}
	}
}