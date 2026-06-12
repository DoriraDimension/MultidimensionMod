using MultidimensionMod.Common.Systems;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class Woodfisk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 2;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToQuestFish();
        }

        public override bool IsQuestFish() => true;

        public override bool IsAnglerQuestAvailable() => DownedSystem.downedMonarch;

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = Language.GetTextValue("Mods.MultidimensionMod.Items.Woodfisk.QuestDialogue");
            catchLocation = Language.GetTextValue("Mods.MultidimensionMod.MiscText.ForestCatchFishTooltip");
        }
    }
}