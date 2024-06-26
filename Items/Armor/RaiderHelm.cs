﻿using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RaiderHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(0, 0, 40, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 9;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.05f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.RaiderHelm.Lore"))
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

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<RaiderChest>() && legs.type == ModContent.ItemType<RaiderLegs>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Grants knockback immunity\nDamage reduction increases as health lowers\nEnemies are more likely to target you";
			player.noKnockback = true;
			player.aggro += 3;
			player.endurance += (float)(1 - player.statLife / player.statLifeMax) * 0.1f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 5)
			.AddIngredient(ModContent.ItemType<FrostScale>(), 3)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}