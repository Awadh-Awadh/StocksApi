namespace Application.Exceptions;

public class FinhubException : Exception
{
    public FinhubException(string message, string description) : base($"{message} with description {description}")
    {
        Description = description;
    }

    public string Description { get; set; }
}  
