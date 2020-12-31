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

        public void Terminate()
        {
            _hook.Dispose();
        }

        private void RegisterHotkeys()
        {
            RegisterClipboardSlots();

            _hook.RegisterHotKey(Enums.Enums.ModifierKeys.Control | Enums.Enums.ModifierKeys.Shift,
                Keys.A);
            _hook.RegisterHotKey(Enums.Enums.ModifierKeys.Control,
                Keys.L);
        }

        private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            var modifiers = e.Modifier.ToString();

            if (modifiers == KeyMappings.ControlKey)
            {
                if(KeyMappings.IsKeyANumber(e.Key))
                {
                    CopyToClipboardSlot(e);
                    return;
                }
                
                switch (e.Key)
                {
                    case Keys.L:
                        var text = Behaviors.Behaviors.GetTextFromScreen();
                        if (!string.IsNullOrEmpty(text))
                        {
                            Behaviors.Behaviors.ReadClipboard(text);
                        }
                        break;
                }
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
            var text = Behaviors.Behaviors.GetTextFromScreen();
            var position = KeyMappings.KeyToNumber(e.Key);
            _clipboardSlots[position] = text;
            UpdateUIClipboard(position, text);
        }

        private void PasteFromSlot(KeyPressedEventArgs e)
        {
            var text = _clipboardSlots[KeyMappings.KeyToNumber(e.Key)];
            if (!string.IsNullOrEmpty(text))
            {
                Behaviors.Behaviors.SetTextToScreen(text);
            }
        }

        private void UpdateUIClipboard(int position, string text)
        {
            switch (position)
            {
                case 0:
                    this.textBox10.Text = text;
                    break;
                case 1:
                    this.textBox1.Text = text;
                    break;
                case 2:
                    this.textBox2.Text = text;
                    break;
                case 3:
                    this.textBox3.Text = text;
                    break;
                case 4:
                    this.textBox4.Text = text;
                    break;
                case 5:
                    this.textBox5.Text = text;
                    break;
                case 6:
                    this.textBox6.Text = text;
                    break;
                case 7:
                    this.textBox7.Text = text;
                    break;
                case 8:
                    this.textBox8.Text = text;
                    break;
                case 9:
                    this.textBox9.Text = text;
                    break;
            }
        }
    }
}
