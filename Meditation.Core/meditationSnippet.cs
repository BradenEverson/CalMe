namespace Meditation.Core
{
    internal class meditationSnippet
    {
        public string name { get; }
        public string content { get; }
        public meditationSnippet(string name, string content)
        {
            this.name = name;
            this.content = content;
        }
    }
}