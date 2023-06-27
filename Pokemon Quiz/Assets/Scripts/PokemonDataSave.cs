using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class PokemonDataSave
{
    public static void SaveListAsJson(List<PokemonInfo> list, string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}