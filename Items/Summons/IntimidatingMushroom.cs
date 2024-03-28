using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.Common.Globals;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Summons
{
    public class IntimidatingMushroom : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Crown Cap");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
            // Tooltip.SetDefault(@"Summons the Mushroom Monarch");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 44;
            Item.maxStack = 9999;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 90;
            Item.useTime = 90;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            MDWorld.Monday = true;
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !MDWorld.Monday)
            {
                return true;
            }
            return false;
        }
    }
}