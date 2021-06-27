using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(PlayerController pc, int count)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.test";

        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData data = new SavedData(pc, count);

        data.levelToLoad = "New";

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedData LoadGame()
    {
        string path = Application.persistentDataPath + "/game.test";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data = formatter.Deserialize(stream) as SavedData;

            data.levelToLoad = "Level1";

            stream.Close();

            return data;
        }
        else
            return null;
    }
}
