using Productivity__.Hooks;
using Productivity__.Mappings;
using Productivity__.Models;
using System;
using System.Windows.Forms;

namespace Productivity__
{
    public partial class MainWindow : Form
    {
        private KeyboardHook _hook;

        private string[] _clipboardSlots;

        public MainWindow()
        {
            _hook = new KeyboardHook();
            _clipboardSlots = new string[Configs.Configs.ClipboardSlotsCount];

            InitializeComponent();

            _hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(OnKeyPressed);
            RegisterHotkeys();
        }

        private void RegisterHotkeys()
        {
            RegisterClipboardSlots();

            _hook.RegisterHotKey(Enums.Enums.ModifierKeys.Control | Enums.Enums.ModifierKeys.Shift,
                Keys.A);
        }

        private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            var modifiers = e.Modifier.ToString();

            if (modifiers == KeyMappings.ControlKey && KeyMappings.IsKeyANumber(e.Key))
            {
                CopyToClipboardSlot(e);
            }
            if (modifiers == KeyMappings.ControlShiftKey)
            {
                if (KeyMappings.IsKeyANumber(e.Key))
                {
                    PasteFromSlot(e);
                    return;
                }

                switch (e.Key)
                {
                    case Keys.A:
                        Behaviors.Behaviors.AlternateCapitalization();
                        break;
                }
            }
        }

        private void RegisterClipboardSlots()
        {
            for (int i = 0; i < Configs.Configs.ClipboardSlotsCount; i++)
            {
                //copy
                _hook.RegisterHotKey(Enums.Enums.ModifierKeys.Control,
                    KeyMappings.NumberToKey(i));

                //paste
                _hook.RegisterHotKey(Enums.Enums.ModifierKeys.Control | Enums.Enums.ModifierKeys.Shift,
                    KeyMappings.NumberToKey(i));
            }
        }

        private void CopyToClipboardSlot(KeyPressedEventArgs e)
        {
            _clipboardSlots[KeyMappings.KeyToNumber(e.Key)] = Behaviors.Behaviors.GetTextFromScreen();
        }

        private void PasteFromSlot(KeyPressedEventArgs e)
        {
            var text = _clipboardSlots[KeyMappings.KeyToNumber(e.Key)];
            if (!string.IsNullOrEmpty(text))
            {
                Behaviors.Behaviors.SetTextToScreen(text);
            }
        }

    }
}
