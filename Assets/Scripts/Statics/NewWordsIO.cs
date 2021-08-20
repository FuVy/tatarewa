using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public static class NewWordsIO 
{
    private static NewWords _currentWords;

    public static NewWords CurrentWords => _currentWords;

    private static string _path;

    public static void Init(string fileName)
    {
        _path = Application.persistentDataPath + "/" + fileName + ".bin"; //
        ReadWords();
    }

    public static void ReadWords()
    {
        if (Exists())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);
            _currentWords = formatter.Deserialize(stream) as NewWords;
            stream.Close();
        }
        else
        {
            CreateFile();
        }
    }

    private static bool Exists()
    {
        return File.Exists(_path);
    }

    private static void CreateFile()
    {
        File.Create(_path).Close();
        _currentWords = new NewWords();
    }

    public static void SaveWords()
    {
        if (Exists())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var file = File.Open(_path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, _currentWords);
            }
            //file.Flush();
        }
        else
        {
            CreateFile();
        }
    }
}
