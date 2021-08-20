using System.Collections;
using System.Text.RegularExpressions;

public static class WordExtensions 
{
    public static int WordStart(this string text, int initialIndex)
    {
        int i = initialIndex;
        while (i > 0 && (char.IsLetter(text[i - 1]) || text[i - 1] == '-'))
        {
            i--;
        }
        return i;
    }

    public static int WordEnd(this string text, int initialIndex)
    {
        int i = initialIndex;
        while (i < text.Length && (char.IsLetter(text[i]) || text[i] == '-'))
        {
            i++;
        }
        return i;
    }
}
