using MultidimensionMod.Items.Bags;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public override void ResetEffects()
        {
            SmileyJr = false;
            IgnaenHead = false;
            Blaze = false;
            EyeCrit = false;
            StarvingLarva = false;
            Healthy = false;
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
    }
}