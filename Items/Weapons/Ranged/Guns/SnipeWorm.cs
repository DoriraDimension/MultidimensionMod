using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class SnipeWorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snipe Worm");
			// Tooltip.SetDefault("A sniper rifle that was restored from old relics, it has rotten skin around its metal.\nConverts normal bullets into Cursed Bullets.");
		}

		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 22;
			Item.useTime = 52;
			Item.useAnimation = 52;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 23);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 10;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldTaintedGun>())
			.AddIngredient(ItemID.ShadowScale, 20)
			.AddTile(377)
			.Register();
		}
	}
}
