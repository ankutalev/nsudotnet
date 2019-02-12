using System;
using System.Collections.Generic;

namespace Guesser {
    class Guesser {
        private readonly Random _generator = new Random();
        private const int UpperBound = 51;
        private const int LowerBound = 0;
        private int _secretNumber = 42;
        private string _userName;
        private const string ExitMessage = "You can't even win this game, bustard {0}.\n{1} was the answer";
        private const string WonMessage = "It's the only achievement in your life, {0}, your win!";
        private const string StopWord = "q";

        private readonly string[] _humiliations =
            {"You're so stupid,{0}", "Your dog smarter than you, {0}", "Perl programmer - your,{0}, destiny, looser"};

        private DateTime _startTime;
        private readonly List<Tuple<int, char>> _history = new List<Tuple<int, char>>();

        static void Main(string[] args) {
            var guesser = new Guesser();
            guesser.GameCircle();
        }

        public void GameCircle() {
            Console.WriteLine("Tell me, whom I will humiliate");
            _userName = Console.ReadLine();
            _startTime = DateTime.Now;
            _secretNumber = _generator.Next(LowerBound, UpperBound);
            var tryCounter = 0;
            var userAnswer = UpperBound;

            while (userAnswer != _secretNumber) {
                userAnswer = ReadAnswer();
                tryCounter++;
                if (userAnswer == _secretNumber)
                    FinishGame(tryCounter);
                if (userAnswer < _secretNumber) {
                    _history.Add(Tuple.Create(userAnswer, '<'));
                    Console.WriteLine("Secret more than {0}", userAnswer);
                }
                else {
                    _history.Add(Tuple.Create(userAnswer, '>'));
                    Console.WriteLine("Secret less than {0}", userAnswer);
                }

                if (tryCounter % 4 == 0)
                    Console.WriteLine(_humiliations[_generator.Next(_humiliations.Length)], _userName);
            }
        }

        private int ReadAnswer() {
            Console.WriteLine("Guess the number,{0}!", _userName);
            var answerNumber = _secretNumber;
            var isCorrectInput = false;
            while (!isCorrectInput) {
                var answer = Console.ReadLine();
                if (answer == StopWord) {
                    Console.WriteLine(ExitMessage, _userName, _secretNumber);
                    Environment.Exit(0);
                }

                isCorrectInput = int.TryParse(answer, out answerNumber);
                if (!isCorrectInput)
                    Console.WriteLine("You must enter number, foolish kebab!");
            }

            return answerNumber;
        }

        private void FinishGame(int tryCounter) {
            var endTime = DateTime.Now;
            TimeSpan interval = endTime - _startTime;
            Console.WriteLine("You get it for {0} tries", tryCounter);
            var i = 1;
            foreach (var guessTry in _history) {
                Console.WriteLine("Your {0} try was {1} and it was {2} than {3} ", i, guessTry.Item1, guessTry.Item2,
                    _secretNumber);
                i++;
            }
            Console.WriteLine("And you played for {0} minutes and {1} seconds", interval.Minutes, interval.Seconds);
            Console.WriteLine(WonMessage, _userName);
            Environment.Exit(0);
        }
    }
}