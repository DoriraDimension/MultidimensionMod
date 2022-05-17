using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FrostbornBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frostborn Blade");
			Tooltip.SetDefault("Ice created by an elemental from an unknown dimension, shaped into a perfect blade.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.EnchantedSword);
			Item.damage = 71;
			Item.DamageType = DamageClass.Melee;
			Item.width = 70;
			Item.height = 70;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.crit = 26;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileID.FrostBoltSword;

			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.Frostbrand, 1)
			.AddIngredient(ItemID.FrostCore, 3)
			.AddIngredient(ModContent.ItemType<Blight2>(), 3)
			.AddTile(134)
			.Register();
		}
	}
}