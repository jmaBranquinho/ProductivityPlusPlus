using System.Speech.Synthesis;

namespace Productivity__
{
    public class Speaker
    {
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            if (sp.State == SynthesizerState.Speaking)
            {
                sp.SpeakAsyncCancelAll();
            }

            sp.SpeakAsync(text);
        }
    }
}
