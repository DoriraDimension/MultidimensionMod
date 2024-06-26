﻿using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Globals.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class SunlightButterfly : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 82;
			Item.height = 76;
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item60;
			Item.consumable = false;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.SunlightButterfly.Lore"))
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

        public override bool? UseItem(Player player)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				Main.dayTime = true;
				Main.time = 0;
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 8)
			.AddIngredient(ItemID.Daybloom, 3)
			.AddRecipeGroup(Recipes.EvilSample, 6)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}