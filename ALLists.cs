using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.MushBiomes;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Staffs;

namespace MultidimensionMod
{
    public class ALLists
    {
        public static List<int> ReflectionExceptions;
        public static List<int> TransmutableItems;

        public static void LoadLists()
        {
            ReflectionExceptions = new List<int>()
            {
                ProjectileID.SaucerDeathray,
                ProjectileID.PhantasmalDeathray,

                ModContent.ProjectileType<IlluminaRing>(),
                ModContent.ProjectileType<RadiantIlluminaRing>(),
                ModContent.ProjectileType<PufferFart>(),
            };

            #region Items
            TransmutableItems = new List<int>()
            {
                ItemID.LifeCrystal,
                ItemID.ManaCrystal,
                ItemID.LifeFruit,
                ItemID.GoldWorm,
                ItemID.PinkPearl,
                ItemID.SpellTome,
                ItemID.PeddlersHat,
                ItemID.RodofDiscord,
                ItemID.Clentaminator,
                ItemID.BottomlessBucket,
                ItemID.BottomlessShimmerBucket,
                ItemID.WhoopieCushion,
                ItemID.UsedGasTrap,
                ItemID.WoodenArrow,
                ItemID.HellfireArrow,
                ItemID.Flare,
                ItemID.BlueFlare,
                ItemID.Campfire,
                ItemID.AngelStatue,
                ItemID.Sundial,
                ItemID.StarCloak,
                ItemID.LavaMoss,
                ItemID.KryptonMoss,
                ItemID.XenonMoss,
                ItemID.ArgonMoss,
                ItemID.VioletMoss,
                ItemID.CopperBrick,
                ItemID.SilverBrick,
                ItemID.GoldBrick,
                ItemID.PinkBrick,
                ItemID.BlueBrick,
                ItemID.GreenBrick,
                ItemID.ObsidianBrick,
                ItemID.HellstoneBrick,
                ItemID.CobaltBrick,
                ItemID.MythrilBrick,
                ItemID.LunarBrick,
                ItemID.SpiderWall,
                ItemID.SandstoneWall,
                ItemID.HardenedSandWall,
                ItemID.BlueBrickWall,
                ItemID.BlueSlabWall,
                ItemID.BlueTiledWall,
                ItemID.PinkBrickWall,
                ItemID.PinkSlabWall,
                ItemID.PinkTiledWall,
                ItemID.GreenBrickWall,
                ItemID.GreenSlabWall,
                ItemID.GreenTiledWall,
                ItemID.LihzahrdBrickWall,
                ItemID.Apple,
                ItemID.Apricot,
                ItemID.Banana,
                ItemID.BlackCurrant,
                ItemID.BloodOrange,
                ItemID.Cherry,
                ItemID.Coconut,
                ItemID.Dragonfruit,
                ItemID.Elderberry,
                ItemID.Grapefruit,
                ItemID.Lemon,
                ItemID.Mango,
                ItemID.Peach,
                ItemID.Pineapple,
                ItemID.Plum,
                ItemID.Rambutan,
                ItemID.Starfruit,
                ItemID.SpicyPepper,
                ItemID.Pomegranate,
                ItemID.Torch,
                ItemID.PurpleTorch,
                ItemID.RedTorch,
                ItemID.YellowTorch,
                ItemID.BlueTorch,
                ItemID.GreenTorch,
                ItemID.OrangeTorch,
                ItemID.WhiteTorch,
                ItemID.IceTorch,
                ItemID.PinkTorch,
                ItemID.BoneTorch,
                ItemID.UltrabrightTorch,
                ItemID.DemonTorch,
                ItemID.CursedTorch,
                ItemID.IchorTorch,
                ItemID.RainbowTorch,
                ItemID.DesertTorch,
                ItemID.CoralTorch,
                ItemID.CorruptTorch,
                ItemID.CrimsonTorch,
                ItemID.HallowedTorch,
                ItemID.JungleTorch,
                ItemID.MushroomTorch,
                ItemID.IceSlimeBanner,
                ItemID.FallenStar,
                ItemID.MagicMirror,
                ItemID.GoldenCarp,

                ModContent.ItemType<FishCleaver>(),
                ModContent.ItemType<OceanTrident>(),
            };
            #endregion
        }

        public static void UnloadLists()
        {
            ReflectionExceptions = null;
            TransmutableItems = null;
        }
    }
}
