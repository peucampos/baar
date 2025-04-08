using UnityEngine;
using System.Collections.Generic;

public class BackgroundGenerator : MonoBehaviour
{
    public Color backgroundColor;
    public List<Sprite> grassSprites;
    public List<Sprite> objectSprites;
    public int tileSize = 16;

    void Start()
    {
        Camera.main.backgroundColor = backgroundColor;
        GenerateBackground();
    }

    void GenerateBackground()
    {
        float screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
        float screenHeight = Camera.main.orthographicSize * 2;

        float startX = -screenWidth / 2;
        float startY = -screenHeight / 2;

        for (float y = startY; y < startY + screenHeight + tileSize; y += tileSize)
        {
            for (float x = startX; x < startX + screenWidth + tileSize; x += tileSize)
            {
                Vector3 position = new Vector3(x, y, 0);
                CreateTile(position, grassSprites[Random.Range(0, grassSprites.Count)]);
            }
        }

        // Add some objects on top of the grass
        for (int i = 0; i < objectSprites.Count; i++)
        {
            Vector3 position = new Vector3(Random.Range(startX, startX + screenWidth), Random.Range(startY, startY + screenHeight), 0);
            CreateTile(position, objectSprites[i]);
        }
    }

    void CreateTile(Vector3 position, Sprite sprite)
    {
        GameObject tile = new GameObject("Tile");
        tile.transform.position = position;
        SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
}
