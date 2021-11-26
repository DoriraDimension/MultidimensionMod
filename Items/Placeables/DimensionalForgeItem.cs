using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class DimensionalForgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Forge");
			Tooltip.SetDefault("The forge of the dimensional god, it is able to craft items with Dimensium.\nIs capable of transmutation, needs Dimensium as fuel.");
			DisplayName.AddTranslation(GameCulture.German, "Dimensionale Schmiede");
			Tooltip.AddTranslation(GameCulture.German, "Die Schmiede des Dimensionsgottes, es ist fähig Gegenstände aus Dimensium herzustellen.\nIst zur Transmutation fähig, braucht Dimensium als Kraftstoff.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Cyan;
			item.createTile = ModContent.TileType<Tiles.DimensionalForge>();
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Dorira;
				}
			}
		}
	}
}