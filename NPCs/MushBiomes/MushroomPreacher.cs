using MultidimensionMod.Items.Placeables.Banners;
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
using Terraria.Utilities;
using MultidimensionMod.Biomes;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.Common.Systems;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class MushroomPreacher : ModNPC
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
            NPC.width = 96;
            NPC.height = 112;
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
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MushroomPreacher")
            });
        }

        public bool mike = false;
        public bool piper = false;
        public bool fungalf = false;
        public bool utmungus = false;

        public override void OnSpawn(IEntitySource source)
        {
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 60, (int)NPC.Center.Y, ModContent.NPCType<MushroomFollower>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 60, (int)NPC.Center.Y, ModContent.NPCType<MushroomFollower>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 110, (int)NPC.Center.Y, ModContent.NPCType<MushroomFollower>());
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 110, (int)NPC.Center.Y, ModContent.NPCType<MushroomFollower>());
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                mike = true;
                NPC.width = 88;
                NPC.height = 93;
            }
            else if (choice == 1)
            {
                piper = true;
                NPC.width = 96;
                NPC.height = 112;
            }
            else if (choice == 2)
            {
                fungalf = true;
                NPC.width = 58;
                NPC.height = 100;
            }
            else if (choice == 3)
            {
                utmungus = true;
                NPC.width = 74;
                NPC.height = 84;
            }
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
                    int dustIndex = Dust.NewDust(NPC.position, NPC.width * 2, NPC.height * 2, dustType);
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
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue3"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue4"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue5"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue6"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.MushroomPreacher.Dialogue7"));
            string dialogueLine = chat;
            return dialogueLine;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {

        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneGlowshroom && DownedSystem.downedFungus && spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > Main.rockLayer && !NPC.AnyNPCs(ModContent.NPCType<MushroomPreacher>()))
            {
                return 0.13f;
            }
            return 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
            }
        }

        public override void FindFrame(int frameHeight)
        {

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D mikeshroom = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D pipeshroom = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Piper").Value;
            Texture2D dalfshroom = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Fungalf").Value;
            Texture2D mungshroom = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Utmungus").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (utmungus)
                spriteBatch.Draw(mungshroom, NPC.Center + new Vector2(16f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (fungalf)
                spriteBatch.Draw(dalfshroom, NPC.Center + new Vector2(26f, -4f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (piper)
                spriteBatch.Draw(pipeshroom, NPC.Center + new Vector2(0f, 2f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (mike)
                spriteBatch.Draw(mikeshroom, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}