using UnityEngine;

public enum Month
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12
}

[System.Serializable]
public struct Date
{
    [Range(1,31)] public int day;
    public Month month;
    public int year;

    public string GetDate()
    {
        return $"{day} {month} {year}";
    }

    public string GetNumericalDate()
    {
        return $"{day} {(int)month} {year}";
    }
}
