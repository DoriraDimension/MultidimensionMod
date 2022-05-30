﻿using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class ScarusFossores : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarus Fossores");
			Tooltip.SetDefault("A pickaxe created from old blueprints found at the shores. The ancient depictions show it being used to carve out holes from reefs.");
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 13;
			Item.pick = 220;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 3;
		}

		public override void AddRecipes()
		{
			 CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddIngredient(ItemID.HallowedBar, 12)
			.AddTile(134)
			.Register();
		}
	}
}