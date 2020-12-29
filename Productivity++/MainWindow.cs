using Productivity__.Hooks;
using Productivity__.Models;
using System;
using System.Windows.Forms;

namespace Productivity__
{
    public partial class MainWindow : Form
    {
        private KeyboardHook _hook;

        private string[] _clipboardSlots;

        private Keys[] _keyboardNumbersMapping = new Keys[] { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };

        public MainWindow()
        {
            _hook = new KeyboardHook();
            _clipboardSlots = new string[Configs.Configs.ClipboardSlotsCount];

            InitializeComponent();

            RegisterHotkeys();
        }

        private void RegisterHotkeys()
        {
            throw new NotImplementedException();
        }

        private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
