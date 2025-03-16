﻿using midi_sequencer.src.model;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using midi_sequencer.src.service;
using midi_sequencer.src.view.component;

namespace midi_sequencer.view.component.piano_roll
{
    internal class PianoRollTray : Component
    {
        private PianoRoll pianoRoll;

        //private MidiService midiService;

        public PianoRollTray(PianoRoll pianoRoll)
        {
            this.pianoRoll = pianoRoll;

            //this.midiService = new();
        }

        public Grid Build()
        {
            ToolBarTray tbt = new();
            tbt.Height = 30;
            tbt.VerticalAlignment = VerticalAlignment.Top;

            ToolBar tb = new();
            Button build = new();
            build.Content = "Build";
            build.Click += Build_Click;
            tb.Items.Add(build);

            tbt.ToolBars.Add(tb);

            Grid grid = new();
            grid.Children.Add(tbt);

            return grid;
        }

        private void Build_Click(object sender, RoutedEventArgs e)
        {
            MidiEventMapper mapper = new();
            MessageBox.Show("clicked");
            List<MidiEvent> midi = mapper.mapAll(this.pianoRoll.GetNoteButtons());

            var collection = new MidiEventCollection(0, 128);

            collection.AddTrack();
            collection.AddTrack(midi);
            MidiService.GetInstance().AppendEndMarker(collection[0]);
            MidiService.GetInstance().AppendEndMarker(collection[1]);

            collection.PrepareForExport();
            MidiFile.Export("thisshitfuckinworks.mid", collection);
        }
    }
}
