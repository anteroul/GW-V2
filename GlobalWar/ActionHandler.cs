namespace GlobalWar
{
    interface IActionHandler
    {
        public enum Move { None, Missile, Aircraft, AntiMissile, AntiAir, Soldier, Nuke, Chem, Spy, Sub, Manufacture, Propaganda, Diplomacy }

        public static bool ValidMove(Move move, PlayerData p)
        {
            switch (move)
            {
                case Move.Missile:
                    if (p.missiles > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Aircraft:
                    if (p.aircraft > 0)
                    {
                        return true;
                    }
                    break;
                case Move.AntiMissile:
                    if (p.ar > 0)
                    {
                        return true;
                    }
                    break;
                case Move.AntiAir:
                    if (p.aa > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Soldier:
                    if (p.soldiers > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Spy:
                    if (p.spies > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Nuke:
                    if (p.nukes > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Chem:
                    if (p.chemical > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Sub:
                    if (p.subs > 0)
                    {
                        return true;
                    }
                    break;
                case Move.Manufacture:
                    return true;
                case Move.Propaganda:
                    return true;
                case Move.Diplomacy:
                    return true;
                case Move.None:
                    return false;
            }

            return false;
        }
    }
}
