using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIRope : MonoBehaviour
{
    public RectTransform startPoint; // Начальная точка
    public RectTransform endPoint; // Конечная точка
    public GameObject segmentPrefab; // Префаб сегмента веревки (Image)
    public int segmentCount = 10; // Количество сегментов
    public float smoothSpeed = 10f; // Скорость сглаживания

    private List<RectTransform> segments = new List<RectTransform>();
    public float size;
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
        float segmentLength = Vector2.Distance(startPoint.anchoredPosition, endPoint.anchoredPosition) / segmentCount;

        Vector2 prevPosition = startPoint.position;

        for (int i = 0; i < segments.Count; i++)
        {
            RectTransform segment = segments[i];

            // Плавное движение сегмента
            Vector2 targetPosition = Vector2.Lerp(prevPosition, endPoint.position, (float)(i + 1) / segmentCount);
            segment.position = Vector2.Lerp(segment.position, targetPosition, Time.deltaTime * smoothSpeed);

            // Устанавливаем угол наклона
            Vector2 direction = (targetPosition - prevPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            segment.rotation = Quaternion.Euler(0, 0, angle);

            // Растяжение сегментов
            //float distance = Vector2.Distance(prevPosition, targetPosition);
            segment.sizeDelta = new Vector2(size, segmentLength);

            prevPosition = segment.position;
        }
    }
}
