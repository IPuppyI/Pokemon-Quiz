using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class OptionsLoad
{
    private static OptionsConfig optionsConfig;

    public static void Load()
    {
        optionsConfig = LoadOptionsConfigFromJson("OptionsConfig.json");

        if (optionsConfig == null)
        {
            Debug.LogWarning("Failed to load OptionsConfig from JSON file. Creating default.");
            optionsConfig = new OptionsConfig();
        }
    }

    private static OptionsConfig LoadOptionsConfigFromJson(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonData = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<OptionsConfig>(jsonData);
            }
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + path);
            return null;
        }
    }

    public static OptionsConfig GetOptionsConfig()
    {
        return optionsConfig;
    }
}
