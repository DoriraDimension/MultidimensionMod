using MultidimensionMod.Items.Bags;
using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Projectiles.Summon.Sentries;
using MultidimensionMod.Buffs.Ability;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Audio;

namespace MultidimensionMod.Common.Players
{
    public class MDPlayer : ModPlayer
    {
        public bool Healthy;
        public bool Blaze;
        public bool SmileyJr = false;
        public bool IgnaenHead = false;
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
        public bool DrakePoison = false;
        public bool NeroSet = false;

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
            Blaze = false;
            StarvingLarva = false;
            Healthy = false;
            Probe = false;
            HunterEye = false;
            DesireEye = false;
            NightEye = false;
            ExplorerEye = false;
            Geodes = false;
            Madness = false;
            DrakePoison = false;
            NeroSet = false;
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[]
            {
                new Item (ModContent.ItemType<SusPackage>()) //Gives a starter bag item to a newly created player
            };
        }

        public override void UpdateBadLifeRegen()
        {
            Player player = Main.LocalPlayer;
            if (Blaze) //Blazing Suffering debuff
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 36;
            }
            if (Madness) //Madness debuff
            {
                MadnessTimer++;
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                if (MadnessTimer >= 220)
                {
                    MadnessCringe += 5; //Increases the damage this debuff does
                    if (CalmMind)
                    {
                        MadnessCringe -= 5;
                        MadnessCringe += 2; //Reduces the damage immidietly and increases it again by a lower amount if the Calm Mind buff is currently active
                    }
                    MadnessTimer = 0; //resets the time until the next level
                }
                if (MadnessCringe >= 20) //If the damage level would go above 20, it gets reset to 20 instead
                {
                    MadnessCringe = 20; //Maximum damage the debuff can do
                }
                player.lifeRegen -= MadnessCringe;
            }
            if (!Madness)
            {
                MadnessTimer = 0;
                MadnessCringe = 0; //Resets the damage level of the debuff if it runs out
            }
            if (DrakePoison)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegen -= 24;
            }
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;

            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a melee attack
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;

            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a projectile
            }
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ItemID.Mushroom && player.GetModPlayer<MDPlayer>().Healthy)
            {
                item.healLife = 60; //Makes Mushrooms heal more HP when the Healthy Cap accessory is equipped
            }
            else if (item.type == ItemID.Mushroom && !player.GetModPlayer<MDPlayer>().Healthy)
            {
                item.healLife = 15;
            }
        }

        public override void PostHurt(Player.HurtInfo info)
        {
            //This code spawns a friendly Destroyer Probe when the player gets hit, the amount of Probes caps at 4
            Player player = Main.LocalPlayer;
            if (this.Probe && !Player.lavaWet)
            {
                if (Main.myPlayer == Player.whoAmI && Player.ownedProjectileCounts[ModContent.ProjectileType<FriendlyProbe>()] < 4)
                {
                    Item item = DiggerEngine;
                    Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-5, -3)), ModContent.ProjectileType<FriendlyProbe>(), (int)info.Damage + 40, 0f, Player.whoAmI);
                }
            }
            //Gives the player certain debuffs and plays a sound if they get hit while wearing an eye accessory
            if (this.HunterEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheHunter;
                    player.AddBuff(BuffID.Weak, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, player.position);
                }
            }
            if (this.DesireEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeofDesire;
                    player.AddBuff(BuffID.Cursed, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, player.position);
                }
            }
            if (this.ExplorerEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheExplorer;
                    player.AddBuff(BuffID.Slow, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, player.position);
                }
            }
            if (this.NightEye)
            {
                if (Main.rand.NextBool(5))
                {
                    Item item = EyeoftheNightwalker;
                    player.AddBuff(BuffID.Blackout, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, player.position);
                }
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player player = Main.LocalPlayer;
            int sentry = ModContent.ProjectileType<NeroConstruct>();
            if (MDKeybinds.ArmorAbility.JustPressed && NeroSet && player.ownedProjectileCounts[sentry] <= 0)
            {
                Vector2 velocity = new Vector2(0, 0);
                IEntitySource source = player.GetSource_Misc("Nero Set");
                Projectile.NewProjectile(source, Main.MouseWorld, velocity, sentry, 75, 0f, player.whoAmI);
                SoundEngine.PlaySound(SoundID.DD2_DefenseTowerSpawn, player.Center);
            }
        }
    }
}