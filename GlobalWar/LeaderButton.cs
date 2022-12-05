using Raylib_cs;
using static GlobalWar.IInput;

namespace GlobalWar
{
    public class LeaderButton
    {
        public Button Btn;
        private int _id;
        private bool _visible;
        
        public LeaderButton(int id, Sprite s, int x, int y, int w, int h)
        {
            _id = id;
            Btn = new Button(null, s, x, y, w, h);
            _visible = true;
        }

        public int SetEnemy(Opponent opponent, int index, Sound sound)
        {
            if (!OnClickUI(Btn.Rect) || !_visible) return index;
            Raylib.PlaySound(sound);
            switch (_id)
            {
                case 0:
                    opponent = new Opponent(index, "Erdogan", "Muslim");
                    _visible = false;
                    return index + 1;
                case 1:
                    opponent = new Opponent(index, "Isaac Herzog", "Jewish");
                    _visible = false;
                    return index + 1;
                case 2:
                    opponent = new Opponent(index, "Joe Biden", "Liberal");
                    _visible = false;
                    return index + 1;
                case 3:
                    opponent = new Opponent(index, "Boris Johnson", "Conservative");
                    _visible = false;
                    return index + 1;
                case 4:
                    opponent = new Opponent(index, "Bashar al-Assad", "Nationalist");
                    _visible = false;
                    return index + 1;
                case 5:
                    opponent = new Opponent(index, "Kim Jong Un", "Communist");
                    _visible = false;
                    return index + 1;
                case 6:
                    opponent = new Opponent(index, "Fumio Kishida", "Conservative");
                    _visible = false;
                    return index + 1;
                case 7:
                    opponent = new Opponent(index, "Emmanuel Macron", "Liberal");
                    _visible = false;
                    return index + 1;
                case 8:
                    opponent = new Opponent(index, "Sanna Marin", "Liberal");
                    _visible = false;
                    return index + 1;
                case 9:
                    opponent = new Opponent(index, "Xi Jingping", "Communist");
                    _visible = false;
                    return index + 1;
                case 10:
                    opponent = new Opponent(index, "Volodymyr Zelensky", "Jewish");
                    _visible = false;
                    return index + 1;
                case 11:
                    opponent = new Opponent(index, "Vladimir Putin", "Nationalist");
                    _visible = false;
                    return index + 1;
                case 12:
                    opponent = new Opponent(index, "Ebrahim Raisi", "Muslim");
                    _visible = false;
                    return index + 1;
            }

            return index;
        }
        
        public string GetLeaderName()
        {
            if (!_visible) return "";
            switch (_id)
            {
                case 0: return "Erdogan";
                case 1: return "Isaac Herzog";
                case 2: return "Joe Biden";
                case 3: return "Boris Johnson";
                case 4: return "Bashar al-Assad";
                case 5: return "Kim Jong Un";
                case 6: return "Fumio Kishida";
                case 7: return "Emmanuel Macron";
                case 8: return "Sanna Marin";
                case 9: return "Xi Jingping";
                case 10: return "Volodymyr Zelensky";
                case 11: return "Vladimir Putin";
                case 12: return "Ebrahim Raisi";
            }

            return "";
        }

        public bool IsVisible()
        {
            return _visible;
        }
    }
}