using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class BurningSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellfire Saber");
			Tooltip.SetDefault("A saber that was restored from old relics, spawns small fire clouds on hit.");
		}

		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 52;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 90);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

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
			{
				Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.Center.X, target.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<Explosion>(), (int)((double)((float)Item.damage) * 0.2), 0f, Main.myPlayer);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldPetrifiedBlade>())
			.AddIngredient(ItemID.HellstoneBar, 15)
			.AddTile(377)
			.Register();
		}
	}
}