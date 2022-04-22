using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class EleanoraBodypillowItem : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Dimensional Goddess Bodypillow");
			Tooltip.SetDefault("A Dimensional Goddess Bodypillow for your bedroom.");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 48;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.sellPrice(silver: 69);
			Item.createTile = ModContent.TileType<Tiles.EleanoraBodypillow>();
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
			.AddIngredient(ItemID.Silk, 69)
			.AddIngredient(ItemID.LivingFireBlock, 69)
			.AddTile(TileID.Loom)
			.Register();
		}
	}
}