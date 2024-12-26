// #define VERY_VERBOSE
using Il2Cpp;
using MelonLoader;
using System.Diagnostics;
using UnityEngine;

namespace WildlifeTuning
{
    public class WildlifeTuning : MelonMod
    {
		public static WildlifeTuning Instance { get; private set; }
        public override void OnInitializeMelon()
		{
			Settings.OnLoad();
			Instance = this;
		}

		[Conditional("VERY_VERBOSE")]
		internal static void VeryVerboseLog (string msg)
		{
			Instance.LoggerInstance.Msg(msg);
		}
    }



	[HarmonyLib.HarmonyPatch(typeof(SpawnRegion), nameof(SpawnRegion.AddActiveSpawns))]
	public class PatchAddActiveSpawns
	{
		public static void Postfix (SpawnRegion __instance, ref int numToActivate)
		{
            int v = UnityEngine.Random.Range(-1, 1);
            numToActivate = Mathf.Max(1, numToActivate + v);
			WildlifeTuning.VeryVerboseLog($"--------------------------AddActiveSpawns: {numToActivate} (+{v})");
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(SpawnRegion), nameof(SpawnRegion.CalculateTargetPopulation))]
	public class PatchCalculateTargetPopulation
	{
		public static void Postfix (SpawnRegion __instance, ref int __result)
		{
            int v = UnityEngine.Random.Range(-1, 1);
            __result = Mathf.Max(0, __result + v);
			WildlifeTuning.VeryVerboseLog($"--------------------------CalculateTargetPopulation: {__result} (+{v})");
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(SpawnRegion), nameof(SpawnRegion.GetNumHoursBetweenRespawns))]
	public class PatchSpawnRegion
	{
		public static void Postfix (SpawnRegion __instance, ref float __result)
		{
			float baseScale = __instance.m_AiSubTypeSpawned switch
			{
				AiSubType.Wolf => Settings.options.wolfHoursBetweenRespawnBaseScale,
				AiSubType.Stag => Settings.options.deerHoursBetweenRespawnBaseScale,
				AiSubType.Rabbit => Settings.options.rabbitHoursBetweenRespawnBaseScale,
				_ => 1
			};

            float v = UnityEngine.Random.Range(Settings.options.hoursBetweenRespawnScaleMin, Settings.options.hoursBetweenRespawnScaleMax);
			if (UnityEngine.Random.Range(Settings.options.hoursBetweenRespawnScaleMin, Settings.options.hoursBetweenRespawnScaleMax) < Settings.options.chanceHoursBetweenRespawnRareScale)
            	v = UnityEngine.Random.Range(Settings.options.hoursBetweenRespawnRareScaleMin, Settings.options.hoursBetweenRespawnRareScaleMax);

            __result *= baseScale;
            __result *= v;
			WildlifeTuning.VeryVerboseLog($"--------------------------GetNumHoursBetweenRespawns: {__result} (* {baseScale} *{v})");
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(BaseAi), nameof(BaseAi.Awake))]
	public class PatchBaseAi
	{
		public static void Postfix (BaseAi __instance)
		{
			if (__instance.gameObject.scene.name.EndsWith("_SANDBOX")) return; // Spawn region prefab
			__instance.m_RetreatSpeed *= UnityEngine.Random.Range(Settings.options.retreatSpeedScaleRangeMin, Settings.options.retreatSpeedScaleRangeMax);
			__instance.m_RunSpeed *= UnityEngine.Random.Range(Settings.options.runSpeedScaleRangeMin, Settings.options.runSpeedScaleRangeMax);
			if (__instance.m_AiSubType == AiSubType.Wolf)
				 __instance.m_ChasePlayerSpeed *= UnityEngine.Random.Range(Settings.options.wolfChasePlayerSpeedScaleRangeMin, Settings.options.wolfChasePlayerSpeedScaleRangeMax);
			__instance.m_TurnSpeedDegreesPerSecond *= UnityEngine.Random.Range(Settings.options.turnDegreesSpeedScaleRangeMin, Settings.options.turnDegreesSpeedScaleRangeMax);
			__instance.m_StalkSpeed *= UnityEngine.Random.Range(Settings.options.stalkSpeedScaleRangeMin, Settings.options.stalkSpeedScaleRangeMax);
			__instance.m_StalkCatchUpSpeed *= UnityEngine.Random.Range(Settings.options.stalkCatchUpSpeedScaleRangeMin, Settings.options.stalkCatchUpSpeedScaleRangeMax);
			__instance.m_StalkSlowlySpeed *= UnityEngine.Random.Range(Settings.options.stalkSlowlySpeedScaleRangeMin, Settings.options.stalkSlowlySpeedScaleRangeMax);
			if (__instance.m_CuriousLoseInterestChance != 0)
				 __instance.m_CuriousLoseInterestChance += UnityEngine.Random.Range(Settings.options.curiosLoseInterestChanceOffsetMin, Settings.options.curiosLoseInterestChanceOffsetMax);
			if (__instance.m_StalkingLoseInterestChance != 0)
				 __instance.m_StalkingLoseInterestChance += UnityEngine.Random.Range(Settings.options.stalkingLoseInterestChanceOffsetMin, Settings.options.stalkingLoseInterestChanceOffsetMax);
			__instance.m_CuriousLoseInterestChance = Mathf.Clamp(__instance.m_CuriousLoseInterestChance, 0, 100);
			__instance.m_StalkingLoseInterestChance = Mathf.Clamp(__instance.m_StalkingLoseInterestChance, 0, 100);
			if (__instance.m_CuriousEnterStalkingChance != 0)
				 __instance.m_CuriousEnterStalkingChance += UnityEngine.Random.Range(Settings.options.curiosEnterStalkingScaleRangeMin, Settings.options.curiosEnterStalkingScaleRangeMax);
			__instance.m_MaxHP *= UnityEngine.Random.Range(Settings.options.HPScaleMin, Settings.options.HPScaleMax);
			__instance.m_SmellRange *= UnityEngine.Random.Range(Settings.options.smellRangeScaleMin, Settings.options.smellRangeScaleMax);
			if (__instance.m_AiSubType == AiSubType.Wolf)
			{
                float attackScale = UnityEngine.Random.Range(1, Settings.options.wolfAttackRangeScaleUpMax);
                __instance.m_RangeMeleeAttack *= attackScale;
				__instance.m_RangeMeleeAttackLargeAnimal *= attackScale;
				__instance.m_RangeMeleeAttackSmallAnimal *= attackScale;
			}

			var detectRangeScale = __instance.m_AiSubType switch
			{
				AiSubType.Rabbit => SafeRandomRange(Settings.options.rabbitDetectRangeScaleMin, Settings.options.rabbitDetectRangeScaleMax),
				AiSubType.Wolf => SafeRandomRange(Settings.options.wolfDetectRangeScaleMin, Settings.options.wolfDetectRangeScaleMax),
				AiSubType.Bear => SafeRandomRange(Settings.options.bearDetectRangeScaleMin, Settings.options.bearDetectRangeScaleMax),
				AiSubType.Moose => SafeRandomRange(Settings.options.mooseDetectRangeScaleMin, Settings.options.mooseDetectRangeScaleMax),
				AiSubType.Cougar => SafeRandomRange(Settings.options.cougarDetectRangeScaleMin, Settings.options.cougarDetectRangeScaleMax),
				_ => SafeRandomRange(Settings.options.detectRangeScaleMin, Settings.options.detectRangeScaleMax)
			};
			__instance.m_DetectionRange *= detectRangeScale;
			__instance.m_DetectionRangeWhileFeeding *= detectRangeScale;

			var hearRangeScale = __instance.m_AiSubType switch
			{
				AiSubType.Rabbit => SafeRandomRange(Settings.options.rabbitHearFootstepRangeScaleMin, Settings.options.rabbitHearFootstepRangeScaleMax),
				AiSubType.Wolf => SafeRandomRange(Settings.options.wolfHearFootstepRangeScaleMin, Settings.options.wolfHearFootstepRangeScaleMax),
				AiSubType.Bear => SafeRandomRange(Settings.options.bearHearFootstepRangeScaleMin, Settings.options.bearHearFootstepRangeScaleMax),
				AiSubType.Moose => SafeRandomRange(Settings.options.mooseHearFootstepRangeScaleMin, Settings.options.mooseHearFootstepRangeScaleMax),
				AiSubType.Cougar => SafeRandomRange(Settings.options.cougarHearFootstepRangeScaleMin, Settings.options.cougarHearFootstepRangeScaleMax),
				_ => SafeRandomRange(Settings.options.hearFootstepRangeScaleMin, Settings.options.hearFootstepRangeScaleMax)
			};
			__instance.m_HearFootstepsRange *= hearRangeScale;
			__instance.m_HearFootstepsRangeWhileFeeding *= hearRangeScale;
			__instance.m_HearFootstepsRangeWhileSleeping *= hearRangeScale;

			var fleeChanceOffset = __instance.m_AiSubType switch
			{
				AiSubType.Wolf => SafeRandomRange(Settings.options.wolfFleeChanceWhenDetectedOffsetMin, Settings.options.wolfFleeChanceWhenDetectedOffsetMax),
				AiSubType.Bear => SafeRandomRange(Settings.options.bearFleeChanceWhenDetectedOffsetMin, Settings.options.bearFleeChanceWhenDetectedOffsetMax),
				AiSubType.Moose => SafeRandomRange(Settings.options.mooseFleeChanceWhenDetectedOffsetMin, Settings.options.mooseFleeChanceWhenDetectedOffsetMax),
				AiSubType.Cougar => SafeRandomRange(Settings.options.cougarFleeChanceWhenDetectedOffsetMin, Settings.options.cougarFleeChanceWhenDetectedOffsetMax),
				_ => SafeRandomRange(Settings.options.fleeChanceWhenDetectedOffsetMin, Settings.options.fleeChanceWhenDetectedOffsetMax)
			};
			__instance.m_FleeChanceWhenTargetDetected = Mathf.Clamp(__instance.m_FleeChanceWhenTargetDetected + fleeChanceOffset, 0, 100);
	
			WildlifeTuning.VeryVerboseLog($"---BaseAi: {__instance.name}({__instance.gameObject.scene.name}) hp{__instance.m_MaxHP} walk{__instance.m_WalkSpeed} run{__instance.m_RunSpeed}  chase{__instance.m_ChasePlayerSpeed} retreat{__instance.m_RetreatSpeed}turndg{__instance.m_TurnSpeedDegreesPerSecond} stalkslwy{__instance.m_StalkSlowlySpeed} stalk{__instance.m_StalkSpeed} stalkctup{__instance.m_StalkCatchUpSpeed} loseinst{__instance.m_CuriousLoseInterestChance} loseinstStk{__instance.m_StalkingLoseInterestChance} entrstalk{__instance.m_CuriousEnterStalkingChance} smellrg{__instance.m_SmellRange} detectrg{__instance.m_DetectionRange}/{__instance.m_DetectionRangeWhileFeeding} hear{__instance.m_HearFootstepsRange}/{__instance.m_HearFootstepsRangeWhileFeeding}/{__instance.m_HearFootstepsRangeWhileSleeping} fleec{__instance.m_FleeChanceWhenTargetDetected}");
		}
		public static int SafeRandomRange(int min, int max)
		{
			var safeMin = Math.Min(min, max);
			var safeMax = Math.Max(min, max);
			return UnityEngine.Random.Range(safeMin, safeMax);
		}
		public static float SafeRandomRange(float min, float max)
		{
			var safeMin = Math.Min(min, max);
			var safeMax = Math.Max(min, max);
			return UnityEngine.Random.Range(safeMin, safeMax);
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(SnareItem), nameof(SnareItem.DoRoll))]
	public class PatchSnareItem
	{
		public static bool Prefix (SnareItem __instance)
		{
			if (UnityEngine.Random.Range(0, 100) < Settings.options.cancelSnareRollChance)
			{
				WildlifeTuning.VeryVerboseLog($"--------------------------SnareItem.DoRoll Cancelled");
				return false;
			}
			
			return true;
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(StruggleDamageEvent), nameof(StruggleDamageEvent.ApplyDamage))]
	public class PatchStruggleDamageEvent
	{
		public static void Prefix (StruggleDamageEvent __instance, ref float damage)
		{
			float scale = UnityEngine.Random.Range(Settings.options.struggleDamageScaleRangeMin, Settings.options.struggleDamageScaleRangeMax);
			damage *= scale;
			WildlifeTuning.VeryVerboseLog($"--------------------------StruggleDamageEvent.ApplyDamage: {damage} (x{scale})");
		}
	}
}
