using Terraria.ModLoader;

namespace MultidimensionMod
{
    public class MDPlayer : ModPlayer
    {
        public bool Healthy;

        public bool SmileyJr = false;

        public bool IgnaenHead = false;

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
        }
    }
}