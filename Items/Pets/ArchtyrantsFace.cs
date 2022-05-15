using MultidimensionMod.Buffs.Pets;
using MultidimensionMod.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Pets
{
	public class ArchtyrantsFace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Antler");
			Tooltip.SetDefault("Summons a pyhsical apparition of a Demonic being from far beyhond time and space.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish);
			Item.shoot = ModContent.ProjectileType<IgnaenHead>();
			Item.buffType = ModContent.BuffType<IgnaenHeadBuff>();
			Item.width = 42;
			Item.height = 32;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}