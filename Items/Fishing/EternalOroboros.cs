using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class EternalOroboros : ModItem
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

        public override bool IsAnglerQuestAvailable() => false;//Main.hardMode;

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = Language.GetTextValue("Mods.MultidimensionMod.Items.EternalOroboros.QuestDialogue");
            catchLocation = Language.GetTextValue("Mods.MultidimensionMod.MiscText.ScrapyardCatchFishTooltip");
        }
    }
}