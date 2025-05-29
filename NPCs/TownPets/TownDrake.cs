using MultidimensionMod.Items.Materials;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Common.Globals.NPCs;

namespace MultidimensionMod.NPCs.TownPets
{
    [AutoloadHead]
    public class TownDrake : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 6;
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownDog];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownDog];
            NPCID.Sets.IsTownPet[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.PetDrake")
            });
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.TownDog);

            AIType = NPCID.TownDog;
            NPC.lifeMax = 400;
            NPC.defense = 15;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.width = 36;
            NPC.height = 32;
        }

        public override string GetChat()
        {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.Dialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.Dialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.Dialogue3"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.Dialogue4"));
            if (Main.rand.NextBool(3333))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.TheThreat"));
            }
            return chat;
        }

        public override void OnKill()
        {
            int baby = NPC.FindFirstNPC(ModContent.NPCType<TownDrake>());
            //Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.NPCs.TownDrake.Death"), 50, 125, 255);
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_SpawnNPC)
            {
                // A TownNPC is "unlocked" once it successfully spawns into the world.
                TownNPCRespawnSystem.adoptedDrake = true;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (TownNPCRespawnSystem.adoptedDrake)
            {
                return true;
            }
            return false;
        }

        public override void AI()
        {
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == Type)
                Main.player[Main.myPlayer].isTheAnimalBeingPetSmall = true;
            if (Main.rand.NextBool(10000))
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ModContent.ItemType<FrostScale>(), 1);
            }
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
                    NPC.frame.Y = frameHeight * Frame(0, 0, 6);
                    break;

                case 1:
                    NPC.frame.Y = frameHeight * Frame(1, 5, 6);
                    break;

                default:
                    NPC.frame.Y = frameHeight * Frame(0, 0, 6);
                    break;
            }
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Slurb",
                "Velkhana",
                "Popsicle",
                "Sheegoth",
                "Rundas",
                "Kyurem",
                "Tundrana",
                "UwU"
            };
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return new DrakeProfile();
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FrostScale>(), 1, 1, 3));
        }
    }

    public class DrakeProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownPets/TownDrake");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("MultidimensionMod/NPCs/TownPets/TownDrake_Head");
    }
}