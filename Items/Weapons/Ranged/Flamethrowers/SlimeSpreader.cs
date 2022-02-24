using System.Collections.Generic;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class SlimeSpreader : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Spreader");
			Tooltip.SetDefault("A flamethrower that does not convert gel into fire but instead shoots a deadly spread of slime.\nThe most dangerous slime is a slime with a gun.");
			DisplayName.AddTranslation(GameCulture.German, "Schleim Verteiler");
			Tooltip.AddTranslation(GameCulture.German, "Ein Flammenwerfer der Glibber nicht in Feuer umwandelt aber stattdessen tödlichen Schleim schießt.\nDer gefährlichste Schleim ist ein Schleim mit einer Knarre");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.ranged = true;
			item.width = 42;
			item.height = 26;
			item.useTime = 2;
			item.useAnimation = 32;
			item.reuseDelay = 41;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0.3f;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Gel;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.BossWeapon;
				}
			}
		}

		public override bool ConsumeAmmo(Player player)
		{
			return player.itemAnimation >= player.itemAnimationMax - 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
				if (Collision.CanHit(position, 3, 3, position + muzzleOffset, -6, 6))
				{
					position += muzzleOffset;
				}

				{
					float rotation = MathHelper.ToRadians(10);
					position += Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
					for (int i = 0; i < 2; i++)
					{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1))) * .2f;
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					}					
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KingSlimeSoul>(), 4);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 10);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
