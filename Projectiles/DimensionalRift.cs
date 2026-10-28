using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using MultidimensionMod.Items.Accessories;

namespace MultidimensionMod.Projectiles
{
    public class DimensionalRift : ModProjectile
    {
        private int timer;
        private bool itemDropped;
        public override string Texture => "MultidimensionMod/NPCs/TownNPCs/TarahaPortal";

        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 180;
        }

        public override void AI()
        {
            timer++;

            // A subtle floating animation.
            Projectile.velocity = Vector2.Zero;
            Projectile.rotation += 0.01f;

            // Drop the item after one second.
            if (timer >= 60 && !itemDropped)
            {
                itemDropped = true;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Item.NewItem( new EntitySource_Misc("DimensionalRift"), Projectile.getRect(), ModContent.ItemType<AstralTitansEyeJewelOff>());
                }
            }

            // Disappear after three seconds.
            if (timer >= 180)
            {
                Projectile.Kill();
            }
        }
    }
}