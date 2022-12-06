using System;

namespace GlobalWar
{
    class IdeologyButton
    {
        public Button Btn;
        private string _playerIdeology;
        
        public IdeologyButton(string ideology, Sprite s, int x, int y, int w, int h)
        {
            _playerIdeology = ideology;
            Btn = new Button(null, s, x, y, w, h);
        }

        public Player InitializePlayer(Player player)
        {
            return new Player(_playerIdeology);
        }

        public static implicit operator int(IdeologyButton v)
        {
            throw new NotImplementedException();
        }
    }
}
