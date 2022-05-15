using MultidimensionMod.Buffs.Pets;
using MultidimensionMod.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Pets
{
	public class CuteEmoji : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cute Emoji");
			Tooltip.SetDefault("Summons Smiley's adopted son.\nAt some point a young darkling decided to follow and imitate Smiley, thats when he decided to adopt him as his own child.");
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.ZephyrFish);
			Item.shoot = ModContent.ProjectileType<SmileyJr>();
			Item.buffType = ModContent.BuffType<SmileyJrBuff>();
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}