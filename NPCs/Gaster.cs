using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs
{
    public class Gaster : ModNPC
    {

        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 38;
            NPC.height = 96;
            NPC.damage = int.MaxValue;
            NPC.defense = int.MaxValue;
            NPC.lifeMax = int.MaxValue;
            NPC.knockBackResist = 0.0f;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.aiStyle = -1;
            NPC.dontTakeDamage = false;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Gaster")
            });
        }

        public override void AI()
        {

        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
        }

        public override void HitEffect(NPC.HitInfo hit)
        {

        }
    }
}