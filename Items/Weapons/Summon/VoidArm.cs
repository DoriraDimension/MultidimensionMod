﻿using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class VoidArm : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = ItemRarityID.Orange;
			Item.DefaultToWhip(ModContent.ProjectileType<VoidArmProj>(), 37, 6, 20);
			Item.shootSpeed = 6;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
				.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}