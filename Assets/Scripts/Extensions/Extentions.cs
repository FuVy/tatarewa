using System.Text.RegularExpressions;

public static class Extentions
{ 
    public static Sentence[] Sentences(this string text)
    {
        string pattern = @"<.*?>|[!?.;IMCV]+(?=$|\s)";
        Regex rg = new Regex(pattern);
        string[] sentencesSplit = rg.Split(text);
        Sentence[] sentences = new Sentence[sentencesSplit.Length];
        int currentIndex = 0;
        for (int i = 0; i < sentencesSplit.Length; i++)
        {
            sentences[i].text = sentencesSplit[i];
            sentences[i].startIndex = text.IndexOf(sentences[i].text, currentIndex);
            currentIndex = sentences[i].endIndex = sentences[i].startIndex + sentences[i].text.Length;
        }
        return sentences;
    }
}
