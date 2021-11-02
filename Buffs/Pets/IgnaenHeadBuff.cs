using MultidimensionMod.Buffs.Pets;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Pets
{
	public class IgnaenHeadBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Archtyrant's Head");
			Description.SetDefault("The head of a demonic lord is following you.");
			DisplayName.AddTranslation(GameCulture.German, "Erztyranns Kopf");
			Description.AddTranslation(GameCulture.German, "Der Kopf eines dämonischen Lords folgt dir.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<MDPlayer>().IgnaenHead = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.IgnaenHead>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.IgnaenHead>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}