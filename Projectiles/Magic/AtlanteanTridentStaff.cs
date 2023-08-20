using MultidimensionMod.Base;
using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria;
using Terraria.ModLoader;

namespace MultdimensionMod.Projectiles.Magic
{
    public class AtlanteanTridentStaff : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Items/Weapons/Magic/Staffs/AtlanteanTrident";
        public int waterBlast = 0;
        public bool blastReady = false;
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];


            if (waterBlast == 100)
            {
                for (int m = 0; m < 22; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Projectile.Center.X - 1, Projectile.Center.Y - 1), 2, 2, DustID.Water, 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)22 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                    blastReady = true;
                    SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
                }
            }
            if (waterBlast >= 101)
            {
                waterBlast = 101;
            }
            Vector2 focktor = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
            if (Main.myPlayer == Projectile.owner)
            {
                if (!player.channel)
                {
                    if (blastReady)
                    {
                        SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), focktor.X, focktor.Y, 16, 16, ModContent.ProjectileType<Lophiiformes>(), Projectile.damage, 1f, player.whoAmI);
                    }
                }
            }
        }
    }
}