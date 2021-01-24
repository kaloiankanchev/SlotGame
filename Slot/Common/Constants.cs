namespace Slot.Common
{
    /// <summary>
    /// Gameplay features and other details
    /// </summary>    
    public class Constants
    {
        public const string INTRO_TEXT = "Please deposit money you would like to play with:";

        public const string STAKE_AMOUNT_TEXT = "Enter stake amount:";

        public const string WIN_TEXT = "You have won: {0}";

        public const string CURRENT_BALANCE_TEXT = "Current balance is: {0}";

        public const string DEPOSIT_HELP_TEXT = "If you need assistance with the deposit please, call an attendant...";

        public const string INSUFFICIENT_FUNDS_FOR_STAKE = "Stake amount cannot be larger than your current deposit amount";

        public const string INSERT_CREDIT_TEXT = "Please insert new deposit amount if you want to proceed...";

        public const string DEPOSIT_TYPE_AMOUNT = "Deposit";

        public const string STAKE_TYPE_AMOUNT = "Stake";

        public const int ROWS = 4;

        public const int SYMBOLS_PER_ROW = 3;

        public const int DECIMAL_PRECISION = 1;
    }
}
