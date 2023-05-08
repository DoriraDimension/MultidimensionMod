using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class EuniceFlagellum : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(silver: 24);
			Item.rare = ItemRarityID.Yellow;
			Item.DefaultToWhip(ModContent.ProjectileType<Eunice>(), 100, 6, 26);
			Item.shootSpeed = 6;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SwordWhip)
				.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}