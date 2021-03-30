using System;
using System.Collections.Generic;
using System.Text;

namespace TRB2_InputOutput
{
    class TRB2DIOState
    {
        public bool[] DIOState = new bool[] { false, false, false }; // true - 1, false - 0  
        public bool[] DIODirection = new bool[] { true, true, true };  // true - in, false - output
        public bool[] DIOSaveConfig = new bool[] { true, true, true }; // true - save, false - not save
        public double ADCValue = -1;
        private static TRB2DIOState instance;

        public static TRB2DIOState I
        {
            get
            {
                if (instance == null)
                {
                    instance = new TRB2DIOState();
                }

                return instance;
            }
        }

    }
}
