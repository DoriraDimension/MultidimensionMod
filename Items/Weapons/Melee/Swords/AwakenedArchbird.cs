using MultidimensionMod.Common.Players;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Dusts;
using MultidimensionMod.Buffs.Cooldowns;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;
using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria.Audio;
using MultidimensionMod.Projectiles.Ranged;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class AwakenedArchbird : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 5f;
			Item.crit = 12;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (!Main.hardMode)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.Items.AwakenedArchbird.Locked"))
                {
                    OverrideColor = Color.Red
                };
                tooltips.Add(line);
            }
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.AwakenedArchbird.Lore"))
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

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (!Main.hardMode)
            {
                return false;
            }
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ProjectileID.None;
                Item.noMelee = true;
                if (player.GetModPlayer<MDPlayer>().flamescarReset >= 1)
                {
                    return false;
                }
            }
            else
            {
                Item.noMelee = false;
                SetDefaults();
            }
            return base.CanUseItem(player);
        }

        private int amountUsed = 1;

        public override bool? UseItem(Player player)
        {
            int damage = 20 * amountUsed;
            if (player.altFunctionUse == 2)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath62 with { Pitch = -0.50f }, player.position);
                player.GetModPlayer<MDPlayer>().awakenedFlamescar = true;
                if (player.HasBuff(ModContent.BuffType<InnerEmber>()))
                {
                    damage = 40;
                    player.AddBuff(ModContent.BuffType<BlazingSuffering>(), 300);
                }
                if (!player.HasBuff(ModContent.BuffType<InnerEmber>()) || !player.GetModPlayer<MDPlayer>().awakenedFlamescar)
                {
                    damage = 20;
                }
                player.statLife -= damage;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.HealEffect(-damage, true);
                }
                if (player.statLife <= 0)
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason(player.name + Language.GetTextValue("Mods.MultidimensionMod.DeathMessages.Flamescar")), 1000.0, 0);
                }
            }
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (player.GetModPlayer<MDPlayer>().awakenedFlamescar)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CrimsonTorch);
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (player.GetModPlayer<MDPlayer>().awakenedFlamescar)
			{
				target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 120);
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

            if (player.GetModPlayer<MDPlayer>().awakenedFlamescar)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
                    velocity *= 1f - Main.rand.NextFloat(0.3f);
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<SpiritEmber>(), (int)((double)(float)damage * 0.5), knockback, player.whoAmI);
                }
                for (int i = 0; i < 2; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
                    velocity *= 1f - Main.rand.NextFloat(0.3f);
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<SeethingEmber>(), (int)((double)(float)damage * 0.3), knockback, player.whoAmI);
                }
            }
            return false;
		}
	}
}