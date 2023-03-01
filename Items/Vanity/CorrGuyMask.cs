using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class CorrGuyMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Infested Abomination Mask");
			// Tooltip.SetDefault("Does not include flies.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
	}
}