using MultidimensionMod.Items.Bags;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod
{
    public class MDPlayer : ModPlayer
    {
        public bool Healthy;

        public bool Blaze;

        public bool SmileyJr = false;

        public bool IgnaenHead = false;

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
            Blaze = false;
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[]
            {
                new Item (ModContent.ItemType<SusPackage>())
            };
        }

        public override void UpdateBadLifeRegen()
        {
            Player player = Main.LocalPlayer;
            if (Blaze)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 32;
            }
        }
    }
}