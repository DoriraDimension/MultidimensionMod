using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class RotSpit : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 86;
			Item.height = 24;
			Item.useTime = 90;
			Item.useAnimation = 90;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 1, 40, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.NPCDeath13;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RottenSpit>();
			Item.shootSpeed = 65f;
			Item.crit = 13;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}