using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class EelMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Front Eel Mask");
			Tooltip.SetDefault("You look super angry with this on.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Lime;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
	}
}