using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Productivity__.Behaviors
{
    public static class Behaviors
    {
        public static string GetTextFromScreen()
        {
            var text = CopyAndGetTextFromClipboard();
            if(string.IsNullOrEmpty(text))
            {
                SelectWholeWord();
                text = CopyAndGetTextFromClipboard();
            }
            return !string.IsNullOrEmpty(text) ? text : null;
        }

        public static string CopyAndGetTextFromClipboard()
        {
            CopyToClipboard();
            return GetTextFromClipboard();
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

        public static void ReadClipboard(string str)
        {
            var text = GetTextFromScreen();
            Text2Speech(str);
        }

        private static void Text2Speech(string textToSpeech)
        {
            Speaker.Speak(textToSpeech);
        }

        private static void SelectWholeWord()
        {
            SendKeys.Send("^{LEFT 1}^+{RIGHT 1}");
        }

        private static void CopyToClipboard()
        {
            SendKeys.Send("^(c)");
            Thread.Sleep(2000);
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
