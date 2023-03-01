using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class GreatToothsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Skeletal Greatsword");
			// Tooltip.SetDefault("How cruel the world is, humans killing humans for nothing.\nSome are especially cruel and process their victims into weapons, just to show off how many they have killed.\nThe sword throws out bones of the former victims on every swing");
		}

		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 82;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.Bone;
			Item.shootSpeed = 7f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, (int)((double)((float)Item.damage) * 0.3), 0f, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.BoneSword)
			.AddIngredient(ItemID.Bone, 150)
			.AddIngredient(ItemID.BoneFeather)
			.AddTile(300)
			.Register();
		}
	}
}