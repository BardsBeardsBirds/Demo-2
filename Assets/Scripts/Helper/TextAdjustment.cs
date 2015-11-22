using System;
public class TextAdjustment
{
    public static string ReplaceUnderscores(string text)
    {
        string newText = text.Replace("_", " ");

        return newText;
    }
}