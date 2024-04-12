using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria;

namespace MultidimensionMod
{
    public class MDColors
    {
        #region Post-Moon Lord rarities
        public static Color Rarity12 => new Color(239, 0, 243);
        public static Color Rarity13 => new Color(0, 125, 243);
        public static Color Rarity14 => new Color(255, 22, 0);
        public static Color Rarity15 => new Color(0, 178, 107);
        #endregion

        #region special
        //???
        public static Color BossSoulRed => new(130, 0, 0);
        public static Color BossSoulPink => new(172, 37, 139);
        public static Color BossSoulPurple => new(164, 35, 204);

        //Forbidden Artifact rarity rolors
        public static Color ForbiddenLavender => new(95, 57, 249);
        public static Color ForbiddenEldritch => new(7, 80, 80);

        //Shade Item rarity colors
        public static Color ShadeYellow => new(242, 205, 12);

        //Dorira color
        public static Color DoriraColor => new(18, 279, 247);
        #endregion

        #region bosses
        //Queen Bee Soul colors
        public static Color QueenBeePurple => new(63, 39, 105);
        public static Color QueenBeeYellow => new(228, 215, 70);

        //Brain Soul colors
        public static Color BrainDeepRed => new(78, 14, 16);
        public static Color BrainBrightRed => new(220, 165, 166);

        //Cultist Soul colors
        public static Color CultistSolar => new(247, 178, 11);
        public static Color CultistVortex => new(20, 223, 147);
        public static Color CultistNebula => new(246, 92, 216);
        public static Color CultistStardust => new(0, 177, 227);

        //Deerclops Soul colors
        public static Color DeerGray => new(211, 204, 196);
        public static Color DeerShadow => new(27, 3, 123);

        //Duke Soul colors
        public static Color DukeGreen => new(48, 248, 171);
        public static Color DukeBlue => new(25, 120, 181);

        //Empress Soul colors
        public static Color EmpressYellow => new(254, 249, 53);
        public static Color EmpressBlue => new(16, 124, 251);
        public static Color EmpressPink => new(248, 118, 224);

        //Eye Soul rarity
        public static Color EyeBlue => new(55, 49, 181);
        public static Color EyeWhite => new(230, 230, 230);
        public static Color EyeRed => new(181, 37, 37);

        //Golem Core colors
        public static Color GolemBrown => new(141, 56, 0);
        public static Color GolemOrange => new(255, 216, 0);

        //King Slime Soul colors
        public static Color KingSlimeBlue => new(89, 164, 254);
        public static Color KingSlimeGold => new(228, 196, 74);

        //Mech Boss Core colors
        public static Color MechMetal => new(210, 210, 210);
        public static Color SightSoul => new(85, 202, 150);
        public static Color MightSoul => new(49, 94, 202);
        public static Color FrightSoul => new(217, 50, 24);

        //Moon Lord Soul colors
        public static Color MoonBrightGreen => new(137, 232, 204);
        public static Color MoonDarkGreen => new(29, 139, 113);

        //Plantera Soul colors
        public static Color PlantPink => new(225, 128, 206);
        public static Color PlantGreen => new(110, 183, 4);

        //Skeletron Soul colors
        public static Color Bone => new(204, 204, 159);
        public static Color DarkBone => new(45, 45, 29);

        //Smiley Soulshard colors

        public static Color SmileyYellow => new(255, 242, 0);

        public static Color SmileyPale => new(214, 214, 214);

        //Wall Soul colors
        public static Color WallFlesh => new(158, 48, 83);
        public static Color WallDark => new(162, 95, 234);
        public static Color WallLight => new(220, 29, 183);

        //Queen Slime Soul colors
        public static Color QueenSlimePink => new(247, 118, 227);
        public static Color QueenSlimeSilver => new(171, 182, 183);

        //Eater of Worlds Soul colors
        public static Color EaterFlesh => new(116, 94, 97);
        public static Color EaterGoop => new(115, 127, 33);

        //Mushroom Monarch Soul colors
        public static Color MushMonOrange => new(237, 160, 69);
        public static Color MushMonRed => new(198, 52, 52);

        //Feudal Fungus Soul colors
        public static Color FeudalPaleYellow => new(171, 173, 130);
        public static Color FeudalBlue => new(0, 128, 255);
        #endregion

        #region Adel

        public static Color AdelText => new(255, 0, 127);
        #endregion

        #region Other

        public static Color Rainbow => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.LightBlue, Color.Blue, Color.Purple, Color.Red);
        public static Color IncineriteColor = new Color((int)(242 * 0.7f), (int)(107 * 0.7f), 0);
        #endregion
    }
}