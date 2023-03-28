using MultidimensionMod.Projectiles.Magic;
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

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class NeuralWaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
		}


		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<NeuralWave>();
			Item.shootSpeed = 10f;
			Item.crit = 8;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 18; i++)
			{
				int numProj = 2;
				float rotation = MathHelper.ToRadians(50f);
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
				Projectile.NewProjectile(source, player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<NeuralWave>(), damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}