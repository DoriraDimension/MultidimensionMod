using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
    public class VoidArmWhipTag : ModBuff
    {
        public static readonly int TagDamage = 5;

        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }
    public class TidalWhipTag : ModBuff
    {
        public static readonly int TagDamage = 10;

        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }

    public class ALWhipNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;


            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
            if (npc.HasBuff<VoidArmWhipTag>())
            {
                modifiers.FlatBonusDamage += VoidArmWhipTag.TagDamage * projTagMultiplier;
            }
            if (npc.HasBuff<TidalWhipTag>())
            {
                modifiers.FlatBonusDamage += TidalWhipTag.TagDamage * projTagMultiplier;
            }
        }
    }
}