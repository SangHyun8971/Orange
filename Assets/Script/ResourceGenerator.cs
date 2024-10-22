using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ResourceGenerator : MonoBehaviour
{
    public Tilemap tilemap; // �̹� ������ Tilemap
    public GameObject[] prefab; // �ν��Ͻ�ȭ�� ��ü
    public int numberOfObjects = 5; // ������ ��ü ��

    List<Vector3Int> availablePositions;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        // Tilemap�� BoundsInt�� ����Ͽ� �׸����� ������ �����ɴϴ�.
        BoundsInt bounds = tilemap.cellBounds;
        availablePositions = new List<Vector3Int>();

        // Ÿ���� �ִ� ��ġ�� ����Ʈ�� �����մϴ�.
        for (int x = bounds.x + 5; x < bounds.x + bounds.size.x - 5; x++)
        {
            for (int y = bounds.y + 5; y < bounds.y + bounds.size.y - 5; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(position);
                if (tile != null)
                {
                    availablePositions.Add(position);
                }
            }
        }

        GeneratorResource();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GeneratorResource();
        }
    }

    public void GeneratorResource()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Resource");

        // ã�� ������Ʈ�� �ϳ��� �ı��մϴ�.
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        // �������� ��ü�� ������ ��ġ�� �����ϰ� ��ü�� �ν��Ͻ�ȭ�մϴ�.
        int attempts = 0; // ���� ���� ������ ���� �õ� Ƚ��
        const int maxAttempts = 100; // �ִ� �õ� Ƚ��

        for (int i = 0; i < numberOfObjects; i++)
        {
            bool placed = false;

            while (!placed && attempts < maxAttempts)
            {
                attempts++;
                if (availablePositions.Count > 0)
                {
                    int randomIndex = Random.Range(0, availablePositions.Count);
                    Vector3Int randomTilePosition = availablePositions[randomIndex];
                    Vector3 worldPosition = tilemap.GetCellCenterWorld(randomTilePosition);

                    // �浹 ���θ� Ȯ��
                    if (!IsPositionOccupied(worldPosition))
                    {
                        // �浹�� ������ ������Ʈ�� ��ġ
                        Instantiate(prefab[Random.Range(0, prefab.Length)], worldPosition, Quaternion.identity);
                        placed = true; // ������Ʈ�� ���������� ��ġ�Ǿ����� ǥ��
                    }
                }
            }

            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("�ִ� �õ� Ƚ���� �ʰ��߽��ϴ�. �� �̻� ������Ʈ�� ��ġ�� �� �����ϴ�.");
                break;
            }
        }
    }

    bool IsPositionOccupied(Vector3 position)
    {
        return Physics2D.OverlapBox(position, new(4, 4), 0f) != null;
    }
}