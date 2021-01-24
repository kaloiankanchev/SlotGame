namespace Slot.Models
{
    /// <summary>
    /// Current stats of the player
    /// </summary>    
    public class Stats
    {
        #region Properties

        /// <summary>
        /// Current amount on win
        /// </summary>    
        public decimal WinAmount { get; set; }
        /// <summary>
        /// Total balance of player's credits
        /// </summary>    
        public decimal TotalBalance { get; set; }

        #endregion
    }
}
