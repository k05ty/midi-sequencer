using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace midi_sequencer.src.model
{
    internal class NoteButton
    {
        private int noteButtonWidth;
        private int noteButtonHeight;
        private int noteNumber;
        private int channel;

        private Button noteButton;

        public NoteButton(int channel, int noteNumber, Button noteButton, int noteButtonWidth, int noteButtonHeight)
        {
            this.channel = channel;
            this.noteNumber = noteNumber;
            this.noteButton = noteButton;
            this.noteButtonWidth = noteButtonWidth;
            this.noteButtonHeight = noteButtonHeight;
        }

        public Button GetControl()
        {
            throw new NotImplementedException();
        }

        public int GetAbsoluteTime()
        {
            return (int)noteButton.Margin.Left / noteButtonWidth * 16;
        }

        public int GetDuration()
        {
            return (int)noteButton.Width / noteButtonWidth * 16;
        }

        public int GetNoteNumber()
        {
            return noteNumber;
        }

        public int GetChannel()
        {
            return channel;
        }
    }
}
