﻿using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class SidanesQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sidane's Quiver");
			Tooltip.SetDefault("The magitech quiver owned by the creator Sidane.\nSidane is one of the less serious members of the creator council, he would sometimes fly around on a hoverboard and use others inventions as targets for training.\nIncreases arrow damage by 10%, ranged damage by 10% and greatly increases arrow speed \n20% chance to not consume arrows.");
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.10f;
			player.magicQuiver = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.MagicQuiver)
			.AddIngredient(ItemID.RangerEmblem)
			.AddIngredient(ModContent.ItemType<Blight2>(), 2)
			.AddTile(134)
			.Register();
		}
	}
}