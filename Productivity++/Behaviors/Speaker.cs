using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;

namespace Productivity__
{
    public static class Speaker
    {
        public static IEnumerable<int> SpeechRate = Enumerable.Range(0, 11);

        private static SpeechSynthesizer _sp = GetSynth();

        public static void Speak(string text)
        {
            if (_sp.State == SynthesizerState.Speaking)
            {
                _sp.SpeakAsyncCancelAll();
            }

            _sp.SpeakAsync(text);
        }

        public static void ChangeRate(int rate)
        {
            _sp.Rate = rate;
        }

        private static SpeechSynthesizer GetSynth(int rate = 1)
        {
            var sp = new SpeechSynthesizer();
            sp.Rate = rate;

            return sp;
        }
    }
}
