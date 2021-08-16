using System.Text.RegularExpressions;

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
        while ((char.IsLetter(text[i]) || text[i] == '-') && i < text.Length - 1)
        {
            i++;
        }
        return i;
    }

    public static Sentence[] Sentences(this string text)
    {
        string pattern = @"<.*?>|[!?.]+(?=$|\s)";
        Regex rg = new Regex(pattern);
        string[] sentencesSplit = rg.Split(text);
        Sentence[] sentences = new Sentence[sentencesSplit.Length];
        int currentIndex = 0;
        for (int i = 0; i < sentencesSplit.Length; i++)
        {
            sentences[i].text = sentencesSplit[i];
            sentences[i].startIndex = text.IndexOf(sentencesSplit[i], currentIndex);
            currentIndex = sentences[i].endIndex = sentences[i].startIndex + sentences[i].text.Length;
        }
        return sentences;
    }
}
