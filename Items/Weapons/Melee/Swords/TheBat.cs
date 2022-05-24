using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TheBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("All Shattering Bat");
			Tooltip.SetDefault("A old relic in form of a generic baseball bat, but on a much larger scale.\nOnce used to shatter the soul of the dimensional god.\nEnemies will Bleed and burn on hit.\nRight click to shoot multiple fireballs.");
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
			Item.rare = ItemRarityID.Purple;
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
				Item.damage = 359;
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
				Item.damage = 696;
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
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (6));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 600);
			target.AddBuff(BuffID.Bleeding, 600);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				int numberProjectiles = 4 + Main.rand.Next(1);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(18));
					Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{

			CreateRecipe()
			.AddIngredient(ItemID.Pearlwood, 350)
			.AddIngredient(ItemID.FragmentSolar, 50)
			.AddIngredient(ItemID.Meowmere)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}