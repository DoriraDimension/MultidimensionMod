using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
    public class DeepBlue : ModRarity
    {
        public override Color RarityColor => MDColors.Rarity13;

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}