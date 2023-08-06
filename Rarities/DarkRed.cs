using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
    public class DarkRed : ModRarity
    {
        public override Color RarityColor => MDColors.Rarity14;

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}