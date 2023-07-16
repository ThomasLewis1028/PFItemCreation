using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PFItemCreation.Models;

namespace PFItemCreation;

static class Globals
{
    public static Tables Tables;
}

public class ItemCreation
{
    private static readonly string? LocalPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    private static readonly string _dataPath = LocalPath + "\\Data\\";
    private static readonly string _specialAbilitiesFile = "specialAbilities.json";
    private static readonly string _tablesFile = "tables.json";

    public readonly List<SpecialAbilities> SpecialAbilities;


    public ItemCreation()
    {
        Globals.Tables = LoadData<Tables>(_tablesFile);
        SpecialAbilities = LoadArrayData<List<SpecialAbilities>>(_specialAbilitiesFile);
    }

    /// <summary>
    /// Receive the path to a data type and return the deserialized version of that data
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T LoadArrayData<T>(String path)
    {
        path = _dataPath + path;
        var data =
            JArray.Parse(
                File.ReadAllText(path));

        return JsonConvert.DeserializeObject<T>(data.ToString());
    }

    /// <summary>
    /// Receive the path to a data type and return the deserialized version of that data
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T LoadData<T>(String path)
    {
        path = _dataPath + path;
        var data =
            JObject.Parse(
                File.ReadAllText(path));

        return JsonConvert.DeserializeObject<T>(data.ToString());
    }
}