using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class DesertEagle : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 60;
			Item.height = 56;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 10;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -5);
		}
	}
}