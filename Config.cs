using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace CustomRespawnTime {
	public static class Config {
		public static bool UseOnyxSteelPref = true;
		public static bool UsePresetTime = false;
		public static bool UseMultiplier = false;
		public static double RespawnSeconds = 10.0;
		public static double RespawnMultiplier = 0.33;

		//The file will be stored in "Terraria/ModLoader/Mod Configs/CustomRespawnTime.json"
		public static readonly string SubConfigFolder = "Mod Configs";
		public static readonly string ConfigFileName = "CustomRespawnTime.json";
		static string ConfigPath = Path.Combine( Main.SavePath, Config.SubConfigFolder, Config.ConfigFileName );

		static Preferences Configuration = new Preferences( ConfigPath );

		public static void Load() {
			//Reading the config file
			bool success = ReadConfig();

			if( !success ) {
				ErrorLogger.Log( "Failed to read CustomRespawnTime's config file! Recreating config..." );
				CreateConfig();
			}
		}

		//Returns "true" if the config file was found and successfully loaded.
		static bool ReadConfig() {
			if( Configuration.Load() ) {
				Configuration.Get( "UseOnyxSteelPref", ref UseOnyxSteelPref );
				Configuration.Get( "UsePresetTime", ref UsePresetTime );
				Configuration.Get( "UseMultiplier", ref UseMultiplier );
				Configuration.Get( "RespawnSeconds", ref RespawnSeconds );
				Configuration.Get( "RespawnMultiplier", ref RespawnMultiplier );
				return true;
			}
			return false;
		}

		//It would make more sense to call this method SaveConfig(), but since we don't have an in-game editor or anything, this will only be called if a config file wasn't found or it's invalid.
		static void CreateConfig() {
			Configuration.Clear();
			Configuration.Put( "UseOnyxSteelPref", UseOnyxSteelPref );
			Configuration.Put( "UsePresetTime", UsePresetTime );
			Configuration.Put( "UseMultiplier", UseMultiplier );
			Configuration.Put( "RespawnSeconds", RespawnSeconds );
			Configuration.Put( "RespawnMultiplier", RespawnMultiplier );
			Configuration.Save();
		}
	}
}