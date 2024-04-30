using MultidimensionMod.Common.Systems;
using MultidimensionMod.Common.ItemDropRules.DropConditions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using MultidimensionMod.Items.Materials;

namespace MultidimensionMod.NPCs.Bosses.Grips
{
    [AutoloadBossHead]
    public class GripOfChaosBlue : BaseGripOfChaos
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.lifeMax = 1400;
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.buffImmune[BuffID.Poisoned] = true;
            offsetBasePoint = new Vector2(240f, 0f);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MireGripGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MireGripGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MireGripGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MireGripGore4").Type, 1);
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            DownedSystem.downedGrips = true;
            if (!Main.expertMode && Main.rand.NextBool(7))
            {
                //Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<GripMaskBlue>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<ClawOfChaos>()));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<GripsOfChaos>(), 2));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<ClawBaton>(), 3));
            //NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<GripsRelic>()));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<GripTrophyBlue>(), 10));
            //NPCloot.Add(ItemDropRule.ByCondition(new MissingGripCondition(), ModContent.ItemType<HandSoul>()));
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Poisoned, 180); 
        }		
    }
}
