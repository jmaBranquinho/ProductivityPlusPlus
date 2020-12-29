using System;
using System.Linq;
using System.Windows.Forms;

namespace Productivity__.Behaviors
{
    public static class Behaviors
    {
        public static string GetTextFromScreen()
        {
            SelectWholeWord();
            CopyToClipboard();
            var text = GetTextFromClipboard();
            return !string.IsNullOrEmpty(text) ? text : null;
        }

        public static string GetTextFromClipboard()
        {
            try
            {
                return Clipboard.GetText();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SetTextToScreen(string text)
        {
            SetTextToClipboard(text);
            PasteFromClipboard();
        }

        public static void AlternateCapitalization()
        {
            var text = GetTextFromScreen();
            if (!string.IsNullOrEmpty(text))
            {
                if (Char.IsUpper(char.Parse(text.First().ToString())))
                {
                    text = text.First().ToString().ToLower() + text.Substring(1);
                }
                else
                {
                    text = text.First().ToString().ToUpper() + text.Substring(1);
                }

                SetTextToScreen(text);
            }
        }

        private static void SelectWholeWord()
        {
            SendKeys.Send("^{LEFT 1}^+{RIGHT 1}");
        }

        private static void CopyToClipboard()
        {
            SendKeys.Send("^(c)");
        }

        private static void PasteFromClipboard()
        {
            SendKeys.Send("^(v)");
        }

        private static void SetTextToClipboard(string text)
        {
            Clipboard.SetText(text);
        }
    }
}
