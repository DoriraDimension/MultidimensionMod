using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class BlackDragonBow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Fires a high damage Dragonpiercer.\nRight click to shoot a wide spread of flames to incinerate your enemies.\nFatalis, Fatalis, heaven and earth are yours.");
		}

		public override void SetDefaults() {
			Item.damage = 340;
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 64; 
			Item.height = 100; 
			Item.useTime = 80; 
			Item.useAnimation = 80;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 30);
			Item.rare = ModContent.RarityType<ForbiddenArtifact>();
			Item.UseSound = SoundID.Item5; 
			Item.autoReuse = true; 
			Item.shoot = 10; 
			Item.shootSpeed = 120f; 
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 44;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.MoltenFury)
			.AddIngredient(ItemID.LunarBar, 10)
			.AddIngredient(ItemID.SoulofFright, 30)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 4;
				Item.useAnimation = 20;
				Item.UseSound = SoundID.Item34;
				Item.autoReuse = true;
				Item.damage = 98;
				Item.shoot = ModContent.ProjectileType<ShradesDemise>();
				Item.shootSpeed = 40f;
			}
			else
			{
				Item.damage = 1200;
				Item.DamageType = DamageClass.Ranged;
				Item.useTime = 80;
				Item.useAnimation = 80;
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.noMelee = true;
				Item.knockBack = 4;
				Item.UseSound = SoundID.Item5;
				Item.autoReuse = true;
				Item.shoot = 10;
				Item.shootSpeed = 120f;
				Item.useAmmo = AmmoID.Arrow;
				Item.crit = 30;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
            {
				type = ModContent.ProjectileType<ShradesDemise>();

				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 30f;
				if (Collision.CanHit(position, 3, 3, position + muzzleOffset, -6, 6))
				{
					position += muzzleOffset;
				}

				{
					float numberProjectiles = 10 + Main.rand.Next(1);
					float rotation = MathHelper.ToRadians(45);
					position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 60f;
					for (int i = 0; i < numberProjectiles; i++)
					{
						Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
						Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
					}
					return false;
				}
			}
			return true;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Dragonpiercer>();
		}
	}
}