using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using MultidimensionMod.Dusts;

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

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 8; i++)
			{
                Vector2 perturbedSpeed = new Vector2(velocity.X / 2, velocity.Y / 2).RotatedByRandom(MathHelper.ToRadians(8));
                int dust = Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<DesertEagleFeather>(), perturbedSpeed.X + Main.rand.Next(4), perturbedSpeed.Y);
            }
			return true;
        }
	}
}