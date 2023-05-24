using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class RetinusBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 340;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.knockBack = 0f;
			Item.UseSound = SoundID.Item8;
			Item.width = 80;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<RetinusBlasterHoldOut>();
			Item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.ownedProjectileCounts[Item.shoot] < 6;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HallowedBar, 15)
			.AddIngredient(ItemID.SoulofSight, 8)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}