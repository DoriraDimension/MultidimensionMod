using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Solutions
{
    public abstract class Solution : ModProjectile
    {
        public virtual int DustType { get; }

        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 6;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            Projectile.extraUpdates = 2;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer)
            {
                Convert((int)(Projectile.position.X + Projectile.width / 2f) / 16, (int)(Projectile.position.Y + Projectile.height / 2f) / 16, 2);
            }

            if (Projectile.timeLeft > 133)
            {
                Projectile.timeLeft = 133;
            }

            if (Projectile.ai[0] > 7f)
            {
                float dustScale = 1f;

                switch (Projectile.ai[0])
                {
                    case 8f:
                        dustScale = 0.2f;
                        break;

                    case 9f:
                        dustScale = 0.4f;
                        break;

                    case 10f:
                        dustScale = 0.6f;
                        break;

                    case 11f:
                        dustScale = 0.8f;
                        break;
                }

                Projectile.ai[0] += 1f;

                for (int i = 0; i < 1; i++)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
                    dust.noGravity = true;
                    dust.scale *= 1.75f;
                    dust.velocity *= 2f;
                    dust.scale *= dustScale;
                }
            }
            else
            {
                Projectile.ai[0] += 1f;
            }

            Projectile.rotation += 0.3f * Projectile.direction;
        }

        protected static void ConvertTile(int i, int j, ushort type)
        {
            if (Main.tile[i, j].TileType != type)
            {
                Main.tile[i, j].TileType = type;
                WorldGen.SquareTileFrame(i, j);
                NetMessage.SendTileSquare(-1, i, j, 1);
            }
        }

        protected static void ConvertWall(int i, int j, ushort type)
        {
            if (Main.tile[i, j].WallType != type)
            {
                Main.tile[i, j].WallType = type;
                WorldGen.SquareWallFrame(i, j);
                NetMessage.SendTileSquare(-1, i, j, 1);
            }
        }

        public virtual void Convert(int i, int j, int size = 4) { }
    }
}
