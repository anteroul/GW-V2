using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalWar
{
    public struct PlayerData
    {
        public int missiles;
        public int aircraft;
        public int ar;
        public int aa;
        public int soldiers;
        public int nukes;
        public int chemical;
        public int spies;
        public int subs;

        public PlayerData(int difficulty)
        {
            missiles = 0;
            aircraft = 1;
            ar = 1;
            aa = 1;
            soldiers = 2;
            nukes = 1;
            chemical = 1;
            spies = 2;
            subs = 1;
        }
    }
}
