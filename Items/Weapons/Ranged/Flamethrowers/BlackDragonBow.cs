using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class BlackDragonBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 80;
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 64; 
			Item.height = 100;
			Item.useTime = 3;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.UseSound = SoundID.Item34; 
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ShradesDemise>();
			Item.shootSpeed = 40f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ModContent.ProjectileType<ShradesDemise>();
			if (player.statLife <= player.statLifeMax2 / 2)
            {
				type = ModContent.ProjectileType<ShradesDemisePhase2>();
            }
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 30f;
			if (Collision.CanHit(position, 3, 3, position + muzzleOffset, -6, 6))
			{
				position += muzzleOffset;
			}

			{
				float numberProjectiles = 6 + Main.rand.Next(1);
				float rotation = MathHelper.ToRadians(35);
				position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 60f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
					Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage * 2, knockback, player.whoAmI);
				}
				return false;
			}
		}

		public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
			if (player.statLife <= player.statLifeMax2 / 2)
            {
				damage *= 0.5f;
            }
        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.MoltenFury)
			.AddIngredient(ItemID.Flamethrower)
			.AddIngredient(ItemID.LunarBar, 10)
			.AddIngredient(ItemID.SoulofFright, 30)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}