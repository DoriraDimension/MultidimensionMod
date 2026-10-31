using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria.Audio;

namespace MultidimensionMod.Sounds
{
    public static class CustomSounds
    {

        public static readonly SoundStyle RoyalRadianceScream = new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream") { PitchVariance = .1f };

        public static readonly SoundStyle RadianceShot = new("MultidimensionMod/Sounds/Custom/RadianceShot") { PitchVariance = .1f };

        public static readonly SoundStyle Gunshot = new("MultidimensionMod/Sounds/Custom/Gunshot") { PitchVariance = .1f };

        public static readonly SoundStyle LakeAmbience = new("MultidimensionMod/Sounds/Custom/LakeDepthsAmbience") { PitchVariance = .1f };

        public static readonly SoundStyle ClamCrack = new("MultidimensionMod/Sounds/Custom/ClamCrack") { PitchVariance = .1f };

        public static readonly SoundStyle Magic = new("MultidimensionMod/Sounds/Custom/Magic") { PitchVariance = .1f };

        public static readonly SoundStyle AnalysisLoop = new("MultidimensionMod/Sounds/Custom/AnalysisLoop") { PitchVariance = 0.0f };

        public static readonly SoundStyle AnalysisDone = new("MultidimensionMod/Sounds/Custom/AnalysisDone") { PitchVariance = .1f };
    }
}