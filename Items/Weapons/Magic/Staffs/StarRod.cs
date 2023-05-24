using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StarRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.width = 26;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.knockBack = 2f;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 15, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.mana = 4;
			Item.shoot = ModContent.ProjectileType<PoyoStar>();
			Item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceiling = target.Y;
			if (ceiling > player.Center.Y - 200f)
			{
				ceiling = player.Center.Y - 200f;
			}
			for (int i = 0; i < 1; i++)
            {
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceiling);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.FallenStar)
			.AddRecipeGroup(RecipeGroupID.Wood, 5)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}