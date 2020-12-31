using System.Speech.Synthesis;

namespace Productivity__
{
    public static class Speaker
    {
        private static SpeechSynthesizer _sp = GetSynth();
        public static void Speak(string text)
        {
            if (_sp.State == SynthesizerState.Speaking)
            {
                _sp.SpeakAsyncCancelAll();
            }

            _sp.SpeakAsync(text);
        }

        private static SpeechSynthesizer GetSynth(int rate = 1)
        {
            var sp = new SpeechSynthesizer();
            sp.Rate = rate;

            return sp;
        }
    }
}
