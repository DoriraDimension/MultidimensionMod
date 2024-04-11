using MultidimensionMod.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace MultidimensionMod.Buffs.Pets
{
    public class BrothersBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            if (player.whoAmI == Main.myPlayer)
            {
                List<int> pets = new List<int> { ModContent.ProjectileType<FeudalBab>(), ModContent.ProjectileType<MonarchBab>() };
                foreach (int they in pets)
                    if (player.ownedProjectileCounts[they] <= 0)
                        Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, they, 0, 0f, player.whoAmI);
            }
        }
    }
}