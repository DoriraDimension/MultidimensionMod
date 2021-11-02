using System.Collections.Generic;
using Microsoft;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class EclipseReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eclipse Reaper");
			Tooltip.SetDefault("A scythe said to bear incredible power, it was sealed away and hoped to be forgotten.");
			DisplayName.AddTranslation(GameCulture.German, "Eklipsen Schnitter");
			Tooltip.AddTranslation(GameCulture.German, "Eine Sense von der gesagt wird das sie unglaubliche Kraft besitzt, sie wurde versiegelt mit der Hoffnung das sie vergessen wird.");
		}

		public override void SetDefaults()
		{
			item.damage = 72;
			item.melee = true;
			item.width = 68;
			item.height = 70;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 6;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item71;
			item.crit = 10;
			item.shoot = ProjectileID.DeathSickle;
			item.shootSpeed = 50f;
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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(1); 
			float rotation = MathHelper.ToRadians(25);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}