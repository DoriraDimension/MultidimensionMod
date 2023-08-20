using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
    public class BrightPink : ModRarity
    {
        public override Color RarityColor => MDColors.Rarity12;

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}