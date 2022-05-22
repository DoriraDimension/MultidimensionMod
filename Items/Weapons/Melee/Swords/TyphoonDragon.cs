using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TyphoonDragon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Typhoon Dragon");
			Tooltip.SetDefault("A sword used by powerful ancient ocean warriors? It may be logical when this weapon is compared to the other weapons from the deep ocean,\nbut this one is kinda odd as it possesses a weird energy inside, not found in any other weapon here.\nShoots mini sharkrons and releases typhoons and more mini sharkrons on enemy hits.");
		}

		public override void SetDefaults()
		{
			Item.damage = 77;
			Item.DamageType = DamageClass.Melee;
			Item.width = 98;
			Item.height = 120;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MiniSharkron;
			Item.shootSpeed = 11f;
			Item.crit = 12;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.ParallelVariant;
				}
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.Typhoon, (int)((double)((float)Item.damage) * 0.5), Main.myPlayer);
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)(float)Item.damage), Main.myPlayer);
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)(float)Item.damage), Main.myPlayer);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/TyphoonDragon_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
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