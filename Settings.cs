using ModSettings;
using UnityEngine;

namespace WildlifeTuning
{
	public struct CreatureConfig
	{
		public float runSpeedScaleRangeMin;
		public float runSpeedScaleRangeMax;
		public float retreatSpeedScaleRangeMin;
		public float retreatSpeedScaleRangeMax;
		public float chasePlayerSpeedScaleRangeMin;
		public float chasePlayerSpeedScaleRangeMax;
		public float turnDegreesSpeedScaleRangeMin;
		public float turnDegreesSpeedScaleRangeMax;
		public float turnDegreesSpeedScaleRangeRareMin;
		public float turnDegreesSpeedScaleRangeRareMax;
	}
	internal class WildlifeTuningSettings : JsonModSettings
	{
		[Name("Run SpeedScale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float runSpeedScaleRangeMin = 0.95f;
		[Name("Run Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float runSpeedScaleRangeMax = 1.2f;

		[Name("Retreat SpeedScale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float retreatSpeedScaleRangeMin = 0.95f;
		[Name("Retreat Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float retreatSpeedScaleRangeMax = 1.2f;

		[Name("Wolf Chase Player SpeedScale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float wolfChasePlayerSpeedScaleRangeMin = 0.9f;
		[Name("Wolf Chase Player Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float wolfChasePlayerSpeedScaleRangeMax = 1.1f;
		
		[Name("Turning Degrees SpeedScale Min")]
		[Description("")]
		[Slider(0.9f, 1.1f, 20)]
		public float turnDegreesSpeedScaleRangeMin = 0.9f;
		[Name("Turning Degrees Speed Scale Max")]
		[Description("")]
		[Slider(0.9f, 1.1f, 20)]
		public float turnDegreesSpeedScaleRangeMax = 1.1f;

		[Name("Stalk SpeedScale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkSpeedScaleRangeMin = 0.95f;
		[Name("Stalk Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkSpeedScaleRangeMax = 1.2f;
	
		[Name("Stalk Slowly Speed Scale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkSlowlySpeedScaleRangeMin = 0.95f;
		[Name("Stalk Slowly Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkSlowlySpeedScaleRangeMax = 1.2f;

		[Name("Stalk Catch Up Speed Scale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkCatchUpSpeedScaleRangeMin = 0.95f;
		[Name("Stalk Catch Up Speed Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float stalkCatchUpSpeedScaleRangeMax = 1.2f;

		[Name("Stalk Curios Stalking Chance Scale Min")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float curiosEnterStalkingScaleRangeMin = 0.9f;
		[Name("Stalk Curios Stalking Chance Scale Max")]
		[Description("")]
		[Slider(0.8f, 1.5f, 70)]
		public float curiosEnterStalkingScaleRangeMax = 1.1f;

		[Name("Wolf Base Hours Between Respawn Scale")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float wolfHoursBetweenRespawnBaseScale = 1.5f;
	
		[Name("Hours Between Respawn Scale Min")]
		[Description("")]
		[Slider(0.2f, 3f, 280)]
		public float hoursBetweenRespawnScaleMin = 0.9f;
		[Name("Hours Between Respawn Scale Max")]
		[Description("")]
		[Slider(0.2f, 5f, 480)]
		public float hoursBetweenRespawnScaleMax = 2f;

		[Name("Rare Hours Between Respawn Scale Chance")]
		[Description("")]
		[Slider(0f, 1f, 100)]
		public float chanceHoursBetweenRespawnRareScale = 0.15f;
		
		[Name("Hours Between Respawn Scale Min")]
		[Description("")]
		[Slider(0.2f, 5f, 480)]
		public float hoursBetweenRespawnRareScaleMin = 0.5f;
		[Name("Hours Between Respawn Scale Max")]
		[Description("")]
		[Slider(0.2f, 10f, 980)]
		public float hoursBetweenRespawnRareScaleMax = 3f;

		[Name("Lose Interest (Curios) Min")]
		[Description("")]
		[Slider(-10, 0, 10)]
		public int curiosLoseInterestChanceOffsetMin = -10;
		[Name("Lose Interest (Curios) Max")]
		[Description("")]
		[Slider(0, 50f, 50)]
		public int curiosLoseInterestChanceOffsetMax = 10;

		[Name("Lose Interest (Stalking) Min")]
		[Description("")]
		[Slider(-1, 0)]
		public int stalkingLoseInterestChanceOffsetMin = 0;
		[Name("Lose Interest (Stalking) Max")]
		[Description("")]
		[Slider(0, 50f)]
		public int stalkingLoseInterestChanceOffsetMax = 10;

		[Name("Struggle Damage Scale Min")]
		[Description("")]
		[Slider(0.7f, 2f, 130)]
		public float struggleDamageScaleRangeMin = 0.9f;
		[Name("Struggle Damage Scale Max")]
		[Description("")]
		[Slider(0.75f, 3f, 225)]
		public float struggleDamageScaleRangeMax = 1.5f;

		[Name("Rabbit Base Hours Between Respawn Scale")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float rabbitHoursBetweenRespawnBaseScale = 1f;

		[Name("Cancel Snare Rabbit Chance Min")]
		[Description("")]
		[Slider(0, 100)]
		public int cancelSnareRollChance = 25;
		
		[Name("Deer Base Hours Between Respawn Scale")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float deerHoursBetweenRespawnBaseScale = 1f;

		[Name("HP Scale Min")]
		[Description("")]
		[Slider(0.8f, 2f, 120)]
		public float HPScaleMin = 0.8f;
		[Name("HP Scale Max")]
		[Description("")]
		[Slider(1f, 2f, 100)]
		public float HPScaleMax = 1.5f;

		[Name("Wold Attack Range Scale Up Max")]
		[Description("")]
		[Slider(1f, 2f, 10)]
		public float wolfAttackRangeScaleUpMax = 1.3f;

		[Name("Smell Range Scale Min")]
		[Description("")]
		[Slider(0.6f, 2f, 140)]
		public float smellRangeScaleMin = 0.75f;
		[Name("Smell Range Scale Max")]
		[Description("")]
		[Slider(1f, 2f, 100)]
		public float smellRangeScaleMax = 1.5f;

		[Name("Detect Range Scale Min")]
		[Description("")]
		[Slider(0.6f, 2f, 140)]
		public float detectRangeScaleMin = 0.75f;
		[Name("Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 2f, 100)]
		public float detectRangeScaleMax = 1.5f;

		[Name("Rabbit Detect Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float rabbitDetectRangeScaleMin = 1.5f;
		[Name("Rabbit Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float rabbitDetectRangeScaleMax = 2.5f;
		[Name("Wolf Detect Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float wolfDetectRangeScaleMin = 0.75f;
		[Name("Wolf Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float wolfDetectRangeScaleMax = 1.25f;

		[Name("Bear Detect Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float bearDetectRangeScaleMin = 0.75f;
		[Name("Bear Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float bearDetectRangeScaleMax = 1.25f;

		[Name("Moose Detect Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float mooseDetectRangeScaleMin = 0.75f;
		[Name("Moose Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float mooseDetectRangeScaleMax = 1.25f;

		[Name("Cougar Detect Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float cougarDetectRangeScaleMin = 0.75f;
		[Name("Cougar Detect Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float cougarDetectRangeScaleMax = 1.25f;
		[Name("Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.6f, 2f, 140)]
		public float hearFootstepRangeScaleMin = 0.75f;
		[Name("Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 2f, 100)]
		public float hearFootstepRangeScaleMax = 1.5f;
	
		[Name("Rabbit Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float rabbitHearFootstepRangeScaleMin = 1.5f;
		[Name("Rabbit Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float rabbitHearFootstepRangeScaleMax = 2.5f;
		[Name("Wolf Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float wolfHearFootstepRangeScaleMin = 0.75f;
		[Name("Wolf Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float wolfHearFootstepRangeScaleMax = 1.25f;
		[Name("Bear Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float bearHearFootstepRangeScaleMin = 0.75f;
		[Name("Bear Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float bearHearFootstepRangeScaleMax = 1.25f;

		[Name("Moose Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float mooseHearFootstepRangeScaleMin = 0.75f;
		[Name("Moose Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float mooseHearFootstepRangeScaleMax = 1.25f;

		[Name("Cougar Hear Footstep Range Scale Min")]
		[Description("")]
		[Slider(0.5f, 3f, 250)]
		public float cougarHearFootstepRangeScaleMin = 0.75f;
		[Name("Cougar Hear Footstep Range Scale Max")]
		[Description("")]
		[Slider(1f, 5f, 400)]
		public float cougarHearFootstepRangeScaleMax = 1.25f;

		[Name("Flee Chance When Detected Offset Min")]
		[Description("")]
		[Slider(-100, 100)]
		public int fleeChanceWhenDetectedOffsetMin = -5;
		[Name("Flee Chance When Detected Offset Max")]
		[Description("")]
		[Slider(-100, 100)]
		public int fleeChanceWhenDetectedOffsetMax = 15;

		[Name("Wolf Flee Chance When Detected Offset Min")]
		[Description("")]
		[Slider(-100, 100)]
		public int wolfFleeChanceWhenDetectedOffsetMin = -5;
		[Name("Wolf Flee Chance When Detected Offset Max")]
		[Description("")]
		[Slider(-100, 100)]
		public int wolfFleeChanceWhenDetectedOffsetMax = 10;

		[Name("Bear Flee Chance When Detected Offset Min")]
		[Description("")]
		[Slider(-100, 100)]
		public int bearFleeChanceWhenDetectedOffsetMin = 0;
		[Name("Bear Flee Chance When Detected Offset Max")]
		[Description("")]
		[Slider(-100, 100)]
		public int bearFleeChanceWhenDetectedOffsetMax = 0;
		[Name("Moose Flee Chance When Detected Offset Min")]
		[Description("")]
		[Slider(-100, 100)]
		public int mooseFleeChanceWhenDetectedOffsetMin = 0;
		[Name("Moose Flee Chance When Detected Offset Max")]
		[Description("")]
		[Slider(-100, 100)]
		public int mooseFleeChanceWhenDetectedOffsetMax = 0;
		[Name("Cougar Flee Chance When Detected Offset Min")]
		[Description("")]
		[Slider(-100, 100)]
		public int cougarFleeChanceWhenDetectedOffsetMin = 0;
		[Name("Cougar Flee Chance When Detected Offset Max")]
		[Description("")]
		[Slider(-100, 100)]
		public int cougarFleeChanceWhenDetectedOffsetMax = 0;

		// [Name("Fat Rabbit Chance")]
		// [Description("")]
		// [Slider(0, 10)]
		// public int fatRabbitChance = 1;

	}
	internal static class Settings
	{
		internal static WildlifeTuningSettings options;

		public static void OnLoad()
		{
			options = new WildlifeTuningSettings();
			options.AddToModSettings("WildlifeTuning");
		}
	}
}
