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

namespace MultidimensionMod.NPCs.TownPets
{
    [AutoloadHead]
    public class TownDrake : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Drake Juvenile");
            Main.npcFrameCount[Type] = 9;
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownDog];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownDog];
            NPCID.Sets.IsTownPet[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.TownDog);

            AIType = NPCID.TownDog;
            NPC.lifeMax = 300;
            NPC.defense = 15;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override string GetChat()
        {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Sniff Sniff"));
            chat.Add(Language.GetTextValue("Shi Shi Shia"));
            chat.Add(Language.GetTextValue("grrrrrr"));
            chat.Add(Language.GetTextValue("*It stares at you intensely*"));
            if (Main.rand.NextBool(3333))
            {
                chat.Add(Language.GetTextValue("Mark my words mortal, as they will be the last thing you hear in your worthless life. We will strike when you least expect it."));
            }
            return chat;
        }

        public override void OnKill()
        {
            int baby = NPC.FindFirstNPC(ModContent.NPCType<TownDrake>());
            Main.NewText(Language.GetTextValue("Your Drake left, try to find a new one!"), 50, 125, 255);
        }

        public override void OnSpawn(IEntitySource source)
        {
            Main.NewText(Language.GetTextValue("You adopted a juvenile Ice Drake, treat it well."), 50, 125, 255);
        }

        public override void AI()
        {
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == Type)
                Main.player[Main.myPlayer].isTheAnimalBeingPetSmall = true;
        }

        private int frame;
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            if (++NPC.frameCounter > 8)
            {
                frame++;
                NPC.frameCounter = 0;
                if (frame > 9)
                {
                    frame = 0;
                }
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
                "Kyu",
                "Tundrana"
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