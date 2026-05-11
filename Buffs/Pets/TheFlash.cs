using MultidimensionMod.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Buffs.Pets
{
    public class TheFlash : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.05f;
            player.buffTime[buffIndex] = 18000;

            int projType = ModContent.ProjectileType<Flash>();
            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
                var entitySource = player.GetSource_Buff(buffIndex);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
            }
        }
    }
}