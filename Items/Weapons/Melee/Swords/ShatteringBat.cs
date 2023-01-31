using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class ShatteringBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("All Shattering Bat");
			Tooltip.SetDefault("\nEnemies will be confused on hit.\nRight click fires Onyx Shots.\nIt may seem like a generic wooden bat, but this is actually a forbidden artifact\nIt was forged in ancient times, using a extinct form of energy");
		}

		public override void SetDefaults()
		{
			Item.damage = 700;
			Item.DamageType = DamageClass.Melee;
			Item.width = 94;
			Item.height = 94;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(gold: 70);
			Item.rare = ModContent.RarityType<ForbiddenArtifact>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 70; 
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.damage = 245;
				Item.DamageType = DamageClass.Melee;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.useTime = 35;
				Item.useAnimation = 35;
				Item.knockBack = 6;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;
				Item.shoot = ProjectileID.ApprenticeStaffT3Shot;
				Item.shootSpeed = 13f;
				Item.crit = 69;
			}
			else
			{
				Item.damage = 700;
				Item.DamageType = DamageClass.Melee;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.knockBack = 15;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;
				Item.crit = 69;
				Item.shoot = ProjectileID.None;
			}
			return base.CanUseItem(player);
		}


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Smoke);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Confused, 100);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.BlackBolt;
				int numberProjectiles = 8 + Main.rand.Next(1);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(40));
					Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{

			CreateRecipe()
			.AddIngredient(ModContent.ItemType<WoodenBat>())
			.AddIngredient(ItemID.Ebonwood, 300)
			.AddIngredient(ItemID.SoulofNight, 23)
			.AddIngredient(ItemID.LunarBar, 20)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 30)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}