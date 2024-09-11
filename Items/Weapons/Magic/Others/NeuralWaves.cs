using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class NeuralWaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.5f;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 1, 36, 0);
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<NeuralWave>();
			Item.shootSpeed = 10f;
			Item.crit = 8;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.NeuralWaves.Lore"))
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 18; i++)
			{
				int numProj = 2;
				float rotation = MathHelper.ToRadians(50f);
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
				Projectile.NewProjectile(source, player.Center.X + 20, player.Center.Y - 16, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<NeuralWave>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			position = player.Center;
		}

		public override void UseItemFrame(Player player)
		{
			player.bodyFrame.Y = 5 * player.bodyFrame.Height;
		}
	}
}