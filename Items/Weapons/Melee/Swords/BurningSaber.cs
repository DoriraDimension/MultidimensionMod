using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class BurningSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Saber");
			Tooltip.SetDefault("A saber that was restored from old relics, it shoots fireballs and sets enemies on fire.");
			DisplayName.AddTranslation(GameCulture.German, "Brennender Säbel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Säbel der aus alten Relikten restauriert wurde, es schießt Feuerbälle und setzt Gegner in Brand.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BeamSword);
			item.shootSpeed *= 0.75f;
			item.width = 60;
			item.height = 68;
			item.damage = 45;
			item.melee = true;
			item.value = Item.sellPrice(silver: 90);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;

		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RelicWeapon;
				}
			}
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
			target.AddBuff(BuffID.OnFire, 300);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ProjectileID.BallofFire;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldMoltenBlade>());
			recipe.AddIngredient(ModContent.ItemType<OldMoltenGuard>());
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}