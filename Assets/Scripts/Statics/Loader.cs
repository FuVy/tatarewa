using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Loader<T> where T : new()
{
    private static string _path;

    public static object Load(string path)
    {
        _path = path;
        if (Exists())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);
            var data = formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            return CreateFile();
        }
    }
    private static bool Exists()
    {
        return File.Exists(_path);
    }

    private static object CreateFile()
    {
        MonoBehaviour.print(_path);
        File.Create(_path).Close();
        var data = new T();
        return data;
    }

    public static void CreateEmpty(string path)
    {
        File.Create(path).Close();
    }

    public static void Save(string path, T data)
    {
        _path = path;
        if (Exists())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var file = File.Open(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, data);
            }
        }
        else
        {
            CreateFile();
        }
    }
}
