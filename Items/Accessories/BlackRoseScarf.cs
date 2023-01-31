using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class BlackRoseScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Rose Scarf");
			Tooltip.SetDefault("Roses are as beautiful as they are dangerous.\nReflects 45% of damage back to the enemy if they touch you\nThis text will be replaced by the hotkey tooltip\nWhile under the effects of the toxins, you gain a 25% buff to your damage reflection as well as 20 defense");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 44;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ModContent.RarityType<ForbiddenArtifact>();
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			List<string> hotkey = MDKeybinds.RoseScarfKey.GetAssignedKeys();
			foreach (TooltipLine line2 in list)
			{
				if (line2.Mod == "Terraria" && line2.Name == "Tooltip2")
				{
					line2.Text = "Press " + hotkey + " to imbue yourself with deadly toxins that eat away at your health in exchange for powerful thorns and defense";
				}
			}
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().RoseScarf = true;
			player.thorns = 0.45f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ThornScarf>())
			.AddIngredient(ItemID.VialofVenom, 2)
			.AddIngredient(ItemID.BlackFairyDust, 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}