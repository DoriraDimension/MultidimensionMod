using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
    public class DeepGreen : ModRarity
    {
        public override Color RarityColor => MDColors.Rarity15;

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}