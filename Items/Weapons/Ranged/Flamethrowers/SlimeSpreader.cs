﻿using System.Collections.Generic;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class SlimeSpreader : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Spreader");
			Tooltip.SetDefault("A flamethrower that does not convert gel into fire but instead shoots a deadly spread of slime.\nThe most dangerous slime is a slime with a gun.");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 20;
			Item.useTime = 2;
			Item.useAnimation = 32;
			Item.reuseDelay = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.3f;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GelCloud>();
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Gel;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.BossItem;
				}
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 30f;
				if (Collision.CanHit(position, 3, 3, position + muzzleOffset, -6, 6))
				{
					position += muzzleOffset;
				}

				{
					float rotation = MathHelper.ToRadians(10);
					position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
					for (int i = 0; i < 2; i++)
					{
						Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1))) * .2f;
						Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
					}					
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<KingSlimeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}
