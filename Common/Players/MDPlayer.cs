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
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Biomes;
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
using MultidimensionMod.Utilities;
using Terraria.Graphics.Effects;
using MultidimensionMod.Items;

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
        public bool DragonsGuard = false;
        public bool OrnateVeil = false;
        public Item OrnateBand;
        public int veilReset = 0;
        public bool chaosClaw = false;
        public bool GripMinion = false;
        public bool SkulkerShell = false;
        public bool impactTreads = false;
        public bool impactSpeedReached = false;
        public bool FogLantern = false;
        public float FogProgress = 0f;
        public float FogLanternThreshold = 0.7f;
        public bool SpiderNecklace = false;
        public bool starBless = false;
        public Item DivineStarBlessing;
        public bool herbBook = false;
        #region Custom Sword Swing Fields
        public int swingDir = 1;
        public Vector2 currentArmPosition = Vector2.Zero;
        public float currentArmRotation = 0;
        public Vector2 startingDirection = Vector2.Zero;
        public float progress = 0;
        #endregion

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
            SinnerSet = false;
            MonarchHeart = false;
            DrakeShield = false;
            DesertNeck = false;
            Symbio = false;
            Stem = false;
            FungusPrayer = false;
            MushiumSet = false;
            CrippledHealing = false;
            TwinPrayer = false;
            DragonsGuard = false;
            OrnateVeil = false;
            chaosClaw = false;
            GripMinion = false;
            SkulkerShell = false;
            impactTreads = false;
            FogLantern = false;
            SpiderNecklace = false;
            starBless = false;
            herbBook = false;
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
            #region Ornate Band debuff deflection
            if (OrnateVeil && veilReset == 0)
            {
                if (Player.HasBuff(BuffID.OnFire))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.OnFire);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.OnFire, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.OnFire3))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.OnFire3);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.OnFire3, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.ShadowFlame))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.ShadowFlame);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.ShadowFlame, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.Frostburn))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.Frostburn);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.Frostburn, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.Frostburn2))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.Frostburn2);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.Frostburn2, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.Poisoned))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.Poisoned);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.Poisoned, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.Venom))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.Venom);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.Venom, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.CursedInferno))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.CursedInferno);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.CursedInferno, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(BuffID.Electrified))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(BuffID.Electrified);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(BuffID.Electrified, 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(ModContent.BuffType<BlazingSuffering>()))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(ModContent.BuffType<BlazingSuffering>());
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(ModContent.BuffType<BlazingSuffering>(), 600);
                        }
                    }
                    veilReset = 1200;
                }
                else if (Player.HasBuff(ModContent.BuffType<Madness>()))
                {
                    Item item = OrnateBand;
                    Player.ClearBuff(ModContent.BuffType<Madness>());
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    for (int m = 0; m < Main.maxNPCs; m++)
                    {
                        NPC npc = Main.npc[m];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        float npcDist = (npc.Center - Player.Center).Length();
                        float debuffDistance = 800;

                        if (npcDist < debuffDistance)
                        {
                            npc.AddBuff(ModContent.BuffType<Madness>(), 600);
                        }
                    }
                    veilReset = 1200;
                }
            }
            if (veilReset > 0)
            {
                veilReset--;
            }
            #endregion
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
            if (attempt.uncommon && !attempt.inLava && !attempt.inHoney && Main.rand.NextBool(5)) //Replaces any uncommon fishing item with an Energy Fish with a 1/5 chance
            {
                itemDrop = ModContent.ItemType<EnergyFish>();
                return;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            
            
            //Alright so uh determine fog
            float DesiredFog;
            if(Player.InModBiome<TheLakeDepths>()){
                DesiredFog=0f; 
            }
            else if(Player.InModBiome<TheShroudedMire>()&&Main.dayTime)
                DesiredFog = FogLantern ? 0.7f :1f;
            else if(Player.InModBiome<TheShroudedMire>()&&!Main.dayTime)
                DesiredFog = FogLantern ? 0.3f :0.6f;
            else
                DesiredFog=0f;

            if (FogProgress<DesiredFog)
                FogProgress += 0.05f;
            if (FogProgress>DesiredFog)
                FogProgress -= 0.05f;
            
            if (Main.netMode != NetmodeID.Server)
            {
                Filters.Scene["FogMist"].GetShader().UseProgress(FogProgress);
                Filters.Scene["FogMist"].GetShader().UseColor(Color.DarkGray);
                if (FogProgress > 0 && !Filters.Scene["FogMist"].IsInUse())
                    Filters.Scene.Activate("FogMist");
                else if (FogProgress <= 0 && Filters.Scene["FogMist"].IsInUse())
                    Filters.Scene.Deactivate("FogMist");

                Filters.Scene["FogMist"].GetShader().UseDirection(new Vector2(0.01f, 0.01f)); // also a multiplier for its timer 
                Filters.Scene["FogMist"].GetShader().UseIntensity(25); // the denisty
                Filters.Scene["FogMist"].GetShader().Shader.Parameters["uDirection2"].SetValue(new Vector2(0.025f,0.025f)); // the directoin of the fog's "Mask" effect, also a multiplier for its timer

            }

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
            if (impactTreads)
            {
                Player.maxFallSpeed *= (float)1.15;
                //Take away effects and projectile spawn ability when going slower than desired, when on a mount, using a hook or being pulled by the Wall of Flesh's tongue
                if (Player.pulley || Player.mount.Active || Player.grappling[0] != -1 || Player.tongued || Player.velocity.Y < 14.5f)
                {
                    impactSpeedReached = false;
                }
                if (Player.velocity.Y >= 14.5f)
                {
                    impactSpeedReached = true;
                    Player.statDefense += 6;
                }
                //Start spawning flame dust and emit light upon reaching desired speed.
                //Enable ability to spawn impact projectile as well.
                if (impactSpeedReached)
                {
                    if (Main.rand.Next(4) < 3)
                    {
                        int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.Torch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 1.8f;
                        Main.dust[dust].velocity.Y -= 0.5f;
                        if (Main.rand.NextBool(4))
                        {
                            Main.dust[dust].noGravity = false;
                            Main.dust[dust].scale *= 0.5f;
                        }
                    }
                    Lighting.AddLight(Player.position, 0.3f, 0.2f, 0.2f);
                    if (Player.oldVelocity.Y == Player.velocity.Y)
                    {
                        int damage = 40;
                        SoundEngine.PlaySound(SoundID.NPCDeath14, Player.position);
                        Projectile.NewProjectile(Player.GetSource_Accessory(new Item(ModContent.ItemType<ImpactTreads>())), Player.Center.X, Player.Center.Y + 10, 0, 0, ModContent.ProjectileType<ImpactTreadsImpact>(), damage, 0f, Player.whoAmI);
                        impactSpeedReached = false;
                    }
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (Blaze) //Blazing Suffering debuff
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 36;
            }
            if (Madness) //Madness debuff
            {
                MadnessTimer++;
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
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
                Player.lifeRegen -= MadnessCringe;
            }
            if (!Madness)
            {
                MadnessTimer = 0;
                MadnessCringe = 0; //Resets the damage level of the debuff if it runs out
            }
            if (DrakePoison) //Drakeblood Poison debuff
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegen -= 16;
            }
            //Disable life regeneration during Potion Sickness as part of the Heart of the Monarch's tradeoff
            if (MonarchHeart && Player.HasBuff(BuffID.PotionSickness))
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
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
            if (Blaze)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(Player.position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustID.CrimsonTorch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(Player.position, 0.1f, 0.2f, 0.7f);
            }
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                Player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a melee attack
            }
            if (SinnerSet && item.CountsAsClass(DamageClass.Magic))
            {
                target.AddBuff(BuffID.Frostburn, 120);
            }
            if (MushiumSet && !IndigoMode && Player.HasBuff(ModContent.BuffType<LightStarved>()) && target.type != NPCID.TargetDummy)
            {
                Player.AddBuff(BuffID.RapidHealing, 180);
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            if (ALLists.ReflectionExceptions.TrueForAll(x => proj.type != x) && proj.active && !proj.friendly && proj.hostile && proj.damage > 0)
            {
                if (SkulkerShell)
                {
                    if (Main.rand.NextBool(10))
                    {
                        proj.hostile = false;
                        proj.friendly = true;
                        proj.velocity *= -0.5f;
                        proj.extraUpdates += 1;
                        proj.penetrate = 1;
                        modifiers.SetMaxDamage(proj.damage / 2);
                        return;
                    }
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Item item = Player.HeldItem;
            int useTimeSub = item.useTime / 2;
            if (StarvingLarva)
            {
                if (target.life > 0)
                {
                    return;
                }
                Player.statLife += 5; //Heals the player for 5 HP if an enemy dies from a projectile
            }
            if (SinnerSet && proj.CountsAsClass(DamageClass.Magic))
            {
                target.AddBuff(BuffID.Frostburn, 120);
            }
            if (MushiumSet && !IndigoMode && Player.HasBuff(ModContent.BuffType<LightStarved>()) && !proj.npcProj && !proj.trap && target.type != NPCID.TargetDummy)
            {
                Player.AddBuff(BuffID.RapidHealing, 180);
            }
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            if (item.type == ItemID.Mushroom && Player.GetModPlayer<MDPlayer>().Healthy)
            {
                healValue = 40; //Makes Mushrooms heal more HP when the Healthy Cap accessory is equipped
            }
            else if (item.type == ItemID.Mushroom && !Player.GetModPlayer<MDPlayer>().Healthy)
            {
                healValue = 15;
            }
            if (CrippledHealing)
            {
                healValue = (int)(healValue * 0.50f);
            }
            if (MonarchHeart)
            {
                healValue = (int)(healValue * 0.75f);
            }
        }

        public override void OnHitByProjectile(Projectile projectile, Player.HurtInfo hurtinfo)
        {
            if (Probe)
            {
                if (Main.myPlayer == Player.whoAmI && Player.ownedProjectileCounts[ModContent.ProjectileType<FriendlyProbe>()] < 4)
                {
                    int probeDamage = (int)Player.GetBestClassDamage().ApplyTo(40);
                    Item item = DiggerEngine;
                    Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-5, -3)), ModContent.ProjectileType<FriendlyProbe>(), probeDamage, 0f, Player.whoAmI);
                }
            }
            if (starBless)
            {
                Item item = DivineStarBlessing;
                var source = Player.GetSource_Accessory(item);
                for (int n = 0; n < 3; n++)
                {
                    int modeDependantDamage = 120;
                    if (Main.expertMode)
                    {
                        modeDependantDamage = 180;
                    }
                    else if (Main.masterMode)
                    {
                        modeDependantDamage = 230;
                    }

                    int starDamage = (int)Player.GetBestClassDamage().ApplyTo(modeDependantDamage);

                    Projectile theStar = MDHelper.ProjectileRain(source, Player.Center, 350f, 50f, 550f, 650f, 24f, ProjectileID.StarVeilStar, starDamage, 3f, Player.whoAmI);
                    if (theStar.whoAmI.WithinBounds(Main.maxProjectiles))
                    {
                        theStar.DamageType = DamageClass.Generic;
                        theStar.ArmorPenetration = 30;
                        theStar.usesLocalNPCImmunity = true;
                        theStar.localNPCHitCooldown = 7;
                    }
                }
            }
        }

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (DragonsGuard)
            {
                npc.AddBuff(BuffID.OnFire, 180);
            }
            if (SpiderNecklace)
            {
                //Spawn 5 flying spiders when hit by an enemy
                for (int i = 0; i < 5; i++)
                {
                    int spiderDamage = (int)Player.GetBestClassDamage().ApplyTo(16);
                    Projectile bee = Projectile.NewProjectileDirect(Player.GetSource_FromThis(), Player.Center, new Vector2(2, 2).RotatedByRandom(100) * Main.rand.NextFloat(0.5f, 1.2f), ModContent.ProjectileType<FlyingSpider>(), spiderDamage, 0f, Player.whoAmI, 0, 0, 2);
                }
                Player.AddBuff(BuffID.Honey, 600);
            }
            if (Probe)
            {
                if (Main.myPlayer == Player.whoAmI && Player.ownedProjectileCounts[ModContent.ProjectileType<FriendlyProbe>()] < 4)
                {
                    int probeDamage = (int)Player.GetBestClassDamage().ApplyTo(40);
                    Item item = DiggerEngine;
                    Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-5, -3)), ModContent.ProjectileType<FriendlyProbe>(), probeDamage, 0f, Player.whoAmI);
                }
            }
            if (DrakeShield && Player.ownedProjectileCounts[ModContent.ProjectileType<FrostScaleProj>()] < 8)
            {
                if (Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int scaleDamage = (int)Player.GetBestClassDamage().ApplyTo(10);
                        Item item = DrakescaleShield;
                        Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(Main.rand.Next(-11, 11) * .25f, -7 * .75f), ModContent.ProjectileType<FrostScaleProj>(), scaleDamage, 0f, Player.whoAmI);
                    }
                }
            }
            if (DesertNeck && !Player.HasBuff(ModContent.BuffType<ManaBurstCooldown>()))
            {
                int damage = (int)Player.GetBestClassDamage().ApplyTo(Player.statMana / 2);
                if (Main.hardMode)
                {
                    damage = (int)Player.GetBestClassDamage().ApplyTo(Player.statMana);
                }
                if (Main.myPlayer == Player.whoAmI)
                {
                    Player.AddBuff(ModContent.BuffType<ManaBurstCooldown>(), 420);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/ManaBurst"));
                    Player.statMana -= Player.statMana;
                    Item item = DesertNecklace;
                    Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, new Vector2(0, 0), ModContent.ProjectileType<ManaShockwave>(), damage, 0f, Player.whoAmI);
                }
            }
            if (starBless)
            {
                Item item = DivineStarBlessing;
                var source = Player.GetSource_Accessory(item);
                for (int n = 0; n < 3; n++)
                {
                    int modeDependantDamage = 120;
                    if (Main.expertMode)
                    {
                        modeDependantDamage = 180;
                    }
                    else if (Main.masterMode)
                    {
                        modeDependantDamage = 230;
                    }

                    int starDamage = (int)Player.GetBestClassDamage().ApplyTo(modeDependantDamage);

                    Projectile theStar = MDHelper.ProjectileRain(source, Player.Center, 350f, 50f, 550f, 650f, 24f, ProjectileID.StarVeilStar, starDamage, 3f, Player.whoAmI);
                    if (theStar.whoAmI.WithinBounds(Main.maxProjectiles))
                    {
                        theStar.DamageType = DamageClass.Generic;
                        theStar.ArmorPenetration = 30;
                        theStar.usesLocalNPCImmunity = true;
                        theStar.localNPCHitCooldown = 7;
                    }
                }
            }
        }

        public override void PostHurt(Player.HurtInfo info)
        {
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
                if (Main.rand.NextBool(8))
                {
                    Item item = EyeoftheHunter;
                    Player.AddBuff(BuffID.Weak, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, Player.position);
                }
            }
            if (this.DesireEye)
            {
                if (Main.rand.NextBool(8))
                {
                    Item item = EyeofDesire;
                    Player.AddBuff(BuffID.Cursed, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, Player.position);
                }
            }
            if (this.ExplorerEye)
            {
                if (Main.rand.NextBool(8))
                {
                    Item item = EyeoftheExplorer;
                    Player.AddBuff(BuffID.Slow, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, Player.position);
                }
            }
            if (this.NightEye)
            {
                if (Main.rand.NextBool(8))
                {
                    Item item = EyeoftheNightwalker;
                    Player.AddBuff(BuffID.Blackout, 480);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, Player.position);
                }
            }
            #endregion
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            int sentry = ModContent.ProjectileType<NeroConstruct>();
            if (MDKeybinds.ArmorAbility.JustPressed && NeroSet)
            {
                Vector2 velocity = new Vector2(0, 0);
                IEntitySource source = Player.GetSource_Misc("Nero Set");
                Projectile.NewProjectile(source, Main.MouseWorld, velocity, sentry, 75, 0f, Player.whoAmI);
                SoundEngine.PlaySound(SoundID.DD2_DefenseTowerSpawn, Player.Center);
            }
            if (MDKeybinds.ArmorAbility.JustPressed && MushiumSet && !IndigoMode && !Player.HasBuff(ModContent.BuffType<SwapExhaustion>()))
            {
                IndigoMode = true;
                Player.AddBuff(ModContent.BuffType<SwapExhaustion>(), 1800);
                Player.AddBuff(ModContent.BuffType<LightOverload>(), 300);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), Player.position);
                for (int m = 0; m < 20; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Player.Center.X - 1, Player.Center.Y - 1), 2, 2, DustID.GlowingMushroom, 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(12f, 0f), m / (float)20 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }
            else if (MDKeybinds.ArmorAbility.JustPressed && MushiumSet && IndigoMode && !Player.HasBuff(ModContent.BuffType<SwapExhaustion>()))
            {
                IndigoMode = false;
                Player.statLife += 10;
                Player.HealEffect(10);
                Player.AddBuff(ModContent.BuffType<SwapExhaustion>(), 1800);
                Player.AddBuff(ModContent.BuffType<LightStarved>(), 300);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), Player.position);
                for (int m = 0; m < 20; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Player.Center.X - 1, Player.Center.Y - 1), 2, 2, ModContent.DustType<MushroomDust>(), 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(12f, 0f), m / (float)20 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }
        }
    }
}