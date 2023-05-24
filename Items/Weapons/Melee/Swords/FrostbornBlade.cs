using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FrostbornBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 71;
			Item.DamageType = DamageClass.Melee;
			Item.width = 76;
			Item.height = 76;
			Item.useTime = 33;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 5, 40, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<FrostSpike>();
			Item.shootSpeed = 32f;
			Item.crit = 9;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ModContent.ProjectileType<FrostSpike>();

			{
				for (int i = 0; i < 2; i++)
				{
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);
					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}
			}
			return true;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{

		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.Frostbrand, 1)
			.AddIngredient(ModContent.ItemType<Prismatine>(), 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}