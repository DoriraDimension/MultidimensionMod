﻿using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.NPCs.TownPets;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;
using MultidimensionMod.NPCs.Mire;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.Biomes;
using Terraria.Utilities;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class MushroomFollower : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.width = 40;
            NPC.height = 41;
            NPC.damage = 0;
            NPC.defense = 15;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 0, 90);
            NPC.chaseable = false;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<MushStoryBiome>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
               BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MushroomFollower")
            });
        }

        public override void OnSpawn(IEntitySource source)
        {
        }

        public override void AI()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<FeudalFungus>()))
            {
                SoundEngine.PlaySound(SoundID.NPCDeath6 with { Volume = .2f }, NPC.position);
                NPC.active = false;
                for (int i = 0; i < 10; i++)
                {
                    int dustType = DustID.GlowingMushroom;
                    int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                    Dust dust = Main.dust[dustIndex];
                    dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                    dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                    dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
                }
            }
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {

            return false;
        }

        public override bool CanChat()
        {
            return true;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue3"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue4"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue5"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomFollower.Dialogue6"));
            string dialogueLine = chat;
            return dialogueLine;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {

        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
            }
        }

        private int frame;
        public override void FindFrame(int frameHeight)
        {

        }
    }
}