using System;

namespace CisiCsharpDemos
{
    abstract class AbstractTaskSet : ITaskSet
    {
        public virtual void Open() { }

        public virtual void Close() { }

        public virtual void Run() { }

        public void PrintSection(string section)
        {
            int sectionLength = section.Length;
            string underline = new String('-', sectionLength + 2);

            Console.Write(string.Format("\n> {0}\n{1}\n", section, underline));
        }

        public void PrintEndSection()
        {
            PrintTextLine(string.Empty);
        }

        public void PrintText(string text)
        {
            Console.Write(text);
        }

        public void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
