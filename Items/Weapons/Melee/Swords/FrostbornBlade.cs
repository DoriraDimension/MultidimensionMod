using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FrostbornBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frostborn Blade");
			Tooltip.SetDefault("A magic sword from another world, a world beyhond the freezing fog of the Frozen Underworld.\nShoots several frost spikes that inflict Frostbite\nDealing critical hits unleashes more frost spikes from the player.");
		}

		public override void SetDefaults()
		{
			Item.damage = 71;
			Item.DamageType = DamageClass.Melee;
			Item.width = 76;
			Item.height = 76;
			Item.useTime = 23;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<FrostSpike>();
			Item.shootSpeed = 32f;
			Item.crit = 9;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ModContent.ProjectileType<FrostSpike>();

			{
				for (int i = 0; i < 2; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (crit)
			{
				for (int i = 0; i < 3; i++)
				{
					int spike = Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), player.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-5, -3)), ModContent.ProjectileType<FrostSpike>(), (int)((double)((float)Item.damage) * 0.3), 0f, Main.myPlayer);
					Main.projectile[spike].aiStyle = 1;
				}
			}
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.Frostbrand, 1)
			.AddIngredient(ItemID.FrostCore, 3)
			.AddIngredient(ModContent.ItemType<Blight2>(), 3)
			.AddTile(134)
			.Register();
		}
	}
}