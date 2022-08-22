using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class DiggerEngine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Digger Engine");
			Tooltip.SetDefault("A excavator engine used in the Destroyer to mine minerals incredibly fast.\nIncreases mining speed by 50% and spawns friendly Probes when you get hit.");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 12);
			Item.rare = ItemRarityID.Pink;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.BossItem;
				}
			}
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed += 0.50f;
			player.GetModPlayer<MDPlayer>().Probe = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<MetalWormSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 15)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.AddTile(134)
			.Register();
		}
	}
}