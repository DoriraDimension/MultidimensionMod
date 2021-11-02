using MultidimensionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StormScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Scepter");
			Tooltip.SetDefault("Unfinished item, future Storm Eel drop");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.DaedalusStormbow);
			item.shootSpeed *= 0.65f;
			item.damage = 63;
			item.magic = true;
			item.noMelee = true;
			item.mana = 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<StormDroplet>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}