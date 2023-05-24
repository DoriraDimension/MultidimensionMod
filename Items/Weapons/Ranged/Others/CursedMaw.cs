using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class CursedMaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.reuseDelay = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 0, 85, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<CursedBlast>();
			Item.shootSpeed = 10f;
			Item.crit = 4;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RottenChunk, 20)
			.AddIngredient(ItemID.CursedFlame, 8)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
