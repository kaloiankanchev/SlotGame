using System.Collections.Generic;

namespace Slot.Common.Models
{
    /// <summary>
    /// Shows the rows of the slot machine
    /// </summary>
    public class Display
    {
        #region Properties
                
        public List<char> FirstLine { get; set; }

        public List<char> SecondLine { get; set; }

        public List<char> ThirdLine { get; set; }

        public List<char> FourthLine { get; set; }

        #endregion

        #region Constructor

        public Display()
        {
            this.FirstLine = new List<char>();
            this.SecondLine = new List<char>();
            this.ThirdLine = new List<char>();
            this.FourthLine = new List<char>();
        }

        #endregion
    }
}
