using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Common.Players;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class DrakescaleShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.DrakescaleShield.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow)
            {
				player.statDefense += 2;
				player.endurance += 0.04f;
            }
            player.GetModPlayer<MDPlayer>().DrakeShield = true;

        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FrostScale>(), 5)
			.AddRecipeGroup(RecipeGroupID.IronBar, 8)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}