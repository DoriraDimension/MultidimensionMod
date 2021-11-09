using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TyphoonDragon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Typhoon Dragon");
			Tooltip.SetDefault("A sword used by powerful ancient ocean warriors? It may be logical when this weapon is compared to the other weapons from the deep ocean,\nbut this one is kinda odd as it possesses a weird energy inside, not found in any other weapon here.\nShoots mini sharkrons and releases typhoons and more mini sharkrons on enemy hits.");
			DisplayName.AddTranslation(GameCulture.German, "Taifun Drache");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert das von mächtigen Ozean Kriegern benutzt wurde? Es wäre vielleicht logisch wenn es mit den anderen Waffen des tiefen Ozeans verglichen wird,\naber dieses hier ist etwas seltsam weil es eine Energie besitzt die in keiner anderen Waffe gefunden wird.\nVerschießt Mini Sharkrons und verschießt mehr Mini Sharkrons und Taifune wenn Gegenr getroffen werden.");
		}

		public override void SetDefaults()
		{
			item.damage = 77;
			item.melee = true;
			item.width = 98;
			item.height = 120;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.MiniSharkron;
			item.shootSpeed = 6f;
			item.crit = 12;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RareVariant;
				}
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.Typhoon, (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.MiniSharkron, (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/Melee/Swords/TyphoonDragon_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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