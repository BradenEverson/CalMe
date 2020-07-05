using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Meditation.Core
{
    public enum meditationTypes
    {
        breathing,
        yoga,
        focus,
        mantra
    }
    public class Meditation
    {
        private readonly string[] anxietyYogaSnippets = new string[]
        {
            "Big toe pose: stand upright and bend over with a sturdy back, touch your toes and stay there for 30 seconds before breaking and returning upright. This stretch strengthens and helps your hamstrings",
            "Bound Angle Pose: Sit with your legs straight out in front of you, raising your pelvis on a blanket if your hips or groins are tight. Exhale, bend your knees, pull your heels toward your pelvis, then drop your knees out to the sides and press the soles of your feet together. This pose will help to open your hips"
        };
        private readonly string[] nouns = File.ReadAllLines("words/nouns.txt");
        private readonly string[] verbs = File.ReadAllLines("words/verbs.txt");
        private readonly string[] adverbs = File.ReadAllLines("words/adverbs.txt");
        private readonly string[] adjectives = File.ReadAllLines("words/adjectives.txt");
        //Dictionary with key values of meditationTypes, returns a list of meditationSnippet, a class that has a name and content
        private readonly Dictionary<meditationTypes, List<meditationSnippet>> mappedMeditations = new Dictionary<meditationTypes, List<meditationSnippet>>()
        {
            {meditationTypes.focus, new List<meditationSnippet>()
            {
                //Meditation snippets for auditory meditation
                new meditationSnippet("Focal Imagination", "Close your eyes. Think about your favorite <noun>. Imagine every single detail about it. Think about how <adjective> they are, and what you like to do with them, it could be you like to <verb> with it, or maybe how <adverb> it was gone"),
                new meditationSnippet("Imagine","Imagine you are actually a <noun> who likes to <verb>. Think about how <adjective> you are. ")
            }},
            {meditationTypes.breathing, new List<meditationSnippet>()
            {
                //Meditation snippets for breathing meditation
                new meditationSnippet("Box Breathing","Repeat this several times, breathe in from your nose for <num> seconds, hold for <num> seconds, then release from your mouth for <num> seconds"),
                new meditationSnippet("Counted Breathing","Repeat this <num> times. breathe in, count for a second, then breathe out for 2 seconds. Then breathe in ."),
                new meditationSnippet("Breathing mantra","Breathe in, while holding your breath think of the first word that comes to mind, wait <num> seconds, then as exhaling say that word to yourself"),
                new meditationSnippet("Calming Breath","Make a small circular hole with your mouth, suck the air in and feel the brisk coldness, then exhale through your nose. Repeat this until you notice that you're feeling tired")
            }},
            {meditationTypes.mantra, new List<meditationSnippet>()
            {
                //Meditation snippets for mantra meditation
                new meditationSnippet("Repeat a word from your childhood", "Think about your most prized memory from when you were little, then remember the location you were at. Repeat that word to yourself and really begin to feel it's meaning to you, as you repeat it remember every detail of the place and why it was so important to you"),
                new meditationSnippet("Random Word Repeatition", "Think of the word <b><noun></b>. Repeat that word to yourself again and again. Begin to admire the word for it's simplicity, get a true connection to it. Once you realize the deeper meaning to the word, you may continue on")
            }},
            {meditationTypes.yoga, new List<meditationSnippet>()
            {
                //Meditation snippets for yoga
                new meditationSnippet("Yoga for anxiety", "<anxietyyoga>")
            }}
        };
        private readonly List<meditationTypes> allMeditationTypes = Enum.GetValues(typeof(meditationTypes)).Cast<meditationTypes>().ToList();
        public string name { get; set; }
        public string content { get; set; }
        public meditationTypes meditationType { get; }
        public int id { get; set; }
        public bool wasLiked { get; set; }
        public Meditation(meditationTypes meditationType)
        {
            this.meditationType = meditationType;
            generateMeditation();
        }
        private void generateMeditation()
        {
            meditationSnippet meditationSnippet = mappedMeditations[meditationType][staticRandom.Instance.Next(0,mappedMeditations[meditationType].Count-1)];
            name = meditationSnippet.name;
            content = extrapolate(meditationSnippet.content);
        }
        private string extrapolate(string content)
        {
            content = content.Replace("<noun>", nouns[staticRandom.Instance.Next(0, nouns.Length - 1)]).Replace("<verb>", verbs[staticRandom.Instance.Next(0, verbs.Length - 1)]).Replace("<adjective>", adjectives[staticRandom.Instance.Next(0, adjectives.Length - 1)]).Replace("<adverb>", adverbs[staticRandom.Instance.Next(0, adverbs.Length - 1)]).Replace("<num>",staticRandom.Instance.Next(4,10).ToString()).Replace("<anxietyyoga>",anxietyYogaSnippets[staticRandom.Instance.Next(0,anxietyYogaSnippets.Length-1)]);
            return content;
        }
    }
}
