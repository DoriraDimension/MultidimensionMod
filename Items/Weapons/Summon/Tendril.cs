using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class Tendril : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tendril Whip");
			// Tooltip.SetDefault("You can maybe eat it later...");
		}

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.width = 30;
			Item.height = 34;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Blue;
			Item.DefaultToWhip(ModContent.ProjectileType<TendrilWhip>(), 12, 1, 2);
			Item.shootSpeed = 4;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<EyeTendril>(), 4)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}
