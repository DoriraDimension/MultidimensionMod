using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class CoralBow : ModItem
	{
		int Shots = 0;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 46;
			Item.useTime = 39;
			Item.useAnimation = 39;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 21f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (Shots == 4)
            {
				float speedX2 = velocity.X * 0.5f;
				float speedY2 = velocity.Y * 0.5f;
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<TideArrowProj>(), (int)((double)damage * 0.5), knockback, player.whoAmI);
			}
			return true;

        }

		public override bool? UseItem(Player player)
		{
			Shots += 1;
			if (Shots >= 5)
			{
				Shots = 0;
			}
			return true;
		}

		public override void AddRecipes()
        {
            CreateRecipe()
			.AddIngredient(ItemID.Starfish, 4)
            .AddIngredient(ItemID.Coral, 9)
            .AddTile(TileID.Anvils)
            .Register();
		}
    }
}
