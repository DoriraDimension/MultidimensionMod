using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Common.Globals.NPCs;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Materials;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.NPCs.TownPets
{
    [AutoloadHead]
    public class TownBug : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 6;
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = -2;
            NPCID.Sets.NPCFramingGroup[Type] = 8;
            NPCID.Sets.IsTownPet[Type] = true;
            NPCID.Sets.TownNPCBestiaryPriority.Add(Type);
            NPCID.Sets.PlayerDistanceWhilePetting[Type] = 25;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.DangerDetectRange[Type] = 250;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new()
            {
                Velocity = 0.25f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.PetBug")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 56;
            NPC.height = 32;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit45;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.knockBackResist = 0.5f;
            NPC.housingCategory = 1;
        }

        public override string GetChat()
        {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownBug.Dialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownBug.Dialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownBug.Dialogue3"));
            return chat;
        }

        public override void OnKill()
        {
            int baby = NPC.FindFirstNPC(ModContent.NPCType<TownBug>());
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (TownNPCRespawnSystem.adoptedBug)
            {
                return true;
            }
            return false;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(800))
            {
                SoundEngine.PlaySound(SoundID.Zombie77, NPC.position);
            }
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == Type)
                Main.player[Main.myPlayer].isTheAnimalBeingPetSmall = true;
        }

        private int frame;
        private int frameCounter = 0;

        public int Frame(int firstFrame, int lastFrame, int speed)
        {
            frameCounter++;
            if (frameCounter > speed)
            {
                frameCounter = 0;
                frame++;
                if (frame > lastFrame)
                    frame = firstFrame;
            }

            return frame;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;

            switch (NPC.ai[0])
            {
                case 0:
                    NPC.frame.Y = frameHeight * Frame(5, 5, 6);
                    break;

                case 1:
                    NPC.frame.Y = frameHeight * Frame(0, 4, 6);
                    break;

                default:
                    NPC.frame.Y = frameHeight * Frame(5, 5, 6);
                    break;
            }
        }

        public readonly List<string> LeafList = new() {
            "Leafy", "Lil' Nibble", "Seltas", "Garmond", "Borb", "Afungus", "Sustingus", "Monarch Chloro"
        };
        public readonly List<string> DapperList = new() {
            "Lil' Nibble", "Deadly Dapperbug", "Hornet", "Scarlet", "Borb", "Afungus", "Sustingus", "Lord Crimson"
        };
        public readonly List<string> SakuraList = new() {
            "Lil' Nibble", "Sakura", "Kirby", "Queen", "Borb", "Afungus", "Sustingus", "Empress Spring"
        };
        public readonly List<string> MidasList = new() {
            "Lil' Nibble", "Midas", "Athal-Ka", "Shiny", "Relic", "Borb", "Afungus", "Sustingus", "King Avaritia"
        };

        public override List<string> SetNPCNameList()
        {
            return NPC.townNpcVariationIndex switch
            { // Change the name based on the variation.
                0 => LeafList,
                1 => DapperList,
                2 => SakuraList,
                3 => MidasList,
                _ => LeafList
            };
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return new BugProfile();
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("UI.PetTheAnimal");
        }
    }
    public class BugProfile : ITownNPCProfile
    {
        private static readonly string filePath = "MultidimensionMod/NPCs/TownPets/TownBug";
        public int RollVariation() => Main.rand.Next(4);
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        private readonly Asset<Texture2D> variant0 = ModContent.Request<Texture2D>(filePath);
        private readonly Asset<Texture2D> variant1 = ModContent.Request<Texture2D>($"{filePath}_Dapper");
        private readonly Asset<Texture2D> variant2 = ModContent.Request<Texture2D>($"{filePath}_Sakura");
        private readonly Asset<Texture2D> variant3 = ModContent.Request<Texture2D>($"{filePath}_Midas");
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            return npc.townNpcVariationIndex switch
            {
                0 => variant0,
                1 => variant1,
                2 => variant2,
                3 => variant3,
                _ => variant0
            };
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("MultidimensionMod/NPCs/TownPets/TownBug_Head");
    }
}