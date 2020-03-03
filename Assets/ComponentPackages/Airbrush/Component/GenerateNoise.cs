using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateNoise
{
    static float GetRandomChannel()
    {
        float random = Random.value;
        for (int r = 0; r < 4; ++r)
        {
            random += Random.value;
        }
        random /= 5.0f;
        return random;
    }

    static Color GetRandomColour()
    {
        Color colour = Color.black;
        colour.r = GetRandomChannel();
        colour.g = GetRandomChannel();
        colour.b = GetRandomChannel();
        return colour;
    }


    [MenuItem("Tools/Generate Noise Texture")]
    static void CreateAsset()
    {
        string path = 
            EditorUtility.SaveFilePanelInProject(
                "Generate random noise texture",
                "Noise.png",
                "png",
                "File name to write to");

        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        int width = 256;
        int height = 256;
        Texture2D texture = new Texture2D(width, height);
        Color [] pixels = texture.GetPixels();
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Color random = GetRandomColour();
                pixels[y * width + x] = random;
            }
        }
        texture.SetPixels(pixels);
        texture.Apply(false, false);
        File.WriteAllBytes(path, texture.EncodeToPNG());
        AssetDatabase.Refresh();
        var importer = AssetImporter.GetAtPath(path) as TextureImporter;
        importer.sRGBTexture = false;
        importer.mipmapEnabled = false;
        importer.filterMode = FilterMode.Point;

        importer.textureCompression =
            TextureImporterCompression.Uncompressed;

        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
    }
}
