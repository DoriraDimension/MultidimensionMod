using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class QueensKunai : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Queen's Kunai");
			// Tooltip.SetDefault("Throws kunais that summon a sparkling energy circle on impact.");
		}


		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<QueenKunai>();
			Item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<WomanSlimeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}