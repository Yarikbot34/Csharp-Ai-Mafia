namespace AiMafia.Models;

public class AiMessage
{
    public string model {get; set;}
    public string name{get; set;}
    public string message{get; set;}
    
    public AiMessage(string model, string name, string message)
    {
        this.model = model;
        this.name = name;
        this.message = message;
    }
}