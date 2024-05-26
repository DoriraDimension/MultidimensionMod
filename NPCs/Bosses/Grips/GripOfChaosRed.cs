using MultidimensionMod.Common.ItemDropRules.DropConditions;
using MultidimensionMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;

namespace MultidimensionMod.NPCs.Bosses.Grips
{
    [AutoloadBossHead]
    public class GripOfChaosRed : BaseGripOfChaos
    {
        public override void SetDefaults()
        {
			base.SetDefaults();
			NPC.lifeMax = 1600;
            NPC.damage = 32;
            NPC.defense = 15;	
            NPC.buffImmune[BuffID.OnFire] = true;			
			offsetBasePoint = new Vector2(-240f, 0f);			
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.GripHot")
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfernoGripGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfernoGripGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfernoGripGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfernoGripGore4").Type, 1);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D hand = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(hand, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            DownedSystem.downedGrips = true;
            if (!Main.expertMode && Main.rand.NextBool(7))
            {
                //Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<GripMaskRed>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<ClawOfChaos>()));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<GripsOfChaos>(), 2));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<ClawBaton>(), 3));
            //NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<GripsRelic>()));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<GripTrophyRed>(), 10));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<HandSoul>()));
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}
