using Verse;
using WilmotStoryteller.Patches.PawnPatch;

namespace WilmotStoryteller.Storyteller
{
    [StaticConstructorOnStartup]
    public class WilmotBehavior
    {
        #region Private Fields

        private WilmotData Data { get; set; }
        #endregion Private Fields

        #region Public Constructors

        public WilmotBehavior()
        {
            Data = new WilmotData();
            Log.Message("Initialized Wilmot :)");
            SetupHarmonyOverrides();
        }

        #endregion Public Constructors

        #region Actions

        // So, what's the plan?
        // Good Question: I think every storyteller tick, we add up deeds, so we'll have a set of good/bad
        // Guilty killing - + 1 bad deed.
        // Guilty Damage - +1 per pawn
        // Guilty Action?

        public void Tick()
        {
            // First we need to review what we have

        }


        #endregion

        #region Override Events

        public void PawnKilledHandler(object sender, PawnEvents.IPawnKilledArgs killedArgs)
        {
            Log.Message("Handler called.");
            if (killedArgs.DamageInfo != null)
            {
                Log.Message(killedArgs.DamageInfo.Value.Instigator.ToString());
                Log.Message(killedArgs.ExactCulprit.ToString());
            }
        }

        public void SetupHarmonyOverrides()
        {
            Log.Message(nameof(SetupHarmonyOverrides));
            WilmotHarmonyPawnPatch.PatchAll();
            WilmotHarmonyPawnPatch.Events.PawnKilled += PawnKilledHandler;
        }

        #endregion Override Events
    }
}