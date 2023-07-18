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
    private static readonly string DataPath = LocalPath + "\\Data\\";
    private const string SpecialAbilitiesFile = "specialAbilities.json";
    private const string SpecialMaterialsFile = "specialMaterials.json";
    private const string TablesFile = "tables.json";

    public readonly List<SpecialAbility> SpecialAbilities;
    public readonly List<SpecialMaterial> SpecialMaterials;


    public ItemCreation()
    {
        Globals.Tables = LoadData<Tables>(TablesFile);
        SpecialAbilities = LoadArrayData<List<SpecialAbility>>(SpecialAbilitiesFile);
        SpecialMaterials = LoadArrayData<List<SpecialMaterial>>(SpecialMaterialsFile);
    }

    /// <summary>
    /// Receive the path to a data type and return the deserialized version of that data
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T LoadArrayData<T>(String path)
    {
        path = DataPath + path;
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
        path = DataPath + path;
        var data =
            JObject.Parse(
                File.ReadAllText(path));

        return JsonConvert.DeserializeObject<T>(data.ToString());
    }
}