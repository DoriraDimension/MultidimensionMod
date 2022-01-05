using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SpooderLexicon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arachnophobia");
			Tooltip.SetDefault("An entire book on how to defeat the fear of spiders, wait... WHY ARE THERE SPIDERS IN THIS BOOK?!\nShoots homing spiders and rarely a high velocity Albino Spider that deals double damage.");
			DisplayName.AddTranslation(GameCulture.German, "Arachnophobia");
			Tooltip.AddTranslation(GameCulture.German, "Ein komplettes Buch darüber wie mein die Angst vor Spinnen besiegt, warte... WARUM SIND DA SPINNEN IN DIESEM BUCH?!\nSchießt verfolgende Spinnen und selten eine super schnelle Albino Spinne die doppelten Schaden zufügt.");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.magic = true;
			item.mana = 5;
			item.width = 36;
			item.height = 32;
			item.useTime = 54;
			item.useAnimation = 54;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 12);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Spooder>();
			item.shootSpeed = 9f;
			item.crit = 8;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(10))
			{
				float speedX2 = speedX * 2.0f;
				float speedY2 = speedY * 2.0f;
				Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<Weeeeeeeee>(), (int)((double)damage * 2.0), knockBack, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
