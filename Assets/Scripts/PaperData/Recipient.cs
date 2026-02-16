[System.Serializable]
public struct Recipient
{
    public Greeting greeting;
    public string recipient;

    public string GetRecipient()
    {
        return $"{greeting.GetClosingValue()} {recipient},";
    }
}
