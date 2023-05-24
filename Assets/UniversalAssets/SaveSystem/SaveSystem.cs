using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static string FileName = "progress.fun";

    public static void SaveProgress(Progress progress) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + FileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        ProgressData data = new ProgressData(progress);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static ProgressData Load() {
        string path = Application.persistentDataPath + "/" + FileName;
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ProgressData data = formatter.Deserialize(stream) as ProgressData;
            stream.Close();
            return data;
        } else {
            Debug.Log("Файла нет");
            return null;
        }
    }

    public static void DeleteSaveFile() {
        string path = Application.persistentDataPath + "/" + FileName;
        if (File.Exists(path)) {
            File.Delete(path);
        }
    }

}
