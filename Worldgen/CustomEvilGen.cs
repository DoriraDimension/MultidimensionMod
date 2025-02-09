using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using MultidimensionMod.Walls;
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using System.Linq;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using Terraria.GameContent.Generation;
using static tModPorter.ProgressUpdate;
using static Terraria.WorldGen;

namespace MultidimensionMod.Worldgen
{
    public class CustomEvilGen : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{
			GenPass currentPass;
			
			int corruption = tasks.FindIndex(genPass => genPass.Name == "Corruption");
			if (corruption != -1)
			{
				currentPass = new CustomEvilGenTask();
				tasks[corruption] = currentPass;
			}
			
		}
	}
	public class CustomEvilGenTask : GenPass
	{
		public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 1; //unknown size, assume small
        }

		public CustomEvilGenTask() : base("CustomEvilGenTask", 1094.237f) { }
		//Re-Logic explain what this actually is
	    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration){
			int num778 = Main.maxTilesX;
			int num779 = 0;
			int num780 = Main.maxTilesX;
			int num781 = 0;
			for (int num782 = 0; num782 < Main.maxTilesX; num782++) {
				for (int num783 = 0; (double)num783 < Main.worldSurface; num783++) {
					if (Main.tile[num782, num783].HasTile) {
						if (Main.tile[num782, num783].TileType == 60) {
							if (num782 < num778)
								num778 = num782;

							if (num782 > num779)
								num779 = num782;
						}
						else if (Main.tile[num782, num783].TileType == 147 || Main.tile[num782, num783].TileType == 161) {
							if (num782 < num780)
								num780 = num782;

							if (num782 > num781)
								num781 = num782;
						}
					}
				}
			}

			int num784 = 10;
			num778 -= num784;
			num779 += num784;
			num780 -= num784;
			num781 += num784;
			int num785 = 500;
			int num786 = 100;
			bool flag49 = crimson;
			double num787 = (double)Main.maxTilesX * 0.00045;
			if (remixWorldGen) {
				num787 *= 2.0;
			}
			else if (tenthAnniversaryWorldGen) {
				num785 *= 2;
				num786 *= 2;
			}

			if (drunkWorldGen) {
				flag49 = true;
				num787 /= 2.0;
			}

			if (flag49) {
				progress.Message = Lang.gen[72].Value;
				for (int num788 = 0; (double)num788 < num787; num788++) {
					int num789 = num780;
					int num790 = num781;
					int num791 = num778;
					int num792 = num779;
					double value15 = (double)num788 / num787;
					progress.Set(value15);
					bool flag50 = false;
					int num793 = 0;
					int num794 = 0;
					int num795 = 0;
					while (!flag50) {
						flag50 = true;
						int num796 = Main.maxTilesX / 2;
						int num797 = 200;
						if (drunkWorldGen) {
							num797 = 100;
							num793 = ((!GenVars.crimsonLeft) ? genRand.Next((int)((double)Main.maxTilesX * 0.5), Main.maxTilesX - num785) : genRand.Next(num785, (int)((double)Main.maxTilesX * 0.5)));
						}
						else {
							num793 = genRand.Next(num785, Main.maxTilesX - num785);
						}

						num794 = num793 - genRand.Next(200) - 100;
						num795 = num793 + genRand.Next(200) + 100;
						
						int worldSize = GetWorldSize();
						float FungusPositioningMultiplier = 1f;
						int FungusPositioningPlacement = 1;
						FungusPositioningPlacement = Main.dungeonX > Main.maxTilesX / 2 ? 0 : 1;
						FungusPositioningMultiplier = FungusPositioningPlacement == 0 ? 3.8f : 4.2f;
						int SFcentre = (int)(Main.maxTilesX / 7f * FungusPositioningMultiplier); 
						int SFradius = worldSize == 3 ? 500 : worldSize == 2 ? 420 : 260;
						int SFavoidanceLeft=SFcentre-SFradius;
						int SFavoidanceRight=SFcentre+SFradius;
						if (num794 < GenVars.evilBiomeBeachAvoidance)
							num794 = GenVars.evilBiomeBeachAvoidance;

						if (num795 > Main.maxTilesX - GenVars.evilBiomeBeachAvoidance)
							num795 = Main.maxTilesX - GenVars.evilBiomeBeachAvoidance;
						if(Enumerable.Range(SFavoidanceLeft,SFavoidanceRight).Contains(num793))
							flag50 = false;
						if (num793 < num794 + GenVars.evilBiomeAvoidanceMidFixer)
							num793 = num794 + GenVars.evilBiomeAvoidanceMidFixer;

						if (num793 > num795 - GenVars.evilBiomeAvoidanceMidFixer)
							num793 = num795 - GenVars.evilBiomeAvoidanceMidFixer;

						if (GenVars.dungeonSide < 0 && num794 < 400)
							num794 = 400;
						else if (GenVars.dungeonSide > 0 && num794 > Main.maxTilesX - 400)
							num794 = Main.maxTilesX - 400;

						if (num794 < GenVars.dungeonLocation + num786 && num795 > GenVars.dungeonLocation - num786)
							flag50 = false;
						

						if (!remixWorldGen) {
							if (!tenthAnniversaryWorldGen) {
								if (num793 > num796 - num797 && num793 < num796 + num797)
									flag50 = false;

								if (num794 > num796 - num797 && num794 < num796 + num797)
									flag50 = false;

								if (num795 > num796 - num797 && num795 < num796 + num797)
									flag50 = false;
							}

							if (num793 > GenVars.UndergroundDesertLocation.X && num793 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag50 = false;

							if (num794 > GenVars.UndergroundDesertLocation.X && num794 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag50 = false;

							if (num795 > GenVars.UndergroundDesertLocation.X && num795 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag50 = false;

							if (num794 < num790 && num795 > num789) {
								num789++;
								num790--;
								flag50 = false;
							}

							if (num794 < num792 && num795 > num791) {
								num791++;
								num792--;
								flag50 = false;
							}
						}
					}

					CrimStart(num793, (int)GenVars.worldSurfaceLow - 10);
					for (int num798 = num794; num798 < num795; num798++) {
						for (int num799 = (int)GenVars.worldSurfaceLow; (double)num799 < Main.worldSurface - 1.0; num799++) {
							if (Main.tile[num798, num799].HasTile) {
								int num800 = num799 + genRand.Next(10, 14);
								for (int num801 = num799; num801 < num800; num801++) {
									if (Main.tile[num798, num801].TileType == 60 && num798 >= num794 + genRand.Next(5) && num798 < num795 - genRand.Next(5))
										Main.tile[num798, num801].TileType = 662;
								}

								break;
							}
						}
					}

					double num802 = Main.worldSurface + 40.0;
					for (int num803 = num794; num803 < num795; num803++) {
						num802 += (double)genRand.Next(-2, 3);
						if (num802 < Main.worldSurface + 30.0)
							num802 = Main.worldSurface + 30.0;

						if (num802 > Main.worldSurface + 50.0)
							num802 = Main.worldSurface + 50.0;

						bool flag51 = false;
						for (int num804 = (int)GenVars.worldSurfaceLow; (double)num804 < num802; num804++) {
							if (Main.tile[num803, num804].HasTile) {
								if (Main.tile[num803, num804].TileType == 53 && num803 >= num794 + genRand.Next(5) && num803 <= num795 - genRand.Next(5))
									Main.tile[num803, num804].TileType = 234;

								if ((double)num804 < Main.worldSurface - 1.0 && !flag51) {
									if (Main.tile[num803, num804].TileType == 0) {
										grassSpread = 0;
										SpreadGrass(num803, num804, 0, 199);
									}
									else if (Main.tile[num803, num804].TileType == 59) {
										grassSpread = 0;
										SpreadGrass(num803, num804, 59, 662);
									}
								}

								flag51 = true;
								if (Main.tile[num803, num804].WallType == 216)
									Main.tile[num803, num804].WallType = 218;
								else if (Main.tile[num803, num804].WallType == 187)
									Main.tile[num803, num804].WallType = 221;

								if (Main.tile[num803, num804].TileType == 1) {
									if (num803 >= num794 + genRand.Next(5) && num803 <= num795 - genRand.Next(5))
										Main.tile[num803, num804].TileType = 203;
								}
								else if (Main.tile[num803, num804].TileType == 2) {
									Main.tile[num803, num804].TileType = 199;
								}
								else if (Main.tile[num803, num804].TileType == 60) {
									Main.tile[num803, num804].TileType = 662;
								}
								else if (Main.tile[num803, num804].TileType == 161) {
									Main.tile[num803, num804].TileType = 200;
								}
								else if (Main.tile[num803, num804].TileType == 396) {
									Main.tile[num803, num804].TileType = 401;
								}
								else if (Main.tile[num803, num804].TileType == 397) {
									Main.tile[num803, num804].TileType = 399;
								}
							}
						}
					}

					int num805 = genRand.Next(10, 15);
					for (int num806 = 0; num806 < num805; num806++) {
						int num807 = 0;
						bool flag52 = false;
						int num808 = 0;
						while (!flag52) {
							num807++;
							int num809 = genRand.Next(num794 - num808, num795 + num808);
							int num810 = genRand.Next((int)(Main.worldSurface - (double)(num808 / 2)), (int)(Main.worldSurface + 100.0 + (double)num808));
							while (oceanDepths(num809, num810)) {
								num809 = genRand.Next(num794 - num808, num795 + num808);
								num810 = genRand.Next((int)(Main.worldSurface - (double)(num808 / 2)), (int)(Main.worldSurface + 100.0 + (double)num808));
							}

							if (num807 > 100) {
								num808++;
								num807 = 0;
							}

							if (!Main.tile[num809, num810].HasTile) {
								for (; !Main.tile[num809, num810].HasTile; num810++) {
								}

								num810--;
							}
							else {
								while (Main.tile[num809, num810].HasTile && (double)num810 > Main.worldSurface) {
									num810--;
								}
							}

							if ((num808 > 10 || (Main.tile[num809, num810 + 1].HasTile && Main.tile[num809, num810 + 1].TileType == 203)) && !IsTileNearby(num809, num810, 26, 3)) {
								Place3x2(num809, num810, 26, 1);
								if (Main.tile[num809, num810].TileType == 26)
									flag52 = true;
							}

							if (num808 > 100)
								flag52 = true;
						}
					}
				}

				CrimPlaceHearts();
			}

			if (drunkWorldGen)
				flag49 = false;

			if (!flag49) {
				progress.Message = Lang.gen[20].Value;
				for (int num811 = 0; (double)num811 < num787; num811++) {
					int num812 = num780;
					int num813 = num781;
					int num814 = num778;
					int num815 = num779;
					double value16 = (double)num811 / num787;
					progress.Set(value16);
					bool flag53 = false;
					int num816 = 0;
					int num817 = 0;
					int num818 = 0;
					while (!flag53) {
						flag53 = true;
						int num819 = Main.maxTilesX / 2;
						int num820 = 200;
						num816 = ((!drunkWorldGen) ? genRand.Next(num785, Main.maxTilesX - num785) : (GenVars.crimsonLeft ? genRand.Next((int)((double)Main.maxTilesX * 0.5), Main.maxTilesX - num785) : genRand.Next(num785, (int)((double)Main.maxTilesX * 0.5))));
						num817 = num816 - genRand.Next(200) - 100;
						num818 = num816 + genRand.Next(200) + 100;
						if (num817 < GenVars.evilBiomeBeachAvoidance)
							num817 = GenVars.evilBiomeBeachAvoidance;

						if (num818 > Main.maxTilesX - GenVars.evilBiomeBeachAvoidance)
							num818 = Main.maxTilesX - GenVars.evilBiomeBeachAvoidance;

						if (num816 < num817 + GenVars.evilBiomeAvoidanceMidFixer)
							num816 = num817 + GenVars.evilBiomeAvoidanceMidFixer;

						if (num816 > num818 - GenVars.evilBiomeAvoidanceMidFixer)
							num816 = num818 - GenVars.evilBiomeAvoidanceMidFixer;

						if (num817 < GenVars.dungeonLocation + num786 && num818 > GenVars.dungeonLocation - num786)
							flag53 = false;

						if (!remixWorldGen) {
							if (!tenthAnniversaryWorldGen) {
								if (num816 > num819 - num820 && num816 < num819 + num820)
									flag53 = false;

								if (num817 > num819 - num820 && num817 < num819 + num820)
									flag53 = false;

								if (num818 > num819 - num820 && num818 < num819 + num820)
									flag53 = false;
							}

							if (num816 > GenVars.UndergroundDesertLocation.X && num816 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag53 = false;

							if (num817 > GenVars.UndergroundDesertLocation.X && num817 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag53 = false;

							if (num818 > GenVars.UndergroundDesertLocation.X && num818 < GenVars.UndergroundDesertLocation.X + GenVars.UndergroundDesertLocation.Width)
								flag53 = false;

							if (num817 < num813 && num818 > num812) {
								num812++;
								num813--;
								flag53 = false;
							}

							if (num817 < num815 && num818 > num814) {
								num814++;
								num815--;
								flag53 = false;
							}
						}
					}

					int num821 = 0;
					for (int num822 = num817; num822 < num818; num822++) {
						if (num821 > 0)
							num821--;

						if (num822 == num816 || num821 == 0) {
							for (int num823 = (int)GenVars.worldSurfaceLow; (double)num823 < Main.worldSurface - 1.0; num823++) {
								if (Main.tile[num822, num823].HasTile || Main.tile[num822, num823].WallType > 0) {
									if (num822 == num816) {
										num821 = 20;
										ChasmRunner(num822, num823, genRand.Next(150) + 150, makeOrb: true);
									}
									else if (genRand.Next(35) == 0 && num821 == 0) {
										num821 = 30;
										bool makeOrb = true;
										ChasmRunner(num822, num823, genRand.Next(50) + 50, makeOrb);
									}

									break;
								}
							}
						}

						for (int num824 = (int)GenVars.worldSurfaceLow; (double)num824 < Main.worldSurface - 1.0; num824++) {
							if (Main.tile[num822, num824].HasTile) {
								int num825 = num824 + genRand.Next(10, 14);
								for (int num826 = num824; num826 < num825; num826++) {
									if (Main.tile[num822, num826].TileType == 60 && num822 >= num817 + genRand.Next(5) && num822 < num818 - genRand.Next(5))
										Main.tile[num822, num826].TileType = 661;
								}

								break;
							}
						}
					}

					double num827 = Main.worldSurface + 40.0;
					for (int num828 = num817; num828 < num818; num828++) {
						num827 += (double)genRand.Next(-2, 3);
						if (num827 < Main.worldSurface + 30.0)
							num827 = Main.worldSurface + 30.0;

						if (num827 > Main.worldSurface + 50.0)
							num827 = Main.worldSurface + 50.0;

						bool flag54 = false;
						for (int num829 = (int)GenVars.worldSurfaceLow; (double)num829 < num827; num829++) {
							if (Main.tile[num828, num829].HasTile) {
								if (Main.tile[num828, num829].TileType == 53 && num828 >= num817 + genRand.Next(5) && num828 <= num818 - genRand.Next(5))
									Main.tile[num828, num829].TileType = 112;

								if ((double)num829 < Main.worldSurface - 1.0 && !flag54) {
									if (Main.tile[num828, num829].TileType == 0) {
										grassSpread = 0;
										SpreadGrass(num828, num829, 0, 23);
									}
									else if (Main.tile[num828, num829].TileType == 59) {
										grassSpread = 0;
										SpreadGrass(num828, num829, 59, 661);
									}
								}

								flag54 = true;
								if (Main.tile[num828, num829].WallType == 216)
									Main.tile[num828, num829].WallType = 217;
								else if (Main.tile[num828, num829].WallType == 187)
									Main.tile[num828, num829].WallType = 220;

								if (Main.tile[num828, num829].TileType == 1) {
									if (num828 >= num817 + genRand.Next(5) && num828 <= num818 - genRand.Next(5))
										Main.tile[num828, num829].TileType = 25;
								}
								else if (Main.tile[num828, num829].TileType == 2) {
									Main.tile[num828, num829].TileType = 23;
								}
								else if (Main.tile[num828, num829].TileType == 60) {
									Main.tile[num828, num829].TileType = 661;
								}
								else if (Main.tile[num828, num829].TileType == 161) {
									Main.tile[num828, num829].TileType = 163;
								}
								else if (Main.tile[num828, num829].TileType == 396) {
									Main.tile[num828, num829].TileType = 400;
								}
								else if (Main.tile[num828, num829].TileType == 397) {
									Main.tile[num828, num829].TileType = 398;
								}
							}
						}
					}

					for (int num830 = num817; num830 < num818; num830++) {
						for (int num831 = 0; num831 < Main.maxTilesY - 50; num831++) {
							if (Main.tile[num830, num831].HasTile && Main.tile[num830, num831].TileType == 31) {
								int num832 = num830 - 13;
								int num833 = num830 + 13;
								int num834 = num831 - 13;
								int num835 = num831 + 13;
								for (int num836 = num832; num836 < num833; num836++) {
									if (num836 > 10 && num836 < Main.maxTilesX - 10) {
										for (int num837 = num834; num837 < num835; num837++) {
											Tile annoyingTile= Main.tile[num836, num837];
											if (Math.Abs(num836 - num830) + Math.Abs(num837 - num831) < 9 + genRand.Next(11) && genRand.Next(3) != 0 && Main.tile[num836, num837].TileType != 31) {
												annoyingTile.HasTile=true;
												Main.tile[num836, num837].TileType = 25;
												if (Math.Abs(num836 - num830) <= 1 && Math.Abs(num837 - num831) <= 1)
													annoyingTile.HasTile=false;
											}

											if (Main.tile[num836, num837].TileType != 31 && Math.Abs(num836 - num830) <= 2 + genRand.Next(3) && Math.Abs(num837 - num831) <= 2 + genRand.Next(3))
												annoyingTile.HasTile=false;
										}
									}
								}
							}
						}
					}
				}
			}
		}

	}
}