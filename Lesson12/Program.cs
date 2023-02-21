using JFA.Telegram.Console;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


var users = new List<User>();

var botManager = new TelegramBotMananger();
var bot = botManager.Create("6222122663:AAHKVmMxhIP7Kw5unJPcTVw-uJ0MkAxsnKo");
botManager.Start(NewMessage);

void NewMessage(Update update)
{
    User user;

    var chatId = update.Message.From.Id;
    var message = update.Message.Text;

    if (users.Any(user => user.ChatId == chatId))
    {
        user = users.First(user => user.ChatId == chatId);
    }
    else
    {
        user = new User();
        user.ChatId = chatId;
        users.Add(user);
    }

    switch (user.NextMessage)
    {
        case ENextMessage.Menu:
            {
                switch (message)
                {
                    case "signin":
                        {
                            if (user == null)
                            {
                                SendMessage("Royxatdan oting");
                            }
                            else
                                SendMessage(user.ToText());
                        }
                        break;
                    case "signup":
                        {
                            SendMessage("Send phone:");
                            user.NextMessage = ENextMessage.Phone;
                        }
                        break;
                    default: SendMessage("Menu \n signin\n signup"); break;
                }
                break;
            }
        case ENextMessage.Phone:
            {
                SendMessage($"your phone: {message}");

                user.Phone = message;

                SendMessage("Send name:");
                user.NextMessage = ENextMessage.Name;

                break;
            }
        case ENextMessage.Name:
            {
                SendMessage($"your name: {message}");

                user.Name = message;

                SendMessage("Send age:");
                user.NextMessage = ENextMessage.Age;

                break;
            }
        case ENextMessage.Age:
            {
                SendMessage($"your age: {message}");

                user.Age = Convert.ToInt32(message);

                user.NextMessage = ENextMessage.Menu;
                break;
            }
    }


    void SendMessage(string message)
    {
        bot.SendTextMessageAsync(user.ChatId, message);
    }
}

enum ENextMessage
{
    Menu,
    Phone,
    Name,
    Age
}
enum ENextMessagew
{
    Created,
    Name,
    Menu,
    OutlayName,
    OutlayPrice
}
