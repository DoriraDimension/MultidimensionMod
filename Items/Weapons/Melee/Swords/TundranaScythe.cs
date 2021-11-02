using MultidimensionMod.Items.Materials;
using Microsoft;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TundranaScythe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tundrana Scythe");
			Tooltip.SetDefault("A scythe created by an ice elemental from another dimension, it's extremely cold.");
			DisplayName.AddTranslation(GameCulture.German, "Tundrana Sense");
			Tooltip.AddTranslation(GameCulture.German, "Eine Sense die von einem Eis Elementar aus einer anderen Dimension erschaffen wurde, sie ist extrem kalt.");
		}

		public override void SetDefaults()
		{
			item.damage = 79;
			item.melee = true;
			item.width = 76;
			item.height = 60;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileID.IceSickle;
			item.shootSpeed = 10f;
			item.reuseDelay = 14;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			{
				type = Main.rand.Next(new int[] { type, ProjectileID.FrostBoltSword, ProjectileID.IceSickle });
			}

			{
				int numberProjectiles = 4 + Main.rand.Next(1);
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
			recipe.AddIngredient(ItemID.IceSickle, 1);
			recipe.AddIngredient(ItemID.FrostCore, 2);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}