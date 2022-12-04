namespace GlobalWar
{
    public struct Opponent
    {
        public string Name;
        public string Ideology;
        public int FriendshipPoints;
        public int Population;
        public bool Alive;
        public PlayerData Data;

        public Opponent(string name, string ideology)
        {
            Name = name;
            Ideology = ideology;
            FriendshipPoints = 50;
            Population = 250;
            Alive = true;
            Data = new PlayerData();
        }

        public void UpdateStatus()
        {
            if (FriendshipPoints > 100) FriendshipPoints = 100;
            if (Population > 0) return;
            Population = 0;
            Alive = false;
        }
    }
}