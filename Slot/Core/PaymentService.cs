using Slot.Common;
using System.Collections.Generic;
using System.Linq;

namespace Slot.Core
{
    /// <summary>
    /// Implements the payment service logic
    /// </summary>
    public class PaymentService
    {
        #region Constants

        public const int SINGLE_SYMBOL_WIN = 1;

        public const int TWO_SYMBOL_WIN = 2;

        #endregion

        #region Methods
        /// <summary>
        /// Calculates the win amount per line.
        /// </summary>
        /// <param name="currentRow">The current row.</param>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        public static decimal AmountWonPerLine(List<char> currentRow, Player player)
        {
            var CreditsWonOnLine = 0m;

            bool LineWins = false;
            var symbol = '\0';

            if (!currentRow.Contains('*'))
            {
                LineWins = currentRow.GroupBy(x => x)
                .Where(g => g.Count() > 2)
                 .Select(y => y.Key)
                .Any();
                if (LineWins)
                {
                    symbol = currentRow.FirstOrDefault();
                    switch (symbol)
                    {
                        case 'A':
                            CreditsWonOnLine = (Constants.SYMBOLS_PER_ROW * (SlotGame.A_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        case 'B':
                            CreditsWonOnLine = (Constants.SYMBOLS_PER_ROW * (SlotGame.B_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        case 'P':
                            CreditsWonOnLine = (Constants.SYMBOLS_PER_ROW * (SlotGame.P_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                var wildCardOccur = 0;
                foreach (var item in currentRow)
                {
                    if (item == '*')
                    {
                        wildCardOccur++;
                    }
                }
                if (wildCardOccur < 2)
                {
                    LineWins = currentRow.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                   .Select(y => y.Key)
                  .Any();
                    if (LineWins)
                    {
                        symbol = currentRow.First(s => s != '*');
                        switch (symbol)
                        {
                            case 'A':
                                CreditsWonOnLine = (TWO_SYMBOL_WIN * (SlotGame.A_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                                break;
                            case 'B':
                                CreditsWonOnLine = (TWO_SYMBOL_WIN * (SlotGame.B_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                                break;
                            case 'P':
                                CreditsWonOnLine = (TWO_SYMBOL_WIN * (SlotGame.P_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    symbol = currentRow.First(s => s != '*');
                    switch (symbol)
                    {
                        case 'A':
                            CreditsWonOnLine = (SINGLE_SYMBOL_WIN * (SlotGame.A_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        case 'B':
                            CreditsWonOnLine = (SINGLE_SYMBOL_WIN * (SlotGame.B_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        case 'P':
                            CreditsWonOnLine = (SINGLE_SYMBOL_WIN * (SlotGame.P_SYMBOL_COEFFCIENT)) * player.StakeAmount;
                            break;
                        default:
                            break;
                    }
                }
            }
            return CreditsWonOnLine;
        }

        #endregion
    }
}
