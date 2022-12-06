namespace GlobalWar
{
    public struct Player
    {
        public string Ideology;
        public int Population;
        public bool Alive;
        public PlayerData Data;

        public Player(string ideology)
        {
            Ideology = ideology;
            Population = 250;
            Alive = true;
            Data = new PlayerData(4);
        }
    }
}
