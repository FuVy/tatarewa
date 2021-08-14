public static class Extenstions
{
    public static int WordStart(this string text, int initialIndex)
    {
        int i = initialIndex;
        while (char.IsLetter(text[i]))
        {
            i--;
        }
        return i;
    }

    public static int WordEnd(this string text, int initialIndex)
    {
        int i = initialIndex;
        while (char.IsLetter(text[i]))
        {
            i++;
        }
        return i;
    }
}
