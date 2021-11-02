using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Front)]
	public class DarkCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Cloak");
			Tooltip.SetDefault("The cloak of a lonely dark warrior. \nDouble tap in any direction to do a dash!");
			DisplayName.AddTranslation(GameCulture.German, "Dunkelumhang");
			Tooltip.AddTranslation(GameCulture.German, "Der Umhang eines einsamen dunklen Kriegers \nDoppelklicke in eine richtung um einen dash auszuführen.");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 46;
			item.accessory = true;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(silver: 14);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ExampleDashPlayer mp = player.GetModPlayer<ExampleDashPlayer>();

			if (!mp.DashActive)
				return;

			player.eocDash = mp.DashTimer;
			player.armorEffectDrawShadowEOCShield = true;

			if (mp.DashTimer == ExampleDashPlayer.MAX_DASH_TIMER)
			{
				Vector2 newVelocity = player.velocity;

				if ((mp.DashDir == ExampleDashPlayer.DashUp && player.velocity.Y > -mp.DashVelocity) || (mp.DashDir == ExampleDashPlayer.DashDown && player.velocity.Y < mp.DashVelocity))
				{
					float dashDirection = mp.DashDir == ExampleDashPlayer.DashDown ? 1 : -1.3f;
					newVelocity.Y = dashDirection * mp.DashVelocity;
				}
				else if ((mp.DashDir == ExampleDashPlayer.DashLeft && player.velocity.X > -mp.DashVelocity) || (mp.DashDir == ExampleDashPlayer.DashRight && player.velocity.X < mp.DashVelocity))
				{
					int dashDirection = mp.DashDir == ExampleDashPlayer.DashRight ? 1 : -1;
					newVelocity.X = dashDirection * mp.DashVelocity;
				}

				player.velocity = newVelocity;
			}

			mp.DashTimer--;
			mp.DashDelay--;

			if (mp.DashDelay == 0)
			{
				mp.DashDelay = ExampleDashPlayer.MAX_DASH_DELAY;
				mp.DashTimer = ExampleDashPlayer.MAX_DASH_TIMER;
				mp.DashActive = false;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 18);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class ExampleDashPlayer : ModPlayer
	{
		public static readonly int DashDown = 0;
		public static readonly int DashUp = 1;
		public static readonly int DashRight = 2;
		public static readonly int DashLeft = 3;
		public int DashDir = -1;
		public bool DashActive = false;
		public int DashDelay = MAX_DASH_DELAY;
		public int DashTimer = MAX_DASH_TIMER;
		public readonly float DashVelocity = 12f;
		public static readonly int MAX_DASH_DELAY = 50;
		public static readonly int MAX_DASH_TIMER = 160;

		public override void ResetEffects()
		{
			bool dashAccessoryEquipped = false;

			for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
			{
				Item item = player.armor[i];
				if (item.type == ModContent.ItemType<DarkCloak>())
					dashAccessoryEquipped = true;
				else if (item.type == ItemID.EoCShield || item.type == ItemID.MasterNinjaGear || item.type == ItemID.Tabi)
					return;
			}
			if (!dashAccessoryEquipped || player.setSolar || player.mount.Active || DashActive)
				return;
			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[DashDown] < 15)
				DashDir = DashDown;
			else if (player.controlUp && player.releaseUp && player.doubleTapCardinalTimer[DashUp] < 15)
				DashDir = DashUp;
			else if (player.controlRight && player.releaseRight && player.doubleTapCardinalTimer[DashRight] < 15)
				DashDir = DashRight;
			else if (player.controlLeft && player.releaseLeft && player.doubleTapCardinalTimer[DashLeft] < 15)
				DashDir = DashLeft;
			else
				return;  

			DashActive = true;
		}
	}
}
