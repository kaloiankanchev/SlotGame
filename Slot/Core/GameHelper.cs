using Slot.Common;
using Slot.Common.Models;
using System;

namespace Slot.Core
{
    public static class GameHelper
    {
        /// <summary>
        /// Shows the symbols result on display.
        /// </summary>
        /// <param name="display">The display.</param>
        public static void ShowSymbolsResultOnDisplay(Display display)
        {
            Console.WriteLine(display.FirstLine.ToArray());
            Console.WriteLine(display.SecondLine.ToArray());
            Console.WriteLine(display.ThirdLine.ToArray());
            Console.WriteLine(display.FourthLine.ToArray());
        }

        /// <summary>
        /// Returns the total balance amount according after every spin
        /// </summary>
        /// <param name="depositAmount">The deposit amount.</param>
        /// <param name="stakeAmount">The stake amount.</param>
        /// <param name="winAmount">The win amount.</param>
        /// <returns></returns>
        public static decimal TotalBalance(decimal depositAmount, decimal stakeAmount, decimal winAmount)
        {
            decimal result = 0m;

            result = (depositAmount - stakeAmount) + winAmount;

            return result;
        }
        /// <summary>
        /// Resets the reels.
        /// </summary>
        /// <param name="display">The display.</param>
        public static void ResetReels(Display display)
        {
            display.FirstLine.Clear();
            display.SecondLine.Clear();
            display.ThirdLine.Clear();
            display.FourthLine.Clear();
        }
        /// <summary>
        /// Spinning the symbols
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="game">The game.</param>
        /// <param name="display">The display.</param>
        public static void Spin(Random random, SlotGame game, Display display)
        {
            for (int i = 0; i < Constants.SYMBOLS_PER_ROW; i++)
            {
                display.FirstLine.Add(game.GetSymbol(random));
                display.SecondLine.Add(game.GetSymbol(random));
                display.ThirdLine.Add(game.GetSymbol(random));
                display.FourthLine.Add(game.GetSymbol(random));
            }
        }
        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <returns></returns>
        public static decimal StartGame()
        {
            Console.WriteLine(Constants.INTRO_TEXT);
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            while (depositAmount <= 0)
            {
                Console.WriteLine(Constants.DEPOSIT_HELP_TEXT);
                Console.WriteLine(Constants.INTRO_TEXT);
                depositAmount = Convert.ToDecimal(Console.ReadLine());
            }
            return depositAmount;
        }
        /// <summary>
        /// Takes the bet by the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="stake">The stake.</param>
        /// <returns></returns>
        public static decimal TakeBetByPlayer(Player player, decimal stake)
        {
            while (stake <= 0 || stake > player.DepositAmount)
            {
                if (stake <= player.DepositAmount)
                {
                    Console.WriteLine(Constants.STAKE_AMOUNT_TEXT);
                    stake = Convert.ToDecimal(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine(Constants.INSUFFICIENT_FUNDS_FOR_STAKE);
                    stake = Convert.ToDecimal(Console.ReadLine());
                }

            }

            return stake;
        }
    }
}
