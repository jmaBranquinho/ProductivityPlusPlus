using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productivity__.Behaviors
{
    public static class Behaviors
    {
        public static string GetTextFromScreen()
        {
            SelectWholeWord();
            var text = CopyAndGetTextFromClipboard();
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

        public static void ReadClipboard()
        {
            var text = GetTextFromClipboard();
            Text2Speech(text);
        }

        private static void Text2Speech(string textToSpeech) {
            //workaround for .net core
            Execute($@"Add-Type -AssemblyName System.speech;  
            $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer;                           
            $speak.Speak(""{textToSpeech}"");"); 

            void Execute(string command)
            {
                var cFile = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".ps1";

                using var tw = new System.IO.StreamWriter(cFile, false, Encoding.UTF8);
                tw.Write(command);

                var start =
                    new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "C:\\windows\\system32\\windowspowershell\\v1.0\\powershell.exe",                
                        LoadUserProfile = false,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Arguments = $"-executionpolicy bypass -File {cFile}",
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                    };

                var p = System.Diagnostics.Process.Start(start);
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
