using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class Mythos : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 49;
			Item.DamageType = DamageClass.Magic;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.knockBack = 4.5f;
			Item.width = 80;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 4, 0, 0);
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<MythosStaff>();
			Item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}