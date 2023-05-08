using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class VoidArm : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(silver: 24);
			Item.rare = ItemRarityID.Orange;
			Item.DefaultToWhip(ModContent.ProjectileType<VoidArmProj>(), 37, 6, 20);
			Item.shootSpeed = 6;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SwordWhip)
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