using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class SmileyMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley Mask");
			Tooltip.SetDefault("Maybe if you disguise as him, the Darklings wont attack you anymore.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 70);
			Item.rare = ItemRarityID.LightRed;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;

		}
	}
}