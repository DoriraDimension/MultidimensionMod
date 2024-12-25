using System;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static MultidimensionMod.Items.Potions.EGG;

namespace MultidimensionMod.Common.Systems
{
    //Thanks for Wrath of the Gods for having a public example on how to achieve this
    [Autoload(Side = ModSide.Client)]
    public class OblivionFuckOffTextSystem : ModSystem
    {
        public static bool UseEggText
        {
            get;
            set;
        }

        public static string EggText => Language.GetTextValue("Mods.MultidimensionMod.Items.EGG.FuckOffText");

        public override void OnModLoad()
        {
            Terraria.GameContent.UI.IL_GameTipsDisplay.Draw += ChangeTipTextToEgg;
            On_Main.DrawMenu += ChangeTextToEgg;
        }

        private void ChangeTextToEgg(On_Main.orig_DrawMenu orig, Main self, GameTime gameTime)
        {
            if (UseEggText)
            {
                Main.statusText = Language.GetTextValue("Mods.MultidimensionMod.Items.EGG.FuckOffText2");
                orig(self, gameTime);

                if (returnDelay >= 1)
                {
                    Main.menuMode = 10;
                    returnDelay++;

                    if (returnDelay >= 600)
                    {
                        Main.menuMode = 0;
                        returnDelay = 0;
                    }
                }
                return;
            }
            orig(self, gameTime);
        }

        public override void PostUpdateEverything()
        {
            if (!Main.gameMenu)
            {
                UseEggText = false;
            }
        }

        private void ChangeTipTextToEgg(ILContext il)
        {
            ILCursor cursor = new(il);

            if (!cursor.TryGotoNext(i => i.MatchCallOrCallvirt(typeof(Language), "get_ActiveCulture")))
                return;

            int textLocalIndex = 0;
            if (!cursor.TryGotoNext(MoveType.Before, i => i.MatchStloc(out textLocalIndex)))
                return;

            cursor.EmitDelegate<Func<string, string>>(originalText =>
            {
                if (UseEggText)
                    return EggText;
                return originalText;
            });

            if (!cursor.TryGotoNext(MoveType.After, i => i.MatchCallOrCallvirt<Color>("get_White")))
                return;

            cursor.EmitDelegate<Func<Color, Color>>(originalColor =>
            {
                if (UseEggText)
                    return Color.IndianRed;
                return originalColor;
            });
        }
    }
}
