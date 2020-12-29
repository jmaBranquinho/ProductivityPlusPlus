using System;
using System.Windows.Forms;

namespace Productivity__.Mappings
{
    public static class KeyMappings
    {
        public static string ControlKey = "Control";
        public static string ShiftKey = "Shift";
        public static string ControlShiftKey = "Control, Shift";

        public static int KeyToNumber(Keys key)
        {
            switch (key)
            {
                case Keys.D0:
                    return 0;
                case Keys.D1:
                    return 1;
                case Keys.D2:
                    return 2;
                case Keys.D3:
                    return 3;
                case Keys.D4:
                    return 4;
                case Keys.D5:
                    return 5;
                case Keys.D6:
                    return 6;
                case Keys.D7:
                    return 7;
                case Keys.D8:
                    return 8;
                case Keys.D9:
                    return 9;
                default: throw new Exception($"key {key.ToString()} is NaN");
            }
        }

        public static Keys NumberToKey(int key)
        {
            switch (key)
            {
                case 0:
                    return Keys.D0;
                case 1:
                    return Keys.D1;
                case 2:
                    return Keys.D2;
                case 3:
                    return Keys.D3;
                case 4:
                    return Keys.D4;
                case 5:
                    return Keys.D5;
                case 6:
                    return Keys.D6;
                case 7:
                    return Keys.D7;
                case 8:
                    return Keys.D8;
                case 9:
                    return Keys.D9;
                default: throw new Exception($"key {key} is not valid");
            }
        }

        public static bool IsKeyANumber(Keys key)
        {
            try
            {
                return KeyToNumber(key) > 0;
            } 
            catch(Exception)
            {
                return false;
            }
        }

        public static string JoinKeys(string[] keys)
        {
            return string.Join(", ", keys);
        }
    }
}
