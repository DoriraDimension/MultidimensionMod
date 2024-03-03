using MultidimensionMod.Biomes;
using MultidimensionMod.Dusts;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class ShroomJelly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mushroom Jelly");
            Main.npcFrameCount[NPC.type] = 11;
		}

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 26;
            NPC.height = 26;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.lifeMax = 160;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.knockBackResist = 0.8f;
            NPC.value = 1000f;
            NPC.npcSlots = 0.3f;
            Banner = NPC.type;
            //BannerItem = ModContent.ItemType<ShroomJellyBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.ShroomJelly")
            });
        }

        public int JellyTimer = 0;

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Dash"), NPC.position);
        }

        public override void AI()
        {
            NPC.velocity.X = 0;
            God++;
            if (God >= 120)
            {
                God = 120;
            }
            if (JellyTimer <= 15)
            {
                JellyTimer++;
                NPC.velocity.Y = -3f;
            }
            else if (JellyTimer >= 15 && JellyTimer < 30)
            {
                JellyTimer++;
                NPC.velocity.Y = -1.5f;
            }
            else if (JellyTimer >= 30)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y += 0.1f;
                }
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = 0f;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 7.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= 10 * frameHeight)
                {
                    NPC.frame.Y = 0 * frameHeight;
                }
            }
        }

        public int God = 0;

        public override bool? CanBeHitByProjectile(Projectile projectile) => God < 120 ? false : null;
        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => God < 120 ? false : true;

        public override void HitEffect(NPC.HitInfo hit)
		{

            int dust1 = ModContent.DustType<MushroomDust>();
            if (NPC.life <= 0)
			{
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
            }
		}
	}
}