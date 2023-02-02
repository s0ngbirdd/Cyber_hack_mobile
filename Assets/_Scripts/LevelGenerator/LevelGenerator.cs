using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Public
    public static event Action OnTileSpawn;

    // Serialize
    [SerializeField] private Texture2D _map;
    [SerializeField] private ColorToPrefab[] _colorMappings;

    // Private
    private int _targetCount = 0;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for(int x = 0; x < _map.width; x++)
        {
            for(int y = 0; y < _map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = _map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            // The pixel is transparrent. Ignore it.
            return;
        }

        foreach (ColorToPrefab colorMapping in _colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                var tile = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);

                if (tile.tag.Equals("target"))
                {
                    tile.name = $"target{_targetCount++}";
                }
                else
                {
                    tile.name = $"Tile X:{x} Y:{y}";
                }

                if (tile.tag.Equals("Tile"))
                {
                    OnTileSpawn?.Invoke();
                }
            }
        }
    }
}
