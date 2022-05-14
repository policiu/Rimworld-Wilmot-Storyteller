using HarmonyLib;
using System;
using System.Reflection;
using Verse;
using WilmotStoryteller.Utilities;

namespace WilmotStoryteller.Patches.PawnPatch
{
    #region Events

    public class PawnEvents
    {
        /// <summary>
        /// Called when a Pawn dies
        /// </summary>
        public event EventHandler<IPawnKilledArgs> PawnKilled;

        /// <summary>
        /// Invoke handlers for PawnKilled
        /// </summary>
        /// <param name="e"></param>
        internal virtual void OnPawnKilled(IPawnKilledArgs e)
        {
            EventHandler<IPawnKilledArgs> handler = PawnKilled;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Arguments for the PawnKilled event
        /// </summary>
        public class IPawnKilledArgs
        {
            // Damage information
            public DamageInfo? DamageInfo;
            // Body part where the fatal blow occurred
            public Hediff ExactCulprit;
        }
    }

    #endregion Events

    [HarmonyPatch(typeof(Pawn), nameof(Pawn.Kill), new Type[] { typeof(DamageInfo?), typeof(Hediff) })]
    public class WilmotHarmonyPawnKill
    {
        /// <summary>
        /// We want to record if the player did a good or bad deed. Currently, it's pretty arbitrary
        /// </summary>
        /// <param name="dinfo">        Damage </param>
        /// <param name="exactCulprit"> Body part where the fatal blow occurred </param>
        public static void Postfix(DamageInfo? dinfo, Hediff exactCulprit = null)

        {
            WilmotHarmonyPawnPatch.Events.OnPawnKilled(new PawnEvents.IPawnKilledArgs()
            {
                DamageInfo = dinfo,
                ExactCulprit = exactCulprit
            });
        }
    }

    internal static class WilmotHarmonyPawnPatch
    {
        public static PawnEvents Events = new PawnEvents();

        /// <summary>
        /// Initialize harmony and patch some pawn methods
        /// </summary>
        public static void PatchAll()
        {
            Log.Message("Patching..... " + HarmonyUtility.GetHarmonyName("events"));
            Harmony harmony = new Harmony(HarmonyUtility.GetHarmonyName("events"));
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message("Checking Patched Methods");
            foreach (var method in harmony.GetPatchedMethods())
            {
                Log.Message("\t-" + method.Name);
            }
        }
    }
}