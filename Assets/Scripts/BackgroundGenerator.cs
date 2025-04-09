using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;

public class BackgroundGenerator : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;
    public Color backgroundColor;
    public List<Sprite> grassSprites;
    public List<Sprite> objectSprites;
    public int tileSize = 16;

    void Start()
    {
        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine Camera not assigned. Please assign a Cinemachine Virtual Camera.");
            return;
        }

        SetBackgroundColor();
        GenerateBackground();
    }

    void SetBackgroundColor()
    {
        //Camera mainCamera = cinemachineCamera.VirtualCameraGameObject.GetComponent<Camera>();
        //if (mainCamera != null)
        //{
        //    mainCamera.backgroundColor = backgroundColor;
        //}
        //else
        //{
        //    Debug.LogError("Main Camera not found in Cinemachine Virtual Camera. Ensure you have a Camera component.");
        //}
    }

    void GenerateBackground()
    {
        Camera mainCamera = cinemachineCamera.VirtualCameraGameObject.GetComponent<Camera>();
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found in Cinemachine Virtual Camera. Ensure you have a Camera component.");
            return;
        }

        // Get the orthographic size and aspect ratio
        float screenHeight = mainCamera.orthographicSize * 2;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Calculate the start positions
        float startX = Mathf.Floor(mainCamera.transform.position.x - screenWidth / 2 / tileSize) * tileSize;
        float startY = Mathf.Floor(mainCamera.transform.position.y - screenHeight / 2 / tileSize) * tileSize;

        // Generate grass tiles
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
        tile.transform.parent = this.transform; // Set the parent to the GameObject this script is attached to
        SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
}
