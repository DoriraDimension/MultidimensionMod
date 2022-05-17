using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TundranaScythe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tundrana Scythe");
			Tooltip.SetDefault("A scythe created by an ice elemental from another dimension, it's extremely cold.");
		}

		public override void SetDefaults()
		{
			Item.damage = 79;
			Item.DamageType = DamageClass.Melee;
			Item.width = 76;
			Item.height = 60;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.IceSickle;
			Item.shootSpeed = 10f;
			Item.reuseDelay = 14;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			{
				type = Main.rand.Next(new int[] { type, ProjectileID.FrostBoltSword, ProjectileID.IceSickle });
			}

			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}
			}
			return true;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.IceSickle, 1)
			.AddIngredient(ItemID.FrostCore, 2)
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddTile(134)
			.Register();
		}
	}
}