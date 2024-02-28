using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public GameObject orderPrefab;
    public Transform ordersCanvas;

    void Start()
    {
        StartCoroutine(SpawnOrderRoutine());
    }

    IEnumerator SpawnOrderRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            SpawnOrder();
        }
    }

    void SpawnOrder()
    {
        GameObject newOrder = Instantiate(orderPrefab, /* Random position in 3D space */);
        // Customize order details (dish, timer, etc.) as needed

        // Update UI canvas based on the 3D order position
        Vector2 screenPos = Camera.main.WorldToScreenPoint(newOrder.transform.position);
        newOrder.GetComponent<Order>().SetCanvasPosition(screenPos);
    }
}