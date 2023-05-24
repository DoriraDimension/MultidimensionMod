﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
	public class Socks : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = ItemRarityID.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.wet && !player.lavaWet && !player.honeyWet && !player.immune)
			{
				player.KillMe(PlayerDeathReason.ByCustomReason(player.name + Language.GetTextValue("Mods.MultidimensionMod.DeathMessages.Socks")), 1000.0, 0);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Silk, 10)
			.AddTile(TileID.Loom)
			.Register();
		}
	}
}