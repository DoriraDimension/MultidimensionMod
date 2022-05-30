using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class October1Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Monument of the Eternal Bond");
			Tooltip.SetDefault("A monument, dedicated to the dimensional deities eternal soul bond.\nIt is said that soulmates will always find eachother, doesnt matter how far they are away from eachother\n<3");
		}

		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 16;
			Item.maxStack = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Expert;
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<October1>();
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							Item.OverrideColor = new Color(18, 279, 247);
							break;
						case 1:
							Item.OverrideColor = new Color(247, 171, 18);
							break;
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(29)
			.AddIngredient(ItemID.LovePotion)
			.AddIngredient(ItemID.FragmentVortex, 7)
			.AddIngredient(ItemID.FragmentSolar, 7)
			.AddIngredient(ItemID.SoulofLight, 10)
			.AddIngredient(ItemID.SoulofNight, 10)
			.AddTile(134)
			.Register();
		}
	}
}