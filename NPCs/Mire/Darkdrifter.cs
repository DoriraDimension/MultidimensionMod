using MultidimensionMod.Items.Critters;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using MultidimensionMod.NPCs.Corruption;
using MultidimensionMod.NPCs.TownNPCs;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.Utilities;

namespace MultidimensionMod.NPCs.Mire
{
    public class Darkdrifter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 20;
            NPC.height = 30;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0;
            NPC.knockBackResist = 0.5f;
            NPC.noGravity = true;
            NPC.catchItem = (short)ModContent.ItemType<DarkdrifterItem>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Darkdrifter")
            });
        }

        public int STOP = 0;

        public override void AI()
        {
            STOP--;
            if (NPC.wet)
            {
                NPC.noGravity = true;
                if (Main.rand.NextBool(180))
                {
                    NPC.velocity.X = Main.rand.Next(-2, 3);
                    NPC.velocity.Y = Main.rand.Next(-2, 3);
                    STOP = 60;
                }
                else if (STOP == 0)
                {
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                }
            }
            if (!NPC.wet)
            {
                NPC.noGravity = false;
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;


        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int dust = ModContent.DustType<BogwoodDust>();
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
            }
            Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.t_Slime, NPC.velocity.X * 0.5f,
                NPC.velocity.Y * 0.5f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D horse = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(horse, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }

    public class DrifterSpawner : ModNPC
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 20;
            NPC.height = 30;
            NPC.defense = 0;
            NPC.lifeMax = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0;
            NPC.knockBackResist = 0.0f;
            NPC.noGravity = true;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Darkdrifter")
            });
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 20, (int)NPC.Center.Y, ModContent.NPCType<Darkdrifter>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 20, (int)NPC.Center.Y, ModContent.NPCType<Darkdrifter>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y + 20, ModContent.NPCType<Darkdrifter>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y - 20, ModContent.NPCType<Darkdrifter>());
        }

        public override void AI()
        {
            NPC.active = false;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<TheLakeDepths>()) && spawnInfo.Water)
            {
                return SpawnCondition.CaveJellyfish.Chance * 0.70f;
            }
            return 0f;
        }
    }
}