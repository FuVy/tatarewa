using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public static class Extenstions
{
    public static int WordStart(this string text, int initialIndex)
    {
        int i = initialIndex;
        while (i > 0 && (char.IsLetter(text[i-1]) || text[i-1] == '-'))
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

    public static Sentence[] Sentences(this string text)
    {
        string pattern = @"<.*?>|[!?.;]+(?=$|\s)";
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

    public static Vector3 ScreenToWorld(this Camera camera, Vector2 position2D)
    {
        Vector3 position = position2D;
        position.z = 0;
        return camera.ScreenToWorldPoint(position);
    }

    public static void Load(this TMP_InputField input, string text)
    {
        input.text = text;
    }

    public static void Load(this TMP_Text textField, string text)
    {
        textField.text = text;
    }
}
