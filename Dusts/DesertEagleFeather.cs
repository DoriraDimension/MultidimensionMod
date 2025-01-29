using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
    public class DesertEagleFeather : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.frame = new Rectangle(0, 0, 22, 12);
            dust.scale -= 0.022f;
            dust.position += dust.velocity;
            dust.rotation *= .01f * Main.rand.Next(3);
            if (dust.scale <= 0)
            {
                dust.active = false;
            }
            return false;
        }
    }
}