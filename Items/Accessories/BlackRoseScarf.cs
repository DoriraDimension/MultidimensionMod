using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class BlackRoseScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Rose Scarf");
			Tooltip.SetDefault("Roses are as beautiful as they are dangerous.\nGreatly hurts your enemies when they touch you");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 44;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ItemRarityID.Lime;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.ParallelVariant;
				}
			}
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 0.40f;
		}
	}
}