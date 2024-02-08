using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
    public class AccursedGhost : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.frame = new Rectangle(0, 0, 10, 16);
            dust.scale -= 0.03f;
            dust.position += dust.velocity;
            dust.rotation = 0f;
            if (dust.scale <= 0)
            {
                dust.active = false;
            }
            return false;
        }
        public override bool MidUpdate(Dust dust)
        {
            if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
            {

            }
            return true;
        }

    }
}