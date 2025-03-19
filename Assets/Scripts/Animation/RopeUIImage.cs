using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeUIImage : MonoBehaviour
{
    public RectTransform startPoint; // Начальная точка
    public RectTransform endPoint; // Конечная точка
    public GameObject segmentPrefab; // Префаб сегмента (UI Image)
    public int segmentCount = 10; // Количество сегментов

    private List<RectTransform> segments = new List<RectTransform>();

    void Start()
    {
        GenerateRope();
    }

    void Update()
    {
        UpdateRope();
    }

    void GenerateRope()
    {
        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = Instantiate(segmentPrefab, transform);
            RectTransform rect = segment.GetComponent<RectTransform>();
            segments.Add(rect);
        }
    }

    void UpdateRope()
    {
        // Вычисляем длину каждого сегмента

        float segmentLength = Vector2.Distance(startPoint.anchoredPosition, endPoint.anchoredPosition) / segmentCount;

        Vector2 prevPosition = startPoint.position;
        for (int i = 0; i < segments.Count; i++)
        {
            RectTransform segment = segments[i];

            // Позиция сегмента
            Vector2 targetPosition = Vector2.Lerp(startPoint.position, endPoint.position, (float)(i + 1) / segmentCount);
            segment.position = targetPosition;

            // Угол наклона
            Vector2 direction = (targetPosition - prevPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            segment.rotation = Quaternion.Euler(0, 0, angle);

            // Устанавливаем размер сегмента
            segment.sizeDelta = new Vector2(segment.sizeDelta.y, segmentLength);

            prevPosition = segment.position;
        }
    }
}