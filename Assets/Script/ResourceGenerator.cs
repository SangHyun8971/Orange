using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ResourceGenerator : MonoBehaviour
{
    public Tilemap tilemap; // 이미 설정된 Tilemap
    public GameObject[] prefab; // 인스턴스화할 객체
    public int numberOfObjects = 5; // 생성할 객체 수

    List<Vector3Int> availablePositions;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        // Tilemap의 BoundsInt를 사용하여 그리드의 범위를 가져옵니다.
        BoundsInt bounds = tilemap.cellBounds;
        availablePositions = new List<Vector3Int>();

        // 타일이 있는 위치를 리스트에 저장합니다.
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

        // 찾은 오브젝트를 하나씩 파괴합니다.
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        // 랜덤으로 객체를 생성할 위치를 선택하고 객체를 인스턴스화합니다.
        int attempts = 0; // 무한 루프 방지를 위한 시도 횟수
        const int maxAttempts = 100; // 최대 시도 횟수

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

                    // 충돌 여부를 확인
                    if (!IsPositionOccupied(worldPosition))
                    {
                        // 충돌이 없으면 오브젝트를 배치
                        Instantiate(prefab[Random.Range(0, prefab.Length)], worldPosition, Quaternion.identity);
                        placed = true; // 오브젝트가 성공적으로 배치되었음을 표시
                    }
                }
            }

            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("최대 시도 횟수를 초과했습니다. 더 이상 오브젝트를 배치할 수 없습니다.");
                break;
            }
        }
    }

    bool IsPositionOccupied(Vector3 position)
    {
        return Physics2D.OverlapBox(position, new(4, 4), 0f) != null;
    }
}