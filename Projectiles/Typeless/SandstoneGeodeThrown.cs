using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
    internal class SandstoneGeodeThrown : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sandstone Geode");
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
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

        public override void OnKill(int timeLeft)
        {
            Player player = Main.LocalPlayer;
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Sand, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            if (!player.GetModPlayer<MDPlayer>().Geodes)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    int choice = Main.rand.Next(5);
                    if (choice == 0)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.SandBlock, 50);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                    else if (choice == 1)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.SandBlock, 25);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                    else if (choice == 2)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.Sandstone, 50);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                    else if (choice == 3)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.HardenedSand, 50);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                    else if (choice == 4)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<OldDustyBow>(), 1);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                    else if (choice == 5)
                    {
                        Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.DesertFossil, 15);
                        if (Main.hardMode && Main.rand.NextFloat() < .2500f)
                        {
                            Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AncientBattleArmorMaterial, 1);
                        }
                    }
                }
            }
            else if (player.GetModPlayer<MDPlayer>().Geodes)
            {
                if (Main.rand.NextFloat() < .3300f)
                {
                    Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<SandstoneGeode>(), 1);
                }
            }
            if (player.GetModPlayer<MDPlayer>().Geodes)
            {
                for (int i = 0; i < 2; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ModContent.ProjectileType<SandBallz>(), (int)((double)((float)Projectile.damage) * 0.3f), 0f, Main.myPlayer);
                }
            }
            if (player.GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
            {
                SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
                for (int i = 0; i < 2; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<SandExplosion>(), (int)((double)((float)Projectile.damage) * 0.7f), 0f, Main.myPlayer);
                }
            }
        }
    }
}