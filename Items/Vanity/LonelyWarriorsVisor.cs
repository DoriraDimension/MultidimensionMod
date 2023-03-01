using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class LonelyWarriorsVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lonely Warrior's Visor");
			// Tooltip.SetDefault("The Visor of a dark warrior.");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 12;
			Item.value = Item.sellPrice(silver: 70);
			Item.rare = ItemRarityID.LightRed;
			Item.vanity = true;
			ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
		}
	}
}