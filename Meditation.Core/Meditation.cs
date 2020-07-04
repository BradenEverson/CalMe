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
        guided,
        mantra
    }
    public class Meditation
    {
        private string[] nouns = File.ReadAllLines("words/nouns.txt");
        private string[] verbs = File.ReadAllLines("words/verbs.txt");
        private string[] adverbs = File.ReadAllLines("words/adverbs.txt");
        private string[] adjectives = File.ReadAllLines("words/adjectives.txt");
        //Dictionary with key values of meditationTypes, returns a list of meditationSnippet, a class that has a name and content
        private Dictionary<meditationTypes, List<meditationSnippet>> mappedMeditations = new Dictionary<meditationTypes, List<meditationSnippet>>()
        {
            {meditationTypes.focus, new List<meditationSnippet>()
            {
                //Meditation snippets for auditory meditation
                new meditationSnippet("Focal Imagination", "Close your eyes. Think about your favorite <noun>. Imagine every single detail about it. Think about how <adjective> they are, and what you like to do with them, it could be you like to <verb> with it, or maybe how <adverb> it was gone")
            }},
            {meditationTypes.breathing, new List<meditationSnippet>()
            {
                //Meditation snippets for breathing meditation
            }},
            {meditationTypes.guided, new List<meditationSnippet>()
            {
                //Meditation snippets for guided meditation
            }},
            {meditationTypes.mantra, new List<meditationSnippet>()
            {
                //Meditation snippets for mantra meditation
            }},
            {meditationTypes.yoga, new List<meditationSnippet>()
            {
                //Meditation snippets for yoga
            }}
        };
        private List<meditationTypes> allMeditationTypes = Enum.GetValues(typeof(meditationTypes)).Cast<meditationTypes>().ToList();
        public string name { get; set; }
        public string content { get; set; }
        public meditationTypes meditationType { get; }
        public int id { get; set; }
        public bool wasLiked { get; set; }
        public Meditation()
        {
            meditationType = allMeditationTypes[staticRandom.Instance.Next(0,allMeditationTypes.Count-1)];
            generateMeditation();
        }
        private void generateMeditation()
        {
            meditationSnippet meditationSnippet = mappedMeditations[meditationTypes.focus][staticRandom.Instance.Next(0,mappedMeditations[meditationTypes.focus].Count-1)];
            name = meditationSnippet.name;
            content = extrapolate(meditationSnippet.content);
        }
        private string extrapolate(string content)
        {
            content = content.Replace("<noun>", nouns[staticRandom.Instance.Next(0, nouns.Length - 1)]).Replace("<verb>", verbs[staticRandom.Instance.Next(0, verbs.Length - 1)]).Replace("<adjective>", adjectives[staticRandom.Instance.Next(0, adjectives.Length - 1)]).Replace("<adverb>", adverbs[staticRandom.Instance.Next(0, adverbs.Length - 1)]);
            return content;
        }
    }
}
