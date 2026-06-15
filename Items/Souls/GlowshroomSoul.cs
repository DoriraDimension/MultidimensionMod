using MultidimensionMod.Rarities.Souls;
using MultidimensionMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader.IO;
using MultidimensionMod.NPCs.Friendly;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.Audio;
using Terraria.Localization;
using MultidimensionMod.Items.Placeables;

namespace MultidimensionMod.Items.Souls
{
    public class GlowshroomSoul : ModItem
    {
        public static readonly SoundStyle UseSound = new SoundStyle("MultidimensionMod/Sounds/Custom/HallowedCry");
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.rare = ModContent.RarityType<GlowshroomSoulRarity>();
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = UseSound;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (MemorySystem.seenMemory)
            {
                TooltipLine line = new(Mod, "MemorySeen", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.MemorySeen"))
                {
                    OverrideColor = Color.White,
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "MemoryNotSeen", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.MemoryNotSeen"))
                {
                    OverrideColor = Color.White,
                };
                tooltips.Add(line);
            }
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (MemorySystem.seenMemory)
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<FungusMemory>()] < 1)
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y - 200, 0f, 0f, ModContent.ProjectileType<FungusMemory>(), 0, 0f);
            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/GlowshroomSoul").Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }

    public class FungusMemory : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 12;
        }
        public override void SetDefaults()
        {
            Projectile.damage = 24;
            Projectile.width = 58;
            Projectile.height = 126;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 9000;
        }

        public override bool? CanDamage() => false;

        public int DEATH = 0;
        private int LegFrame;
        public int E = 0;

        public override void AI()
        {
            DEATH++;
            Projectile.velocity.X = 0;
            Projectile.velocity.Y = 0;
            if (DEATH >= 240)
            {
                if (++Projectile.frameCounter >= 6)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 11)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<FungusDie>(), 0, 0f);
                        Projectile.Kill();
                    }
                }
            }
            else
                Projectile.frame = 0;
            if (++E >= 8)
            {
                E = 0;
                LegFrame++;
                if (LegFrame > 3)
                    LegFrame = 0;
            }
            if (Projectile.frame == 7)
            {
                SoundEngine.PlaySound(SoundID.DD2_LightningBugHurt, Projectile.position);
                SoundEngine.PlaySound(SoundID.NPCHit1 with { Volume = -0.50f }, Projectile.position);
            }
        }

        public override void OnKill(int timeLeft)
        {
            Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X - 15, Projectile.Center.Y), Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/FungusDieGore1").Type, 1);
            Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X + 15, Projectile.Center.Y), Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/FungusDieGore2").Type, 1);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D shrem = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
            int height = shrem.Height / 12;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, shrem.Width, height);
            Vector2 drawOrigin = new(shrem.Width / 2, Projectile.height / 2);
            Main.EntitySpriteDraw(shrem, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/FungusLegs").Value;
            int height = texture.Height / 4;
            int y = height * LegFrame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
        }
    }

    public class FungusDie : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.damage = 24;
            Projectile.width = 58;
            Projectile.height = 126;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 9000;
        }

        public override bool? CanDamage() => false;

        public int Decaying = 0;
        public bool WillDieNow = false;

        public override void AI()
        {
            Projectile.velocity.Y = 0.5f;
            if (++Projectile.frameCounter >= 34)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                {
                    WillDieNow = true;
                    Projectile.frame = 4;
                }
            }
            if (WillDieNow)
            {
                Decaying++;
            }
            if (Decaying == 120)
            {
                Item.NewItem(Projectile.GetSource_FromThis(), Projectile.position, Projectile.Size, ModContent.ItemType<RottenMemory>(), 1);
                Projectile.Kill();
            }
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastAuraPulse, Projectile.position);
            MemorySystem.seenMemory = true;
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GlowingMushroom, 0f, 0f, 69, default(Color), 2f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D shrem = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
            int height = shrem.Height / 5;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, shrem.Width, height);
            Vector2 drawOrigin = new(shrem.Width / 2, Projectile.height / 2);
            Main.EntitySpriteDraw(shrem, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}