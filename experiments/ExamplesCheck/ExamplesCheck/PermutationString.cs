using System;
namespace ExamplesCheck
{
    public class PermutationString
    {
        string _string = string.Empty;
        string _prefix = string.Empty;

        public PermutationString(string str)
        {
            _string = str;
        }

        public void run()
        {
            run(_string, _prefix);
        }

        void run(string str, string prefix)
        {
            if(str.Length == 0)
            {
                System.Console.WriteLine(prefix);
            }
            else
            {
                for(var i = 0; i < str.Length; ++i)
                {
                    var rem = str.Substring(0, i) + str.Substring(i + 1);
                    run(rem, prefix + str[i]);
                }
            }
        }
    }
}
