using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topsid.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "topsid.txt";

            if (args.Length > 0)
                fileName = args[0];
            
            var file = new FileInfo(fileName);

            if (!file.Exists)
                System.Console.WriteLine("File " + fileName + " does not exists in the same directory as this executable.");
            else
            {
                var topsid = new List<Tops>();

                using (var sr = new StreamReader(file.OpenRead()))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();

                        var splitted = line.Split(' ');

                        var tops = new Tops(int.Parse(splitted[0]), int.Parse(splitted[1]), int.Parse(splitted[2]));

                        topsid.Add(tops);
                    }
                    
                }

                var topsidCollection = new TopsCollection(topsid);

                var komplektid = topsidCollection.Komplekteeri();

                Present(komplektid);

                System.Console.ReadLine();
            }
            
           

        }

        public static void Present(List<TopsCollection.Komplekt> komplektid)
        {
            foreach (var komplekt in komplektid)
            {
                System.Console.WriteLine(string.Join(" ", komplekt.Topsid.Select(x => x.Number)));
            }
        }
    }
}
