using System;
using System.Collections.Generic;

namespace Slot
{
    /// <summary>
    /// The slot machine
    /// </summary>
    public class SlotGame
    {
        #region Constants

        public const decimal A_SYMBOL_COEFFCIENT = 0.4m;

        public const decimal B_SYMBOL_COEFFCIENT = 0.6m;

        public const decimal P_SYMBOL_COEFFCIENT = 0.8m;

        public const decimal WILDCARD_SYMBOL_COEFFCIENT = 0m;

        #endregion

        #region Properties

        /// <summary>
        /// Collection of symbols
        /// </summary>     
        public char[] Symbols { get; set; }

        /// <summary>
        /// Key-value pair of symbols and relevant coefficients
        /// </summary>    
        public Dictionary<char, decimal> SymbolsCoefficients { get; set; }

        /// <summary>
        /// Returns random symbol according to the probality of occurance
        /// </summary>    
        public char GetSymbol(Random random)
        {
            var returnedSymbol = '\0';         
            int rand = random.Next(1, 100);
                       
            if (rand <= 45)
            {
                returnedSymbol = Symbols[0];
            }
            if (rand > 45 && rand <= 80)
            {
                returnedSymbol = Symbols[1];
            }
            if (rand > 80 && rand <= 95)
            {
                returnedSymbol = Symbols[2];
            }
            if (rand > 95)
            {
                returnedSymbol = Symbols[3];
            }

            return returnedSymbol;
        }

        #endregion

        #region Constructor

        public SlotGame()
        {
            this.Symbols = new char[] { 'A', 'B', 'P', '*' };
            this.SymbolsCoefficients = new Dictionary<char, decimal>
             {
                {Symbols[0], A_SYMBOL_COEFFCIENT},
                {Symbols[1], B_SYMBOL_COEFFCIENT},
                {Symbols[2], P_SYMBOL_COEFFCIENT},
                {Symbols[3], WILDCARD_SYMBOL_COEFFCIENT}
             };
        }

        #endregion

    }
}
