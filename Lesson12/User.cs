
class User
{
    public string Phone;
    public string Name;
    public int Age;
    public ENextMessage NextMessage;
    public long ChatId;

    public string ToText()
    {
        return $"ChatId: {ChatId}, Phone: {Phone}, Name: {Name}, Age: {Age}";
    }
}