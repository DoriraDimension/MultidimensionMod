using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;

namespace MultidimensionMod.Projectiles.Magic
{
    internal class UmosBook : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Items/Weapons/Magic/Tomes/UmosShower";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }

        public override bool? CanDamage() => false;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.channel || player.statMana <= 0)
            {
                Projectile.Kill();
            }
            Projectile.spriteDirection = player.direction;
            Projectile.Center = player.Center + new Vector2(0, -25);
            player.heldProj = Projectile.whoAmI;
        }
    }
}