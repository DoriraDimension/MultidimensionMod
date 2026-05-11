using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
    public class MushroomDust : ModDust
	{
        public override void SetStaticDefaults()
            => UpdateType = 110;
    }
}