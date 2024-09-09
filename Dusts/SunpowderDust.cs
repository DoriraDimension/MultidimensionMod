using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
    public class SunpowderDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.frame = new Rectangle(0, 0, 32, 32);
            dust.scale -= 0.02f;
            dust.position += dust.velocity;
            dust.rotation = 0f;
            if (dust.scale <= 0)
            {
                dust.active = false;
            }
            return false;
        }
    }
}