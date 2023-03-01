using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishronCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fishron Cleaver");
			// Tooltip.SetDefault("A big cleaver, designed like a mutated ocean creature, it was seen as a sign of strength.\nReleases typhoons on enemy hits.");
		}

		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Melee;
			Item.width = 98;
			Item.height = 94;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 9;
			Item.shoot = ProjectileID.FlaironBubble;
			Item.shootSpeed = 17f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, (int)((double)((float)Item.damage) * 0.2), 0f, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FishCleaver>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 15)
			.AddCondition(Recipe.Condition.NearWater)
			.Register();
		}
	}
}