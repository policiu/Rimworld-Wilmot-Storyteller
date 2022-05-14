using Verse;

namespace WilmotStoryteller.Storyteller
{
    internal class WilmotData : IExposable
    {
        #region Public Constructors

        public WilmotData() : base()
        {
        }

        #endregion Public Constructors

        #region Private Fields

        private uint _deedNegative = 0;
        private uint _deedPositive = 0;
        private uint _deedTotal = 0;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Total number of "negative" deeds the player has done.
        /// </summary>
        public uint DeedNegative { get => _deedNegative; private set => _deedNegative = value; }

        /// <summary>
        /// Total number of "positive" deeds the player has done
        /// </summary>
        public uint DeedPositive { get => _deedPositive; private set => _deedPositive = value; }

        /// <summary>
        /// Total number of deeds the player has done. This influences the chance of increasing the
        /// quest progression
        /// </summary>
        public uint DeedTotal { get => _deedTotal; private set => _deedTotal = value; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Debug: Print out the internals
        /// </summary>
        public void ExposeData()
        {
            Scribe_Values.Look(ref _deedTotal, "DeedTotal");
            Scribe_Values.Look(ref _deedPositive, "DeedPositive");
            Scribe_Values.Look(ref _deedNegative, "DeedNegative");
        }

        #endregion Public Methods
    }
}