using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class EleanoraPlushiePlaceable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Goddess Plushie (placeable)");
			Tooltip.SetDefault("The adorable goddess now exists as a marketable plushie.");
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 60;
			Item.maxStack = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Red;
			Item.createTile = ModContent.TileType<EleanoraPlushiePlaced>();
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.overrideColor = MDRarity.Eleanora;
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.FragmentSolar, 10)
			.AddIngredient(ItemID.Silk, 15)
			.AddIngredient(ItemID.SoulofLight, 5)
			.AddTile(134)
			.Register();
		}
	}
}