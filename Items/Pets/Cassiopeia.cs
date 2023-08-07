using MultidimensionMod.Projectiles.Pets;
using MultidimensionMod.Buffs.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Pets
{
	public class Cassiopeia : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
            Item.DefaultToVanitypet(ModContent.ProjectileType<Cosima>(), ModContent.BuffType<CosimaBuff>());
            Item.width = 12;
			Item.height = 12;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Expert;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
    }
}