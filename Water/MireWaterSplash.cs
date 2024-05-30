using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Water
{
    public class MireWaterSplash : ModDust
    {
        public override void SetStaticDefaults()
        {
            UpdateType = 33;
        }

        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170;
            dust.velocity *= 0.4f;
            dust.velocity.Y += 1f;
        }
    }
}