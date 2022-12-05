using System;

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
        
        private Sprite _avatar;

        public Opponent(int id, string name, string ideology, Sprite avatar)
        {
            Name = name;
            Ideology = ideology;
            FriendshipPoints = 50;
            Population = 250;
            Alive = true;
            Data = new PlayerData(id);
            _avatar = avatar;
            Console.WriteLine(id + ", " + Name + ", " + Ideology);
        }

        public void UpdateStatus()
        {
            if (FriendshipPoints > 100) FriendshipPoints = 100;
            if (Population > 0) return;
            Population = 0;
            Alive = false;
        }

        public void DrawAvatar(int x, int y)
        {
            if (Alive) _avatar?.Draw(x, y, false);
        }
    }
}