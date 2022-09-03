using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class EclipseReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eclipse Reaper");
			Tooltip.SetDefault("The reapers that appear during the eclipse are followers of the Dimensional Death,\nfar down the line as the most unimportant servants,\ntho some of them have the honor to wield a scythe with incredible power");
		}

		public override void SetDefaults()
		{
			Item.damage = 62;
			Item.DamageType = DamageClass.Melee;
			Item.width = 68;
			Item.height = 70;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item71;
			Item.crit = 10;
			Item.shoot = ProjectileID.DeathSickle;
			Item.shootSpeed = 50f;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.ForbiddenArtifact;
				}
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(30);

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			return false; 
		}
	}
}