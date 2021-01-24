namespace Slot.Common.Models
{
    /// <summary>
    /// Represents winning amounts on each line
    /// </summary>
    public class Winnings
    {
        #region Properties

        public decimal FirstLine { get; set; }

        public decimal SecondLine { get; set; }

        public decimal ThirdLine { get; set; }

        public decimal FourthLine { get; set; }

        #endregion
        /// <summary>
        /// Collect winnings for each line
        /// </summary>

        #region Methods

        public decimal CollectAllWinnings()
        {
            var result = 0m;
            result = FirstLine + SecondLine + ThirdLine + FourthLine;
            return result;
        }

        #endregion
    }
}
