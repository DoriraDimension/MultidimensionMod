using MultidimensionMod.Items.Bags;
using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Projectiles.Summon.Sentries;
using MultidimensionMod.Projectiles.Typeless;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Buffs.Cooldowns;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Buffs.Ability;
using MultidimensionMod.Base;
using MultidimensionMod.Dusts;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Audio;
using Terraria.Localization;

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
        public bool SinnerSet = false;
        public bool MonarchHeart = false;
        public int delayedHealValue = 0;
        public int firstTickHeal = 0;
        public bool DrakeShield = false;
        public Item DrakescaleShield;
        public Item ColdDesertShield;
        public bool DesertNeck = false;
        public Item DesertNecklace;
        public bool Symbio = false;
        public int Mario;
        public int GiveBirth;
        public bool Stem = false;
        public bool manaSick = false;
        public int manaSickTimer;
        public bool FungusPrayer = false;
        public bool MushiumSet = false;
        public bool IndigoMode = false;
        public bool CrippledHealing = false;
        public bool TwinPrayer = false;
        public bool awakenedFlamescar = false;
        public int flamescarReset = 0;

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
            MonarchHeart = false;
            DrakeShield = false;
            DesertNeck = false;
            Symbio = false;
            Stem = false;
            FungusPrayer = false;
            MushiumSet = false;
            CrippledHealing = false;
            TwinPrayer = false;
        }

        public override void UpdateDead()
        {
            if (!Symbio)
            {
                Mario = 0;
                GiveBirth = 0;
            }
            delayedHealValue = 0;
        }

        public override void UpdateEquips()
        {
            if (!Symbio)
            {
                Mario = 0;
                GiveBirth = 0;
            }
            if (!MonarchHeart)
            {
                delayedHealValue = 0;
            }
            if (Stem)
            {
                if (Player.manaSick && Player.whoAmI == Main.myPlayer && !Player.HasBuff(ModContent.BuffType<InjectionCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<IndigoInjection>(), 360);
                    Player.AddBuff(ModContent.BuffType<InjectionCooldown>(), 12360);
                }
            }
        }

        public override void PreUpdate()
        {
            if (MonarchHeart && !Player.HasBuff(BuffID.PotionSickness) && !Player.dead)
            {
                int healDividing = 4;
                firstTickHeal++;
                if (firstTickHeal == 1) //So it only happens once
                {
                    Player.Heal(delayedHealValue / healDividing); //Heal for one quarter of the collected damage
                    delayedHealValue = 0;
                }
                if (firstTickHeal >= 2)
                {
                    firstTickHeal = 2; //Keep value on 2 until it is reset
                }
            }
            if (awakenedFlamescar)
            {
                flamescarReset++;
                if (flamescarReset == 1200)
                {
                    awakenedFlamescar = false;
                    flamescarReset = 0;
                    Player.AddBuff(ModContent.BuffType<InnerEmber>(), 600);
                }
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[]
            {
                new Item (ModContent.ItemType<SusPackage>()) //Gives a starter bag item to a newly created player
            };
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (attempt.rare && !attempt.inLava && !attempt.inHoney)
            {
                itemDrop = ModContent.ItemType<EnergyFish>();
                return;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (Symbio)
            {
                int damage = 75;
                Mario++;
                if (Mario >= 3000 && Mario < 6000) //Stage 1 initiated
                {
                    Player.endurance += 0.05f;
                }
                else if (Mario >= 6000 && Mario < 12000) //Stage 2 initiated
                {
                    Player.endurance -= 0.10f;
                }
                else if (Mario >= 12000) //Stage 3 initiated
                {
                    GiveBirth++;
                    Player.statLifeMax2 += 20;
                    Mario = 12000;
                }
                if (GiveBirth == 240)
                {
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"));
                    Projectile.NewProjectile(Player.GetSource_Accessory(new Item(ModContent.ItemType<GlowingFungiScarf>())), Player.Center, new Vector2(0, 0), ModContent.ProjectileType<SymbioHatchling>(), damage, 0f, Player.whoAmI);
                    GiveBirth = 0;
                }
            }
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
                if (MadnessTimer >= 160)
                {
                    MadnessCringe += 5; //Increases the damage this debuff does
                    if (CalmMind)
                    {
                        MadnessCringe -= 5;
                        MadnessCringe += 2; //Reduces the damage immidietly and increases it again by a lower amount if the Calm Mind buff is currently active
                    }
                    MadnessTimer = 0; //resets the time until the next level
                }
                if (MadnessCringe >= 40) //If the damage level would go above 40, it gets reset to 20 instead
                {
                    MadnessCringe = 40; //Maximum damage the debuff can do
                }
                player.lifeRegen -= MadnessCringe;
            }
            if (!Madness)
            {
                MadnessTimer = 0;
                MadnessCringe = 0; //Resets the damage level of the debuff if it runs out
            }
            if (DrakePoison) //Drakeblood Poison debuff
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegen -= 16;
            }
            if (MonarchHeart && Player.HasBuff(BuffID.PotionSickness))
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Madness && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue("Mods.MultidimensionMod.DeathMessages.Madness"));
            if (MonarchHeart && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue("Mods.MultidimensionMod.DeathMessages.MonarchHeart"));
            return true;
        }


        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            int useTimeSub = item.useTime / 2; //Gets the usetime of the held weapon
            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a melee attack
            }
            if (SinnerSet && item.CountsAsClass(DamageClass.Magic))
            {
                target.AddBuff(BuffID.Frostburn, 120);
            }
            if (MushiumSet && !IndigoMode && player.HasBuff(ModContent.BuffType<LightStarved>()))
            {
                if (Main.rand.NextBool(10))
                {
                    Item.NewItem(target.GetSource_Loot(), target.getRect(), ItemID.Heart, noGrabDelay: true);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            Item item = player.HeldItem;
            int useTimeSub = item.useTime / 2;
            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a projectile
            }
            if (SinnerSet && proj.CountsAsClass(DamageClass.Magic))
            {
                target.AddBuff(BuffID.Frostburn, 120);
            }
            if (MushiumSet && !IndigoMode && player.HasBuff(ModContent.BuffType<LightStarved>()) && !proj.npcProj && !proj.trap)
            {
                if (Main.rand.NextBool(10))
                {
                    Item.NewItem(target.GetSource_Loot(), target.getRect(), ItemID.Heart, noGrabDelay: true);
                }
            }
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ItemID.Mushroom && player.GetModPlayer<MDPlayer>().Healthy)
            {
                healValue = 40; //Makes Mushrooms heal more HP when the Healthy Cap accessory is equipped
            }
            else if (item.type == ItemID.Mushroom && !player.GetModPlayer<MDPlayer>().Healthy)
            {
                healValue = 15;
            }
            if (CrippledHealing || MonarchHeart)
            {
                healValue = (int)(healValue * 0.50f);
            }
            if (MonarchHeart)
            {
                healValue = (int)(healValue * 0.75f);
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
            if (DrakeShield && !Player.lavaWet)
            {
                if (Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Item item = DrakescaleShield;
                        Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.Next(-11, 11) * .25f, -7 * .75f), ModContent.ProjectileType<FrostScaleProj>(), (int)info.Damage + 18, 0f, Player.whoAmI);
                    }
                }
            }
            if (DrakeShield && !Player.lavaWet)
            {
                if (Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Item item = ColdDesertShield;
                        Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.Next(-11, 11) * .25f, -7 * .75f), ModContent.ProjectileType<FrostScaleProj>(), (int)info.Damage + 18, 0f, Player.whoAmI);
                    }
                }
            }
            if (DesertNeck && !Player.HasBuff(ModContent.BuffType<ManaBurstCooldown>()))
            {
                int damage = Player.statMana;
                if (Main.hardMode)
                {
                    damage = Player.statMana * 2;
                }
                if (Main.myPlayer == Player.whoAmI)
                {
                    Player.AddBuff(ModContent.BuffType<ManaBurstCooldown>(), 300);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    Player.statMana -= Player.statMana;
                    Item item = DesertNecklace;
                    Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(0, 0), ModContent.ProjectileType<ManaShockwave>(), (int)info.Damage + damage, 0f, Player.whoAmI);
                }
            }
            if (MonarchHeart)
            {
                if (Player.HasBuff(BuffID.PotionSickness))
                {
                    delayedHealValue += info.Damage; //Collects damage done to the player
                    firstTickHeal = 0;
                }
            }
            #region Eye accessory debuffs
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
            #endregion
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
            if (MDKeybinds.ArmorAbility.JustPressed && MushiumSet && !IndigoMode && !player.HasBuff(ModContent.BuffType<SwapExhaustion>()))
            {
                IndigoMode = true;
                player.AddBuff(ModContent.BuffType<SwapExhaustion>(), 1800);
                player.AddBuff(ModContent.BuffType<LightOverload>(), 300);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), player.position);
                for (int m = 0; m < 20; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Player.Center.X - 1, Player.Center.Y - 1), 2, 2, DustID.GlowingMushroom, 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }
            else if (MDKeybinds.ArmorAbility.JustPressed && MushiumSet && IndigoMode && !player.HasBuff(ModContent.BuffType<SwapExhaustion>()))
            {
                IndigoMode = false;
                Player.statLife += 10;
                Player.HealEffect(10);
                player.AddBuff(ModContent.BuffType<SwapExhaustion>(), 1800);
                player.AddBuff(ModContent.BuffType<LightStarved>(), 300);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), player.position);
                for (int m = 0; m < 20; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Player.Center.X - 1, Player.Center.Y - 1), 2, 2, ModContent.DustType<MushroomDust>(), 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }
        }
    }
}