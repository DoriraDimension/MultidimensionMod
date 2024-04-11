using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Rarities.Souls
{
    public class GlowshroomSoulRarity : ModRarity
    {
        public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.FeudalPaleYellow, MDColors.FeudalBlue, MDColors.FeudalPaleYellow);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}