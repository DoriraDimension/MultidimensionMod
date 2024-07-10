using MultidimensionMod.Common.Players;
using MultidimensionMod.Projectiles.Summon.Sentries;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
    public class TwinPrayerBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Summon) += 0.8f;
            player.GetModPlayer<MDPlayer>().TwinPrayer = true;
        }
    }
    public class TwinPrayerNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[projectile.owner];
            if (player.HasBuff<TwinPrayerBuff>() && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                if (Main.rand.NextBool(10))
                {
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Star, noGrabDelay: true);
                }
                if (Main.rand.NextBool(20))
                {
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Heart, noGrabDelay: true);
                }
            }
        }
    }
}