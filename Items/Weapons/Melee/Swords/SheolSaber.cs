using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class SheolSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sheol Saber");
			// Tooltip.SetDefault("A old relic augmented with demon powers, unleashes a hellish explosion on hit and has a chance to unleash several demon scythes.");
		}

		public override void SetDefaults()
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 72;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (296));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.Center.X, target.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<DemonExplosion>(), (int)((double)((float)Item.damage) * 0.3), 0f, Main.myPlayer);
			if (Main.rand.Next(4) == 0)
            {
				for (int i = 0; i < 4; i++)
				{
					Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-9, 10)), ProjectileID.DemonScythe, (int)((double)((float)Item.damage) * 0.3f), 0f, Main.myPlayer);
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
		    .AddIngredient(ModContent.ItemType<BurningSaber>())
			.AddIngredient(ItemID.DemoniteBar, 20)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ModContent.ItemType<Blight2>())
			.AddTile(134)
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/SheolSaber_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}