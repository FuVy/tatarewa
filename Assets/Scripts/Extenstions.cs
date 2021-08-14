public static class Extenstions
{
    public static int WordStart(this string text, int initialIndex)
    {
        int i = initialIndex;
        while ((char.IsLetter(text[i]) || text[i] == '-') && i > 0)
        {
            i--;
        }
        return i;
    }

    public static int WordEnd(this string text, int initialIndex)
    {
        int i = initialIndex;
        while ((char.IsLetter(text[i]) || text[i] == '-') && i < text.Length)
        {
            i++;
        }
        return i;
    }

    public static int SentenceEnd(this string text, int currentIndex)
    {
        for (int i = currentIndex; i < text.Length; i++)
        {
            if (text[i] == '.' || text[i] == '!' || text[i] == '?')
            {
                return i;
            }
        }
        return text.Length - 1;
    }
}
