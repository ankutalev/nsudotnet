using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;


namespace VSisyarpe {
    class Vtentakle {
        private const int AppId = 6983223;
        private readonly VkApi _vk;
        private VkCollection<User> _friends;
        private readonly Random _random = new Random();

        Vtentakle() : this(Console.ReadLine(), ReadPassword()) {
        }

        Vtentakle(string email, string password) {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            _vk = new VkApi(services);
            _vk.Authorize(new ApiAuthParams {
                ApplicationId = AppId,
                Login = email,
                Password = password,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                        {
                            Console.WriteLine("Enter Code:");
                            return Console.ReadLine();
                        }
            });
        }

        Vtentakle(string email) : this(email, ReadPassword()) {
        }

        private void ViewFriends() {
            var filter = new AudioGetParams() { Offset = 0, Count = 40};
            var x = _vk.Audio.Get(filter);
            foreach (var audio in x) {
                Console.WriteLine(audio.Title);
                _vk.Audio.Download(audio,@"c:\users\fix\desktop\a");
                var downloaded = Directory.GetFiles(@"c:\users\fix\desktop\a");
                Console.WriteLine($"DOWNLOAD{downloaded[0]}");
                File.Move(downloaded[0], $@"c:\users\fix\desktop\\a\\{audio.Title}.mp3");
                Console.WriteLine( $"{audio.Artist} {audio.Title}");
            }
        }

        private static void Main(string[] args) {
            try {
                Vtentakle p;
                switch (args.Length) {
                    case 1:
                        p = new Vtentakle(args[0]);
                        break;
                    case 2:
                        p = new Vtentakle(args[0], args[1]);
                        break;
                    default:
                        p = new Vtentakle();
                        break;
                }

                p.ViewFriends();
            }
            catch (VkApiAuthorizationException e) {
                Console.WriteLine("Probably, invalid credentials " + e.Message);
            }
        }

        private static string ReadPassword() {
            var sb = new StringBuilder();
            while (true) {
                var key = Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Red;
                if (key.Key == ConsoleKey.Backspace) {
                    Console.Write("\b \b");
                    if (sb.Length>0)
                        sb.Remove(sb.Length-1, 1);
                }
                else {
                    Console.Write("*");
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    sb.Append(key.KeyChar);
                }
            }

            Console.WriteLine();
            Console.ResetColor();
            return sb.ToString();
        }
    }
}