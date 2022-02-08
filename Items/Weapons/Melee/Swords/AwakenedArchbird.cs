using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class AwakenedArchbird : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Awakened Archbird");
			Tooltip.SetDefault("A sword shaped like a legendary bird found in ancient depictions in the desert, it is full of dark flames.\nShoots shadowflame tentacles when swung and slows enemies when hit for 5 seconds.\nInscriptions say that one day the archbird will swoop down and bathe the earth in it's dark flames.");
			DisplayName.AddTranslation(GameCulture.German, "Erwachter Erzvogel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert geformt wie ein legendärer Vogel aus alten Abbildungen in der Wüste, es ist voll von dunklen Flammen\nSchießt Schattenflammen Tentakel wenn geschwungen und verlangsamt Gegner wenn getroffen für 5 Sekunden.\nInschriften besagen das eines Tages der Erzvogel hinabgleiten wird und die Erde in seinen dunklen Flammen badet.");
		}

		public override void SetDefaults()
		{
			item.damage = 98;
			item.melee = true;
			item.width = 118;
			item.height = 118;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 5;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileID.ShadowFlame;
			item.shootSpeed = 10f;
			item.crit = 12;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (27));
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 320);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ProjectileID.ShadowFlame;

			{
				int numberProjectiles = 2 + Main.rand.Next(1);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DormantKing>());
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 3);
			recipe.AddIngredient(2766, 7);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}