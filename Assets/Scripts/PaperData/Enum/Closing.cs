using System;

public enum Closing
{
    Sincerely,
    Respectfully,
    Best_regards,
    Kind_regards,
    Fuck_you,
    Best,
    Best_wishes,
    Cheers,
    Love,
    Take_care,
    Warmly,
    Later
}

public static class EnumExtentions
{
    public static string GetClosingValue(this Enum value)
    {
        if (value.ToString().Contains("_"))
        {
            string newValue = value.ToString().Replace("_", " ");
            
            return newValue;
        }
        else
        {
            return value.ToString();
        }

    }
}