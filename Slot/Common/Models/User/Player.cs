using Slot.Common;
using System;

namespace Slot
{
    /// <summary>
    /// Player object
    /// </summary>
    public class Player
    {
        #region Fields

        private decimal _depositAmount;
        private decimal _stakeAmount;

        #endregion

        #region Properties

        /// <summary>
        /// Initial deposit made by player
        /// </summary>
        public decimal DepositAmount
        {
            get { return _depositAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(string.Format(ExceptionMessages.AMOUNT_EXCEPTION, Constants.DEPOSIT_TYPE_AMOUNT));

                _depositAmount = Math.Round(value, Constants.DECIMAL_PRECISION);
            }
        }
        /// <summary>
        /// Stake made by player
        /// </summary>
        public decimal StakeAmount
        {
            get { return _stakeAmount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(string.Format(ExceptionMessages.AMOUNT_EXCEPTION, Constants.STAKE_TYPE_AMOUNT));

                _stakeAmount = Math.Round(value, Constants.DECIMAL_PRECISION);
            }
        }

        #endregion
    }
}
