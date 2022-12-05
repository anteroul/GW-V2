namespace GlobalWar
{
    public struct PlayerData
    {
        public int Id;
        public int missiles;
        public int aircraft;
        public int ar;
        public int aa;
        public int soldiers;
        public int nukes;
        public int chemical;
        public int spies;
        public int subs;

        public PlayerData(int _id)
        {
            Id = _id;
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
