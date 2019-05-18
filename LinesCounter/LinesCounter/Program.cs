using System;
using System.IO;

namespace LinesCounter {
    class Program {
        private const int BufferSize = 1000;
        static void Main(string[] args) {
            var buffer = new byte[BufferSize];
            foreach (var arg in args) {
                var files = Directory.EnumerateFiles("../../..", arg,
                    SearchOption.AllDirectories);
                var parser = new StateMachine(arg);
                foreach (var fileName in files) {
                    using (var file = File.OpenRead(fileName)) {
                        int readed;
                        do {
                            readed = file.Read(buffer, 0, buffer.Length);
                            parser.ParseDate(buffer, readed);
                        } while (readed == buffer.Length);
                        parser.Clear();
                    }
                }
                Console.WriteLine(" In language {0}",arg);
                parser.PrintResults();
            }
        }
    }
}