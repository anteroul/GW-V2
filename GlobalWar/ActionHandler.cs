using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalWar
{
    interface ActionHandler
    {
        public enum Move { None, Missile, Aircraft, AntiMissile, AntiAir, Soldier, Nuke, Chem, Spy, Sub, Man, Prop, Dip };

        public bool ValidMove(Move move, bool attack, int missiles, int aircraft, int ar, int aa, int soldiers, int nukes, int chemical, int spies, int subs)
        {
            switch (move)
            {
                case Move.Missile:
                    if (missiles > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Aircraft:
                    if (aircraft > 0)
                    {
                        return true;
                    }
                    break;
                case Move.AntiMissile:
                    if (ar > 0)
                    {
                        return true;
                    }
                    break;
                case Move.AntiAir:
                    if (aa > 0)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
