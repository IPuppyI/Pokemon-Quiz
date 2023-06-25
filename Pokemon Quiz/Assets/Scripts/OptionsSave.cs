using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class OptionsSave
{
    private static OptionsConfig optionsConfig;

    public static void Save(OptionsConfig config, string filename)
    {
        optionsConfig = config;
        string jsonData = JsonConvert.SerializeObject(optionsConfig, Formatting.Indented);

        string path = Path.Combine(Application.persistentDataPath, filename);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonData);
        }

        Debug.Log("OptionsConfig saved to: " + path);
    }
}
