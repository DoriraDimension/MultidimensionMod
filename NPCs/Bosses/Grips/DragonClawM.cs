using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Bosses.Grips
{
    public class DragonClawM : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dragon Claw");
            Main.npcFrameCount[NPC.type] = 5;
        }
        public override void SetDefaults()
        {
            AIType = NPCID.DemonEye;
            AnimationType = NPCID.DemonEye;
            NPC.width = 28;
            NPC.height = 24;
            NPC.friendly = false;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 20;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0f;
            NPC.knockBackResist = 0.6f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
        }

        public override void AI()
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<GripOfChaosRed>()) && !NPC.AnyNPCs(ModContent.NPCType<GripOfChaosBlue>()))
            {
                NPC.alpha += 10;
                if (NPC.alpha > 255)
                {
                    NPC.active = false;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/DragonClawGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/DragonClawGore2").Type, 1);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}