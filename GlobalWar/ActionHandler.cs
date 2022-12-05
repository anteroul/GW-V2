namespace GlobalWar
{
    interface ActionHandler
    {
        public enum Move { None, Missile, Aircraft, AntiMissile, AntiAir, Soldier, Nuke, Chem, Spy, Sub, Man, Prop, Dip };

        public bool ValidMove(Move move, PlayerData p)
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
            }

            return false;
        }
    }
}
