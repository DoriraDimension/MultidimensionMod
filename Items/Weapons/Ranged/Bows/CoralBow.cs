using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class CoralBow : ModItem
	{
		int Shots = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Bow");
			Tooltip.SetDefault("This is bow ma boy.");
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 46;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(copper: 34);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 21f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (Shots == 3)
            {
				float speedX2 = velocity.X * 0.5f;
				float speedY2 = velocity.Y * 0.5f;
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ProjectileID.WaterBolt, (int)((double)damage * 0.5), knockback, player.whoAmI);
			}
			return true;

        }

		public override bool? UseItem(Player player)
		{
			Shots += 1;
			if (Shots >= 4)
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
