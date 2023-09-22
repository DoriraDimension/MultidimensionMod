using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
    public class BloodyMary : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bloody Mary");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 46;
			Item.height = 52;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.autoReuse = true;
		    Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<MarysWrath>(), 1200);
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.Center.X, player.Center.Y, 0f, -15f, ModContent.ProjectileType<Mary>(), (int)((double)((float)Item.damage) * 1f), 0f, Main.myPlayer);
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
			{
				Item.damage = 100;
				Item.noMelee = true;
				Item.noUseGraphic = true;
                return player.ownedProjectileCounts[ModContent.ProjectileType<Mary>()] < 1;
            }
			else
			{
                SetDefaults();
                Item.noMelee = false;
                Item.noUseGraphic = false;
            }
			return true;
        }
    }
}