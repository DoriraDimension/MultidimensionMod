using MultidimensionMod.Items.Bags;
using MultidimensionMod.Projectiles.Summon.Minions;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod
{
    public class MDPlayer : ModPlayer
    {
        public bool Healthy;

        public bool Blaze;

        public bool SmileyJr = false;

        public bool IgnaenHead = false;

        public bool EyeCrit = false;

        public bool StarvingLarva = false;

        public bool Probe = false;

        public Item DiggerEngine;

        public bool HunterEye = false;

        public bool DesireEye = false;

        public bool NightEye = false;

        public bool ExplorerEye = false;

        public Item EyeoftheHunter;

        public Item EyeoftheNightwalker;

        public Item EyeofDesire;

        public Item EyeoftheExplorer;

        public bool Geodes;

        public bool Madness;

        public int MadnessTimer;

        public int MadnessCringe;

        public bool CalmMind;

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
            Blaze = false;
            EyeCrit = false;
            StarvingLarva = false;
            Healthy = false;
            Probe = false;
            HunterEye = false;
            DesireEye = false;
            NightEye = false;
            ExplorerEye = false;
            Geodes = false;
            Madness = false;
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[]
            {
                new Item (ModContent.ItemType<SusPackage>())
            };
        }

        public override void UpdateBadLifeRegen()
        {
            Player player = Main.LocalPlayer;
            if (Blaze)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 32;
            }
            if (Madness)
            {
                MadnessTimer++;
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                if (MadnessTimer >= 220)
                {
                    MadnessCringe += 5;
                    if (CalmMind)
                    {
                        MadnessCringe -= 5;
                        MadnessCringe += 2;
                    }
                    MadnessTimer = 0;
                }
                if (MadnessCringe >= 20)
                {
                    MadnessCringe = 20;
                }
                player.lifeRegen -= MadnessCringe;
            }
            if (!Madness)
            {
                MadnessTimer = 0;
                MadnessCringe = 0;
                player.lifeRegen = 0;
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.LocalPlayer;
            if (EyeCrit)
            {
                if (crit)
                {
                    player.AddBuff(BuffID.Hunter, 960);
                    target.AddBuff(BuffID.Ichor, 240);
                }
            }

            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.LocalPlayer;
            if (EyeCrit)
            {
                if (crit)
                {
                    player.AddBuff(BuffID.Hunter, 960);
                    target.AddBuff(BuffID.Ichor, 240);
                }
            }
            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5;
            }
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ItemID.Mushroom && player.GetModPlayer<MDPlayer>().Healthy)
            {
                item.healLife = 60;
            }
            else if (item.type == ItemID.Mushroom && !player.GetModPlayer<MDPlayer>().Healthy)
            {
                item.healLife = 15;
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
        {
            Player player = Main.LocalPlayer;
            if (this.Probe && !Player.lavaWet)
            {
                if (Main.myPlayer == Player.whoAmI && Player.ownedProjectileCounts[ModContent.ProjectileType<FriendlyProbe>()] < 4)
                {
                    Item item = DiggerEngine;
                    Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-5, -3)), ModContent.ProjectileType<FriendlyProbe>(), (int)damage + 40, 0f, Player.whoAmI);
                }
            }
            if (this.HunterEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheHunter;
                    player.AddBuff(BuffID.Weak, 480);
                }
            }
            if (this.DesireEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeofDesire;
                    player.AddBuff(BuffID.Cursed, 480);
                }
            }
            if (this.ExplorerEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheExplorer;
                    player.AddBuff(BuffID.Slow, 480);
                }
            }
            if (this.NightEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheNightwalker;
                    player.AddBuff(BuffID.Blackout, 480);
                }
            }
        }
    }
}