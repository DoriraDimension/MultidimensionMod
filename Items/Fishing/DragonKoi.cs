using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class DragonKoi : ModItem
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

        public override bool IsAnglerQuestAvailable() => false;

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = Language.GetTextValue("Mods.MultidimensionMod.Items.DragonKoi.QuestDialogue");
            catchLocation = Language.GetTextValue("Mods.MultidimensionMod.MiscText.InfernoCatchFishTooltip");
        }
    }
}