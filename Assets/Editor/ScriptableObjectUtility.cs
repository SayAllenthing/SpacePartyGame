using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtility
{
    /// <summary>
    //	This makes it easy to create, name and place unique new ScriptableObject asset files.
    /// </summary>
	public static T CreateAsset<T>(string name = "New Item") where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

		string path = "Assets/Resources";

        if(asset.GetType() == typeof(WallObjectDatabase))
            path = "Assets/Resources/Modular/Walls";

        if (asset.GetType() == typeof(WallObjectData))
			path = "Assets/Resources/Modular/Walls/Data";

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + name + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

		return asset;
    }

	[MenuItem ("Assets/Create/Ship Wall Database/CreateDatabase")]
	public static void CreateDatabase()
	{
		ScriptableObjectUtility.CreateAsset<WallObjectDatabase>("WallObjectDatabase");
	}
}