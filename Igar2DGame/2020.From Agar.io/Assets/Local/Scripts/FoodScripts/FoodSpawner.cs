using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodSpawner : MonoBehaviour
{
    /// <summary>
    /// This script should only get the children objects from the 
    /// ObjectPooler parent and set them active true ///  
    /// </summary>
    /// 
    /// Transform[] trans = transform.Cast<Transform>().ToArray();

    [SerializeField] private Transform FoodPoolerParent;

    public void Start()
    {
        for (int i = 0; i < FoodPoolerParent.childCount; i++)
        {
            FoodPoolerParent.GetChild(i).gameObject.SetActive(true);
        }
    }
}
