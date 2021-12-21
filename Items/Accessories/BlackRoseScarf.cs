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
			DisplayName.AddTranslation(GameCulture.German, "Schwarzer Rosen Schal");
			Tooltip.AddTranslation(GameCulture.German, "Rosen sind so schön wie sie gefährlich sind.\nVerletzt Gegner wenn sie dich berühren schwer.");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 44;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 7);
			item.rare = ItemRarityID.Lime;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RareVariant;
				}
			}
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 0.40f;
			player.endurance += 0.10f;
		}
	}
}