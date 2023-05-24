using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class GreatToothsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 82;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 2, 0, 80);
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
					Projectile.NewProjectileDirect(source, position, newVelocity, type, (int)((double)((float)Item.damage) * 0.5), 0f, player.whoAmI);
				}
			}
			return false;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.BoneSword)
			.AddIngredient(ItemID.Bone, 110)
			.AddIngredient(ItemID.Ectoplasm, 5)
			.AddTile(TileID.BoneWelder)
			.Register();
		}
	}
}