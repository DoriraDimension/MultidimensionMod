using MultidimensionMod.Base;
using MultidimensionMod.Buffs.Cooldowns;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Audio;

namespace MultidimensionMod.Items.Accessories
{
    public class ToadLeg : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Truffle Legs");
            //Tooltip.SetDefault(@"Increased jump speed and allows auto-jump
//You are immune to fall damage
//Increased jump height");
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ToadLeapPlayer>().LegEquipped = true;
            player.noFallDmg = true;
        }
    }

    public class ToadLeapPlayer : ModPlayer
    {
        public bool LegEquipped;
        public const int Leap = 1;
        public const int LeapCooldown = 65;
        public const int LeapDuration = 50;
        public const float LeapVelocity = 20f;
        public int Dir = -1;
        public int LeapDelay = 0;
        public int LeapTimer = 0; 

        public override void ResetEffects()
        {
            LegEquipped = false;
            if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[Leap] < 15)
            {
                Dir = Leap;
            }
            else
                Dir = -1;
        }

        public override void PreUpdateMovement()
        {
            if (CanUseLeap() && Dir != -1 && LeapDelay == 0 && !Player.HasBuff(ModContent.BuffType<LegPain>()))
            {
                Vector2 newVelocity = Player.velocity;

                switch (Dir)
                {
                    case Leap when Player.velocity.Y < LeapVelocity:
                        {
                            float LeapDirection = Dir == Leap ? -1 : -1f;
                            newVelocity.Y = LeapDirection * LeapVelocity;
                            break;
                        }
                    default:
                        return;
                }

                LeapDelay = LeapCooldown;
                LeapTimer = LeapDuration;
                Player.velocity = newVelocity;
                for (int m = 0; m < 20; m++)
                {
                    int dustID = Dust.NewDust(new Vector2(Player.Center.X - 1, Player.Center.Y - 1), 6, 6, DustID.GlowingMushroom, 0f, 0f, 100, Color.White, 1.6f);
                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                    Main.dust[dustID].noLight = false;
                    Main.dust[dustID].noGravity = true;
                }
            }

            if (LeapDelay > 0)
                LeapDelay--;

            if (LeapTimer > 0)
            {
                Player.eocDash = LeapTimer;
                Player.armorEffectDrawShadowEOCShield = true;
                LeapTimer--;
            }
            if (LeapTimer == 1)
            {
                Player.AddBuff(ModContent.BuffType<LegPain>(), 1800);
            }
        }

        private bool CanUseLeap()
        {
            return LegEquipped
                && !Player.mount.Active;
        }
    }
}