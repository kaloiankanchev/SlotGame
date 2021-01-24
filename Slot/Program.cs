using Slot.Common;
using Slot.Common.Models;
using Slot.Core;
using Slot.Models;
using System;

namespace Slot
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Enter game
            var player = new Player();
            player.DepositAmount = GameHelper.StartGame();
           
            //Initialize components
            Random random = new Random();
            var game = new SlotGame();
            var display = new Display();
            var winnings = new Winnings();
            var stats = new Stats();
            var winAmount = 0m;
            
            //Select stake and spin
            while (player.DepositAmount > 0m)
            {
                Console.WriteLine(Constants.STAKE_AMOUNT_TEXT);
                var stake = Convert.ToDecimal(Console.ReadLine());
                stake = Math.Round(stake, Constants.DECIMAL_PRECISION);
                player.StakeAmount = GameHelper.TakeBetByPlayer(player, stake);
                
                //Roll symbols
                GameHelper.Spin(random, game, display);
                GameHelper.ShowSymbolsResultOnDisplay(display);

                //Collect all winnigs per line
                winnings.FirstLine = PaymentService.AmountWonPerLine(display.FirstLine, player);
                winnings.SecondLine = PaymentService.AmountWonPerLine(display.SecondLine, player);
                winnings.ThirdLine = PaymentService.AmountWonPerLine(display.ThirdLine, player);
                winnings.FourthLine = PaymentService.AmountWonPerLine(display.FourthLine, player);
                winAmount = Math.Round(winnings.CollectAllWinnings(), Constants.DECIMAL_PRECISION);
                GameHelper.ResetReels(display);
                stats.WinAmount = winAmount;
                
                //Display stats at current stage
                stats.TotalBalance = GameHelper.TotalBalance(player.DepositAmount, player.StakeAmount, winAmount);
                player.DepositAmount = stats.TotalBalance;
                player.DepositAmount = Math.Round(player.DepositAmount, Constants.DECIMAL_PRECISION);                            
                Console.WriteLine(string.Format(Constants.WIN_TEXT, stats.WinAmount));                
                Console.WriteLine(string.Format(Constants.CURRENT_BALANCE_TEXT, player.DepositAmount));
            }
            Console.WriteLine(Constants.INSERT_CREDIT_TEXT);
        }      
    }
}
