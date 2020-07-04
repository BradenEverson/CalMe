using System;
using System.Collections.Generic;
using System.Text;

namespace Meditation.Core
{
    public enum meditationTypes
    {
        breathing,
        yoga,
        auditory
    }
    public class Meditation
    {
        public string name { get; set; }
        public string content { get; set; }
        public meditationTypes meditationType { get; set; }
        public bool wasLiked { get; set; }
    }
}
