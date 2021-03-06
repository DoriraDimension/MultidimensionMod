using MultidimensionMod.Items.Bags;
using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod
{
    public class MDPlayer : ModPlayer
    {
        public bool SmileyJr = false;

        public bool IgnaenHead = false;

        public bool Blaze;

        public bool ShinoroRune;

        public bool IgnaenRune;

        public bool RaitolgurRune;

        public bool KegakumoRune;

        public bool KiminoRune;

        public bool KushoRune;

        public bool PrismaRune;

        public bool HealthCap;

        public bool ZoneColdHell;

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
            Blaze = false;
            ShinoroRune = false;
            IgnaenRune = false;
            RaitolgurRune = false;
            KegakumoRune = false;
            KiminoRune = false;
            KushoRune = false;
            PrismaRune = false;
            HealthCap = false;
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ModContent.ItemType<SusPackage>());
            items.Add(item);
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (Main.rand.NextBool(15))
            {
                caughtType = ModContent.ItemType<EnergyFish>();
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (Blaze)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                player.lifeRegen -= 32;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (Blaze)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 6, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.2f;
                b *= 0.7f;
                fullBright = true;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (ShinoroRune)
            {
                target.AddBuff(BuffID.ShadowFlame, 180);
            }
            if (IgnaenRune)
            {
                target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
            }
            if (RaitolgurRune)
            {
                target.AddBuff(BuffID.Electrified, 180);
            }
            if (KegakumoRune)
            {
                target.AddBuff(BuffID.Poisoned, 180);
                target.AddBuff(BuffID.Venom, 180);
                target.AddBuff(BuffID.Ichor, 180);
            }
            if (KiminoRune)
            {
                if (Main.rand.NextFloat() < .0500f)
                    target.AddBuff(BuffID.Confused, 60);
            }
            if (KushoRune)
            {
                target.AddBuff(BuffID.Slow, 120);
            }
        }

        public override void UpdateBiomes()
        {
            ZoneColdHell = MDWorld.ColdHellTiles > 100;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            MDPlayer modOther = other.GetModPlayer<MDPlayer>();
            modOther.ZoneColdHell = ZoneColdHell;
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneColdHell)
            {
                return mod.GetTexture("Backgrounds/MapBackgrounds/ColdHellMapBackground");
            }
            return null;
        }
    }
}