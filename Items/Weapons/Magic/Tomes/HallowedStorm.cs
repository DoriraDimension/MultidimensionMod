using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class HallowedStorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.knockBack = 1f;
			Item.mana = 6;
			Item.width = 34;
			Item.height = 38;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item9;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<PrismShards>();
			Item.channel = true;
		}

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 20;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, new Vector2(player.Center.X + (float)Main.rand.Next(-60, 60), player.Center.Y + (float)Main.rand.Next(-60, 60)), velocity, type, damage, knockback, Main.myPlayer);
			return false;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			position = player.position;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.CrystalStorm)
			.AddIngredient(ModContent.ItemType<Prismatine>(), 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}