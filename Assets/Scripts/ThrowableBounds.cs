using UnityEngine;

public class ThrowableBounds: MonoBehaviour
{
    public PolygonCollider2D areaCollider;

    void Start()
    {

        MoveToPerimeter();
    }

    public void MoveToPerimeter()
    {
        if (areaCollider == null)
        {
            Debug.LogWarning("No 2D collider assigned!");
            return;
        }

        Bounds bounds = areaCollider.bounds;

        float left = bounds.min.x;
        float right = bounds.max.x;
        float bottom = bounds.min.y;
        float top = bounds.max.y;

        Vector2 newPosition = Vector2.zero;

        // Randomly choose one of the four sides
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: // Top edge
                newPosition = new Vector2(Random.Range(left, right), top);
                break;
            case 1: // Bottom edge
                newPosition = new Vector2(Random.Range(left, right), bottom);
                break;
            case 2: // Left edge
                newPosition = new Vector2(left, Random.Range(bottom, top));
                break;
            case 3: // Right edge
                newPosition = new Vector2(right, Random.Range(bottom, top));
                break;
        }

        transform.position = newPosition;
    }
}
