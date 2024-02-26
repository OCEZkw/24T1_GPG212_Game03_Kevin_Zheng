using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    // Define a structure for orders
    public struct Order
    {
        public string topping; // The topping to be added to the order
        public float timeLimit; // Time limit for completing the order
    }

    public List<Order> orderQueue = new List<Order>(); // Queue of orders
    public float orderSpawnInterval = 5f; // Time interval between new orders
    private float timeSinceLastOrder; // Time since the last order was spawned

    public Image orderImage;
    public Sprite[] orderSprites;

    void Update()
    {
        // Update the time since the last order
        timeSinceLastOrder += Time.deltaTime;

        // Check if it's time to spawn a new order
        if (timeSinceLastOrder >= orderSpawnInterval)
        {
            // Spawn a new order
            SpawnOrder();

            // Reset the timer
            timeSinceLastOrder = 0f;
        }


    }

    void SpawnOrder()
    {
        // Create a new order and add it to the queue
        Order newOrder = new Order
        {
            topping = GetRandomTopping(),
            timeLimit = 10f // Set the time limit for the order (adjust as needed)
        };
        orderQueue.Add(newOrder);

        orderImage.sprite = GetOrderSprite(newOrder.topping);

        // Optionally, you can display the new order on the screen or provide feedback
        Debug.Log("New Order: " + newOrder.topping + ". Time Limit: " + newOrder.timeLimit + "s");

    }

    Sprite GetOrderSprite(string topping)
    {
        // Find and return the corresponding sprite for the given topping
        foreach (var sprite in orderSprites)
        {
            if (sprite.name == topping)
            {
                return sprite;
            }
        }
        return null; // Handle the case when no matching sprite is found
    }


    string GetRandomTopping()
    {
        // Add your list of toppings here
        string[] toppings = { "Cheese", "Tomato", "Mushroom", "Pepperoni" };

        // Return a random topping
        return toppings[Random.Range(0, toppings.Length)];
    }
}
