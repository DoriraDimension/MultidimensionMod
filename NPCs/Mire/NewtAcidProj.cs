using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Mire
{
    public class NewtAcidProj : ModProjectile
	{
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Acid");     
            Main.projFrames[Projectile.type] = 7;     
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;               
			Projectile.height = 14;              
			Projectile.aiStyle = 1;             
			Projectile.friendly = false;         
			Projectile.hostile = true;        
			Projectile.penetrate = 1;           
			Projectile.timeLeft = 600;          
			Projectile.alpha = 20;              
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;        
			AIType = ProjectileID.WoodenArrowFriendly;           
            
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 240);
        }

        public override void AI()
        {
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.NextBool(10))
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BubbleBurst_Green, 0f, 0f, 0);

                Main.dust[dust].scale *= 1.3f;
                Main.dust[dust].fadeIn = 1f;
                Main.dust[dust].noGravity = true;
            }
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 6)
                {
                    Projectile.frame = 0;

                }
            }
        }

        public override void OnKill(int timeleft)
        {
            for (int num468 = 0; num468 < 3; num468++)
            {
                int num469 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.BubbleBurst_Green, -Projectile.velocity.X * 0.2f,
                    -Projectile.velocity.Y * 0.2f, 100, new Color(86, 191, 188), 2f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
            }
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, Projectile.velocity.X, Projectile.velocity.Y, ModContent.ProjectileType<NewtAcidBoom>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
        }
    }
}
