using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class OptionsManager
{
    private static OptionsConfig optionsConfig;

    public static void Load()
    {
        try
        {
            string path = Path.Combine(Application.persistentDataPath, "OptionsConfig.json");

            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonData = streamReader.ReadToEnd();
                optionsConfig =  JsonConvert.DeserializeObject<OptionsConfig>(jsonData);
            }
        }
        catch
        {
            Debug.LogWarning("Failed to load OptionsConfig from JSON file. Creating default.");
            optionsConfig = new OptionsConfig();
        }
    }
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

    public static OptionsConfig GetOptionsConfig()
    {
        return optionsConfig;
    }
}
