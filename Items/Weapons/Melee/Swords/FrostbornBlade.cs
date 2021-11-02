using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FrostbornBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frostborn Blade");
			Tooltip.SetDefault("Ice created by an elemental from an unknown dimension, shaped into a perfect blade.");
			DisplayName.AddTranslation(GameCulture.German, "Frostgeborene Klinge");
			Tooltip.AddTranslation(GameCulture.German, "Eis das von einem Elementar aus einer unbekannten Dimension geschaffen und in eine perfekte Klinge geformt wurde.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.EnchantedSword);
			item.damage = 65;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.knockBack = 6;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.crit = 26;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ProjectileID.FrostBoltSword;

			{
				int numberProjectiles = 3 + Main.rand.Next(1); 
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); 																																																																																					 
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Frostbrand, 1);
			recipe.AddIngredient(ItemID.FrostCore, 3);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 3);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}