using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Weapons.Typeless;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
    internal class OmniGeodeThrown : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omni Geode");
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.hide = false;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.5f;
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            Projectile.rotation += 0.4f * (float)Projectile.direction;
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.LocalPlayer;
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Stone, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            if (!player.GetModPlayer<MDPlayer>().Geodes)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    int choice = Main.rand.Next(6);
                    if (choice == 0)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CobaltOre, 25);
                    }
                    else if (choice == 1)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.PalladiumOre, 25);
                    }
                    else if (choice == 2)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MythrilOre, 25);
                    }
                    else if (choice == 3)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.OrichalcumOre, 25);
                    }
                    else if (choice == 4)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AdamantiteOre, 25);
                    }
                    else if (choice == 5)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.TitaniumOre, 25);
                    }
                }
            }
            else if (player.GetModPlayer<MDPlayer>().Geodes)
            {
                if (Main.rand.NextFloat() < .3300f)
                {
                    Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<OmniGeode>(), 1);
                }
            }
            if (player.GetModPlayer<MDPlayer>().Geodes)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.AmethystBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.TopazBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.EmeraldBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.RubyBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.SapphireBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.DiamondBolt, (int)((double)((float)Projectile.damage) * 0.6f), 0f, Main.myPlayer);
            }
        }
    }
}
 