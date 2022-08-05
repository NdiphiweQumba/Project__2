using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    /// <summary>
    /// Create A Singleton for this since its only going to be the Pool ///
    /// </summary>
    public static ObjectPooler _instance;


    /// <summary>
    /// Property Methods
    /// </summary>
    public static ObjectPooler Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Object Pooler is Null");
            return _instance;
        }
    }

    public int NumberOfObjectsToSpawn = 10;
    public Transform SpawneeContainer;

    [SerializeField]
    public GameObject Food_Prefab;
    [SerializeField]
    private List<GameObject> FoodPool;

    private void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// Spawn Objects At Start ///
    /// </summary>
    private void Start()
    {
        FoodPool = GenerateFood(NumberOfObjectsToSpawn);
        SpawneeContainer.SetParent(this.transform);
    }


    /// <summary>
    /// Generate Prefabs using The List Variable ///
    /// </summary>
    /// <param name="numberOfSpawnees"></param>
    /// <returns></returns>
    private List<GameObject> GenerateFood(int  numberOfSpawnees)
    {
        for (int i = 0; i < numberOfSpawnees; i++)
        {
            GameObject food = Instantiate(Food_Prefab);
            food.transform.SetParent(SpawneeContainer.transform);
            FoodPool.Add(food);
         
            food.SetActive(false);
        }
        return FoodPool;
    }

    /// <summary>
    /// Activate One GameObject a Time in FoodPool With ForEachLoop
    /// </summary>
    /// <returns></returns>
    public GameObject RequestFood()
    {
        foreach (GameObject food_item in FoodPool)
        {
            if (food_item.activeInHierarchy == false)
            {
                food_item.SetActive(true);
                return food_item;
            }
        }

        GameObject new_item_food = Instantiate(Food_Prefab);
        new_item_food.transform.SetParent(SpawneeContainer);
        FoodPool.Add(new_item_food);
        Debug.Log("New Food Item Spawned");
        return new_item_food;
    }
}
