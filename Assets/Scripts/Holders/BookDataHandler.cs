using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class BookDataHandler
{
    [SerializeField]
    private static BookData _data;

    public static BookData Data => _data;

    private static string _path;

    public static void Load(string title)
    {
        _path = Application.persistentDataPath + "/" + title + ".bin"; // 
        
        if (!File.Exists(_path))
        {
            var textfile = Resources.Load("Text/" + title) as TextAsset;
            _data = new BookData(title, textfile.text);
            Loader<BookData>.CreateEmpty(_path);
            Save();
        }
        else
        {
            _data = (BookData)Loader<BookData>.Load(_path);
            MonoBehaviour.print("loaded " + _data.LeftOff);
        }
    }
    public static void Save()
    {
        Loader<BookData>.Save(_path, _data);
    }

}
