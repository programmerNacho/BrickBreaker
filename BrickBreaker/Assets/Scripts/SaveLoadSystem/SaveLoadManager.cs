using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadManager
{
    private static LevelData[] levelsData;

    public static void Serialize(LevelData[] levelsData)
    {
        SaveLoadManager.levelsData = new LevelData[levelsData.Length];
        levelsData.CopyTo(SaveLoadManager.levelsData, 0);

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, SaveLoadManager.levelsData);
        stream.Close();
    }

    public static LevelData[] DeSerialize()
    {
        string path = Application.persistentDataPath + "/save.data";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            levelsData = formatter.Deserialize(stream) as LevelData[];
            stream.Close();
        }

        return levelsData;
    }
}
