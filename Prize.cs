using System;
using System.Collections.Generic;

namespace Quest
{
    public class Prize
    {
        private string _text { get; }

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            int x = adventurer.Awesomeness;

            if (x > 0)
            {
                for (var i = x; i > 0; i--)
                {
                    Console.WriteLine(_text);
                }
            }
            else
            {
                Console.WriteLine("I pity the fool");
            }
        }
    }
}
