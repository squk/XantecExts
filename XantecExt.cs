using UnityEngine;
using System.Collections;

namespace XantecExt
{
	public class XGames
	{
		public static void Authenticate()
		{
			#if UNITY_ANDROID
			PlayGameServices.authenticate();
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.authenticateLocalPlayer();
			#endif
		}

		public static void ShowAchievements()
		{
			#if UNITY_ANDROID
			PlayGameServices.showAchievements();
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.showAchievements();
			#endif
		}

		public static void ShowAllLeaderboards()
		{
			#if UNITY_ANDROID
			PlayGameServices.showLeaderboards();
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
			#endif
		}

		public static void ShowLeaderboard(string leaderboardID)
		{
			#if UNITY_ANDROID
			PlayGameServices.showLeaderboard(leaderboardID, GPGLeaderboardTimeScope.AllTime );
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
			#endif
		}
	}
	public class XAds
	{
		public static bool initialized = false;

		public static void Show()
		{
			#if UNITY_ANDROID
			if(!initialized)
			{
				AdMobAndroid.init( "ADMOB ID" );
				AdMobAndroid.createBanner( AdMobAndroidAd.smartBanner, AdMobAdPlacement.BottomCenter );
				initialized = true;
			}
			else
			{
				AdMobAndroid.refreshAd();
				AdMobAndroid.hideBanner(false);
			}
			#endif
			#if UNITY_IPHONE
			AdBinding.createAdBanner( true );
			#endif
		}
		
		public static void Hide()
		{
			#if UNITY_ANDROID
			AdMobAndroid.hideBanner(true);
			#endif
			#if UNITY_IPHONE
			AdBinding.destroyAdBanner();
			#endif
		}
	}

	public class XAchievement
	{
		public static void Unlock(string[] achievementIDs)
		{
			#if UNITY_ANDROID
			PlayGameServices.unlockAchievement(achievementIDs[0]);
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.reportAchievement(achievementIDs[1], 100);
			#endif
		}
	}

	public class XLeaderboard
	{
		public static void submitScore(string[] leaderboards, int score)
		{
			#if UNITY_ANDROID
			PlayGameServices.submitScore(leaderboards[0], score);
			#endif
			#if UNITY_IPHONE
			GameCenterBinding.reportScore(score, leaderboards[1]);
			#endif
		}
	}

	public class XEtcetera
	{
		public static void showReviewDialog(string appID)
		{
			#if UNITY_IPHONE
			EtceteraBinding.askForReview( "Do you like this game?", "Please review the game if you do!", appID );
			#endif
			
			#if UNITY_ANDROID
			EtceteraAndroid.resetAskForReview();
			EtceteraAndroid.askForReviewNow( "Do you like this game?", "Please review the game if you do!" );
			#endif
		}
	}
}