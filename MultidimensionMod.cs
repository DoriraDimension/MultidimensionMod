using MultidimensionMod.Items.Materials;
using MultidimensionMod.Biomes;
using MultidimensionMod.UI;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.UI;
using Terraria.Localization;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace MultidimensionMod
{
	public class MultidimensionMod : Mod
	{
		//Many things here in the mod are made possible by Ancients Awakened, so pay them a visit!
		internal static MultidimensionMod Instance;

		internal bool vanillaLoaded = true;

		public static int DimensiumEuronen;

        public UserInterface TradingUILayer;

        public TradingUI TradingUIElement;

        //Thanks to Lion8cake for the help with the background and heat distortion ILs.
        public override void Load()
		{
			DimensiumEuronen = CustomCurrencyManager.RegisterCurrency(new MDCurrency(ModContent.ItemType<Dimensium>(), 999L, "Dimensium"));
			Terraria.IL_Main.DrawUnderworldBackgroudLayer += ILMainDrawUnderworldBackgroundLayer;
			//Terraria.IL_Main.Player.UpdateBiomes += NoHeap;
			//IL.Terraria.Liquid.Update += Evaporation;
			SkyManager.Instance["MadnessMoonSky"] = new MadnessMoonSky();
			Filters.Scene["MultidimensionMod:Madness"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.8f, 0.6f, 0.2f).UseOpacity(0.5f), EffectPriority.High);
			base.Load();
        }

		#region Madness looky looky
		public static void PremultiplyTexture(Texture2D texture)
		{
			Color[] buffer = new Color[texture.Width * texture.Height];
			texture.GetData(buffer);
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = Color.FromNonPremultiplied(buffer[i].R, buffer[i].G, buffer[i].B, buffer[i].A);
			}
			texture.SetData(buffer);
		}

		private void PremultiplyTextures()
		{
			Main.QueueMainThreadAction(() =>
			{
				PremultiplyTexture(ModContent.Request<Texture2D>("MultidimensionMod/Biomes/MadnessMoonEye", AssetRequestMode.ImmediateLoad).Value);
			});
		}
		#endregion

		#region Frozen Underworld BG IL
		public static float FUTransition { get; set; }

		private void ILMainDrawUnderworldBackgroundLayer(ILContext il)
		{
			var c = new ILCursor(il);
			c.GotoNext(i => i.MatchStloc(0));
			c.Index++;

			c.EmitDelegate(() => // Transition thingy
			{
				if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
				{
					FUTransition += 0.05f;
					if (FUTransition > 1f)
					{
						FUTransition = 1f;
					}
				}
				else
				{
					FUTransition -= 0.05f;
					if (FUTransition < 0f)
					{
						FUTransition = 0f;
					}
				}
			});

			c.GotoNext(i => i.MatchRet())
				.Emit(OpCodes.Ldarg_0)
				.Emit(OpCodes.Ldarg_1)
				.Emit(OpCodes.Ldarg_2)
				.Emit(OpCodes.Ldarg_3);
			c.EmitDelegate<Action<bool, Vector2, float, int>>((flat, screenOffset, pushUp, layerTextureIndex) =>
			{
				int num27 = Main.underworldBG[layerTextureIndex];
				var assets = new Asset<Texture2D>[TextureAssets.Underworld.Length];
				for (int i = 0; i < TextureAssets.Underworld.Length; i++)
				{
					assets[i] = ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/FU" + (i + 1));
				}

				Asset<Texture2D> asset = assets[num27];
				Texture2D value5 = asset.Value;
				Vector2 vec3 = new Vector2(value5.Width, value5.Height) * 0.5f;
				float num26 = flat ? 1f : (layerTextureIndex * 2) + 3f;
				var value4 = new Vector2(1f / num26);
				var value3 = new Rectangle(0, 0, value5.Width, value5.Height);
				float num25 = 1.3f;
				Vector2 zero = Vector2.Zero;
				int num24 = 0;
				switch (num27)
				{
					case 1:
						{
							int num19 = (int)(Main.GlobalTimeWrappedHourly * 8f) % 4;
							value3 = new Rectangle((num19 >> 1) * (value5.Width >> 1), num19 % 2 * (value5.Height >> 1),
								value5.Width >> 1, value5.Height >> 1);
							vec3 *= 0.5f;
							zero.Y += 175f;
							break;
						}
					case 2:
						zero.Y += 100f;
						break;
					case 3:
						zero.Y += 75f;
						break;
					case 4:
						num25 = 0.5f;
						zero.Y -= 0f;
						break;
					case 5:
						zero.Y += num24;
						break;
					case 6:
						{
							int num20 = (int)(Main.GlobalTimeWrappedHourly * 8f) % 4;
							value3 = new Rectangle(num20 % 2 * (value5.Width >> 1), (num20 >> 1) * (value5.Height >> 1),
								value5.Width >> 1, value5.Height >> 1);
							vec3 *= 0.5f;
							zero.Y += num24;
							zero.Y += -60f;
							break;
						}
					case 7:
						{
							int num21 = (int)(Main.GlobalTimeWrappedHourly * 8f) % 4;
							value3 = new Rectangle(num21 % 2 * (value5.Width >> 1), (num21 >> 1) * (value5.Height >> 1),
								value5.Width >> 1, value5.Height >> 1);
							vec3 *= 0.5f;
							zero.Y += num24;
							zero.X -= 400f;
							zero.Y += 90f;
							break;
						}
					case 8:
						{
							int num22 = (int)(Main.GlobalTimeWrappedHourly * 8f) % 4;
							value3 = new Rectangle(num22 % 2 * (value5.Width >> 1), (num22 >> 1) * (value5.Height >> 1),
								value5.Width >> 1, value5.Height >> 1);
							vec3 *= 0.5f;
							zero.Y += num24;
							zero.Y += 90f;
							break;
						}
					case 9:
						zero.Y += num24;
						zero.Y -= 30f;
						break;
					case 10:
						zero.Y += 250f * num26;
						break;
					case 11:
						zero.Y += 100f * num26;
						break;
					case 12:
						zero.Y += 20f * num26;
						break;
					case 13:
						{
							zero.Y += 20f * num26;
							int num23 = (int)(Main.GlobalTimeWrappedHourly * 8f) % 4;
							value3 = new Rectangle(num23 % 2 * (value5.Width >> 1), (num23 >> 1) * (value5.Height >> 1),
									value5.Width >> 1, value5.Height >> 1);
							vec3 *= 0.5f;
							break;
						}
				}

				if (flat)
				{
					num25 *= 1.5f;
				}

				vec3 *= num25;
				SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / value4.X);
				if (flat)
				{
					zero.Y += ((TextureAssets.Underworld[0].Height() >> 1) * 1.3f) - vec3.Y;
				}

				zero.Y -= pushUp;
				float num18 = num25 * value3.Width;
				int num17 = (int)((int)((screenOffset.X * value4.X) - vec3.X + zero.X - (Main.screenWidth >> 1)) / num18);
				vec3 = vec3.Floor();
				int num16 = (int)Math.Ceiling(Main.screenWidth / num18);
				int num15 = (int)(num25 * ((value3.Width - 1) / value4.X));
				Vector2 vector =
					((new Vector2((num17 - 2) * num15, Main.UnderworldLayer * 16f) + vec3 - screenOffset) * value4) +
					screenOffset - Main.screenPosition - vec3 + zero;
				vector = vector.Floor();
				while (vector.X + num18 < 0f)
				{
					num17++;
					vector.X += num18;
				}

				for (int i = num17 - 2; i <= num17 + 4 + num16; i++)
				{
					Main.spriteBatch.Draw(value5, vector, value3, Color.White * FUTransition, 0f,
						Vector2.Zero, num25, SpriteEffects.None, 0f);
					if (layerTextureIndex == 0)
					{
						int num14 = (int)(vector.Y + (value3.Height * num25));
						Main.spriteBatch.Draw(TextureAssets.BlackTile.Value,
						new Rectangle((int)vector.X, num14, (int)(value3.Width * num25),
							Math.Max(0, Main.screenHeight - num14)),
							new Color(6, 5, 6) * FUTransition);
					}
					vector.X += num18;
				}
			});
		}
		#endregion

		#region Frozen Underworld heat distortion IL
		private void NoHeap(ILContext il)
		{
			var c = new ILCursor(il);
			try
			{
				c.GotoNext(MoveType.After,
					i => i.MatchLdstr("HeatDistortion"),
					i => i.MatchLdsfld<Main>("UseHeatDistortion"));

				c.EmitDelegate((bool useHeatDistortion) => {
					if (Main.LocalPlayer.InModBiome<FrozenUnderworld>())
					{
						return false;
					}
					return useHeatDistortion;
				});
			}
			catch (Exception e)
			{
				Logger.Error(e.Message);
			}
		}
		#endregion
	}

	public class MDSystem : ModSystem
	{
		public static MDSystem Instance { get; private set; }

        public UserInterface TradingUILayer;

        public TradingUI TradingUIElement;
        public MDSystem()
		{
			Instance = this;
		}
		public bool Initialized;

		public UserInterface TitleUILayer;
		public TitleCard TitleCardUIElement;

		public override void Load()
		{
			if (!Main.dedServ)
			{
				TitleUILayer = new UserInterface();
				TitleCardUIElement = new TitleCard();
				TitleUILayer.SetState(TitleCardUIElement);

                TradingUILayer = new UserInterface();
                TradingUIElement = new TradingUI();
                TradingUILayer.SetState(TradingUIElement);
            }
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			layers.Insert(layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text")), new LegacyGameInterfaceLayer("GUI Menus",
				delegate
				{
					return true;
				}, InterfaceScaleType.UI));
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				AddInterfaceLayer(layers, TitleUILayer, TitleCardUIElement, MouseTextIndex + 3, TitleCard.Showing, "Title Card");
                AddInterfaceLayer(layers, TradingUILayer, TradingUIElement, MouseTextIndex + 7, TradingUI.Visible, "Trade");
            }
		}

		public static void AddInterfaceLayer(List<GameInterfaceLayer> layers, UserInterface userInterface, UIState state, int index, bool visible, string customName = null) //Code created by Scalie
		{
			string name;
			if (customName == null)
			{
				name = state.ToString();
			}
			else
			{
				name = customName;
			}
			layers.Insert(index, new LegacyGameInterfaceLayer("MultidimensionMod: " + name,
				delegate
				{
					if (visible)
					{
						userInterface.Update(Main._drawInterfaceGameTime);
						state.Draw(Main.spriteBatch);
					}
					return true;
				}, InterfaceScaleType.UI));
		}

        public override void UpdateUI(GameTime gameTime)
        {
            if (TradingUILayer?.CurrentState != null && TradingUI.Visible)
                TradingUILayer.Update(gameTime);
        }
    }
}