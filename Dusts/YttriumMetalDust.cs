using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
    public class YttriumMetalDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }
        public override bool Update(Dust dust)
        {
            dust.scale *= 0.80f;

            if (dust.scale <= 0)
            {
                dust.active = false;
            }
            return false;
        }
    }
}