using MultidimensionMod.Dusts;
using MultidimensionMod.Buffs.Cooldowns;
using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
    public class ShadowEmoji : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.accessory = true;
            Item.expert = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Expert;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.ShadowEmoji.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        //pretty much Shade Cloak, Dashmaster and Sharp Shadow from Hollow Knight lol
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<VoidDashPlayer>().VoidDashEquipped = true;
        }
    }

    public class VoidDashPlayer : ModPlayer
    {
        public const int DashDown = 0;
        public const int DashRight = 2;
        public const int DashLeft = 3;

        public const int DashCooldown = 65; // Time (frames) between starting dashes. If this is shorter than DashDuration you can start a new dash before an old one has finished
        public const int DashDuration = 50; // Duration of the dash afterimage effect in frames

        public const float DashVelocity = 15f;

        public int DashDir = -1;

        public bool VoidDashEquipped;
        public int DashDelay = 0; // frames remaining till we can dash again
        public int DashTimer = 0; // frames remaining in the dash

        public override void ResetEffects()
        {
            VoidDashEquipped = false;

            if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
            {
                DashDir = DashDown;
            }
            else if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
            {
                DashDir = DashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
            {
                DashDir = DashLeft;
            }
            else
                DashDir = -1;
        }

        public bool rip = false;
        public int Recharge = 0;
        public override void PreUpdateMovement()
        {
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (DashDir)
                {
                    case DashDown when Player.velocity.Y < DashVelocity:
                        {
                            float dashDirection = DashDir == DashDown ? 1 : -1f;
                            newVelocity.Y = dashDirection * DashVelocity;
                            break;
                        }
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            float dashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVelocity;
                            break;
                        }
                    default:
                        return;
                }

                DashDelay = DashCooldown;
                DashTimer = DashDuration;
                Player.velocity = newVelocity;
                if (!Player.HasBuff(ModContent.BuffType<VoidDashCooldown>()))
                {
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/VoidDash"));
                }
                else
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Dash"));
                // Here you'd be able to set an effect that happens when the dash first activates
                // Some examples include:  the larger smoke effect from the Master Ninja Gear and Tabi
            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            {
                Player.eocDash = DashTimer;
                Player.armorEffectDrawShadowEOCShield = true;
                if (!Player.HasBuff(ModContent.BuffType<VoidDashCooldown>()))
                {
                    Player.immune = true;
                    Player.immuneTime = 10;
                    for (int i = 0; i < 10; i++)
                    {
                        int dustIndex3 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, ModContent.DustType<DarkDust>(), 0f, 0f, 100, default(Color), 1.6f);
                        Main.dust[dustIndex3].alpha = 50;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int dustIndex = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, ModContent.DustType<VoidDustG>(), 0f, 0f, 100, default(Color), 1.5f);
                        Main.dust[dustIndex].alpha = 50;
                        Main.dust[dustIndex].noGravity = true;
                        int dustIndex2 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, ModContent.DustType<VoidDustM>(), 0f, 0f, 100, default(Color), 1.5f);
                        Main.dust[dustIndex2].alpha = 50;
                        Main.dust[dustIndex2].noGravity = true;
                    }
                    for (int e = 0; e < Main.maxNPCs; e++)
                    {
                        NPC npc = Main.npc[e];
                        Rectangle rectangle = new Rectangle((int)Player.position.X, (int)Player.position.Y, Player.width, Player.height);
                        if (rectangle.Intersects(npc.Hitbox) && !npc.friendly)
                        {
                            rip = true;
                            npc.AddBuff(ModContent.BuffType<Nihil>(), 120);
                        }
                    }
                    for (int a = 0; a < Main.maxProjectiles; a++)
                    {
                        Projectile proj = Main.projectile[a];
                        Rectangle rectangle = new Rectangle((int)Player.position.X, (int)Player.position.Y, Player.width, Player.height);
                        if (rectangle.Intersects(proj.Hitbox) && !proj.friendly)
                        {
                            rip = true;
                        }
                    }
                }
                DashTimer--;
            }
            if (DashTimer == 1 && rip)
            {
                Player.AddBuff(ModContent.BuffType<VoidDashCooldown>(), 600);
                rip = false;
            }
        }

        private bool CanUseDash()
        {
            return VoidDashEquipped
                && !Player.setSolar // player isn't wearing solar armor
                && !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
        }
    }
}