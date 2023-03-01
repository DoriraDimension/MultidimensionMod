using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Lifelight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lifelight");
			// Tooltip.SetDefault("The awakened form of the Light's Bane that shows that even the most evil being can become good.");
		}

		public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 46);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 8;
			Item.shootSpeed = 15;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (14));
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (57));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), Main.MouseWorld, new Vector2(0, 0), ModContent.ProjectileType<LifelightBlade>(), (int)((double)((float)Item.damage) * 0.5f), 0f, Main.myPlayer);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.LightsBane)
			.AddIngredient(ItemID.SunplateBlock, 15)
			.AddIngredient(ItemID.Bone, 4)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}