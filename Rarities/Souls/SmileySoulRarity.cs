using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Rarities.Souls
{
    public class SmileySoulRarity : ModRarity
    {
        public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.SmileyYellow, MDColors.SmileyPale, MDColors.SmileyYellow);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type;
        }
    }
}