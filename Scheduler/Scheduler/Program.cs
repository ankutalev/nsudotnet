using System;

namespace Scheduler {
    public class Scheduler {
        private DateTime _inputData;
        private const string InputMessage = "Enter date, please!";

        public void ReadDate() {
            var isCorrectDate = false;
            while (!isCorrectDate) {
                Console.WriteLine(InputMessage);
                var userInput = Console.ReadLine();
                isCorrectDate = DateTime.TryParse(userInput, out _inputData);
            }
        }

        public void DrawSchedule() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Input data {0}", _inputData);
            Console.ResetColor();
            var knowWeekDay = new DateTime(2019, 02, 11); // surely first day of the week
            for (var i = 0; i < Enum.GetNames(typeof(DayOfWeek)).Length; i++) {
                Console.Write("{0:ddd}  ", knowWeekDay);
                knowWeekDay = knowWeekDay.AddDays(1);
            }

            Console.WriteLine();
            var monthBeginning = new DateTime(_inputData.Year, _inputData.Month, 1);
            var workDays = 0;
            for (var i = 0; i < ((int) monthBeginning.DayOfWeek + 6) % 7; i++) {
                Console.Write("    ");
            }

            while (monthBeginning.Month == _inputData.Month) {
                if (monthBeginning.DayOfWeek == DayOfWeek.Sunday || monthBeginning.DayOfWeek == DayOfWeek.Saturday) {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else {
                    Console.ResetColor();
                    workDays++;
                }

                if (monthBeginning.Day == _inputData.Day)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{0,2}  ", monthBeginning.Day);
                if (monthBeginning.DayOfWeek == DayOfWeek.Sunday) {
                    Console.WriteLine();
                }

                monthBeginning = monthBeginning.AddDays(1);
            }

            Console.WriteLine();
            Console.Write(" Work days without holidays in this month: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(workDays);
        }

        static void Main(string[] args) {
            var scheduler = new Scheduler();
            scheduler.ReadDate();
            scheduler.DrawSchedule();
        }
    }
}