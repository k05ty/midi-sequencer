﻿using midi_sequencer.src.view.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace midi_sequencer.src.view.component.general
{
    internal class StatusBar : Component
    {
        private Brush brush;

        public StatusBar()
        {
            brush = (SolidColorBrush)new BrushConverter().ConvertFromString("#36495a");
        }

        public Grid Build()
        {
            Grid grid = new();
            grid.Background = brush;

            return grid;
        }
    }
}
