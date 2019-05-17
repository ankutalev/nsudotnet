using System;
using System.Linq;
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
                Settings = Settings.Friends
            });
        }

        Vtentakle(string email) : this(email, ReadPassword()) {
        }

        private void ViewFriends() {
            var filter = new FriendsGetParams {Fields = ProfileFields.Nickname};
            filter.Fields = ProfileFields.LastName;
            filter.Fields = ProfileFields.FirstName;
            _friends = _vk.Friends.Get(filter);
            foreach (var friend in _friends) {
                Console.Write(friend.FirstName + " ");
                Console.WriteLine(friend.LastName);
                friend.FirstName = friend.FirstName.Replace('ё', 'е');
                friend.LastName = friend.LastName.Replace('ё', 'е');
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
                p.WriteMessages();
            }
            catch (VkApiAuthorizationException e) {
                Console.WriteLine("Probably, invalid credentials " + e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("Network error" + e.Message);
            }
        }

        private void WriteMessages() {
            while (true) {
                Console.WriteLine("Input user name or type \"exit\" to close program : ");
                var fullname = Console.ReadLine();
                if (fullname == "exit")
                    Environment.Exit(0);

                fullname = fullname.Replace('ё', 'е');
                var splitted = fullname.Split();

                if (splitted.Length != 2) {
                    Console.WriteLine("Incorrect user name! ");
                }

                var fpart = splitted[0];
                var spart = splitted[1];
                User requiredFriend;
                try {
                    requiredFriend = _friends.First(f =>
                        f.FirstName == fpart && f.LastName == spart || (f.FirstName == spart && f.LastName == fpart));
                }
                catch (Exception) {
                    Console.WriteLine("Friend doesnt exists!");
                    continue;
                }

                Console.WriteLine("Enter message!");
                var message = Console.ReadLine();
                var messageParams = new MessagesSendParams {
                    Message = message, UserId = requiredFriend.Id, RandomId = _random.Next()
                };
                _vk.Messages.Send(messageParams);
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