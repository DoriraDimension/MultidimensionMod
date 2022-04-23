using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class OldSeaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Sea Crown");
			Tooltip.SetDefault("A old crown found in the ocean, it is guessed that it didnt belong to a king as there are many of these found.");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 89);
			Item.rare = ItemRarityID.LightRed;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
		}
	}
}