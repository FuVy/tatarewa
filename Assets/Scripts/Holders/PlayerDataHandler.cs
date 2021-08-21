using UnityEngine;

public static class PlayerDataHandler
{
    [SerializeField]
    private static PlayerData _data;

    public static PlayerData Data => _data;

    private static string _path = Application.persistentDataPath + "/PlayerData.bin"; // 

    public static void Init()
    {
        _data = (PlayerData)Loader<PlayerData>.Load(_path);
    }
    public static void Save()
    {
        Loader<PlayerData>.Save(_path, _data);
    }
}
