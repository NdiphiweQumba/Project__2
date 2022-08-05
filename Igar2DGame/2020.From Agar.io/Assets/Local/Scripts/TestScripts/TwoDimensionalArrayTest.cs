using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 
public class TwoDimensionalArrayTest : MonoBehaviour
{
    [System.NonSerialized] public bool iswhilestoped;

    private const int rows    = 5;
    private const int columns = 5;


    private void Start()
    {
        //int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

        int[] array = new int[] {1,2,3,4,5,
                                    6,7,8,9,10,
                                    11,12,13,14,
                                    15,16,17,18,19,20,
                                 21,22,23,24,25 };

        int[,] matrix = new int[5, 5];

        PrintSpiralOrder(array, matrix);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Debug.Log($"Matrix: {matrix[i, j]}");
            }
        }

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            iswhilestoped = true;
        }
    }

    public void PrintSpiralOrder(int[] arr, int[,] mat)
    {
        int top = 0, 
            left = 0, 
            bottom = columns - 1,
            right = rows - 1;


        int index = 0;
        do
        {
            if (left > right)
                break;
            for (int i = left; i <= right; i++)
                mat[top, i] = arr[index++];
            top++;
            Debug.Log("Top printed");

            if (top > bottom)
                break;
            for (int i = top; i < bottom; i++)
                mat[i, right] = arr[index++];
            right--;
            Debug.Log("Right printed");

            if (left > right)
                break;
            for (int i = right; i > left; i--)
                mat[bottom, i] = arr[index++];
            bottom--;
            Debug.Log("Bottom printed");


            if (bottom > top)
                break;
            for (int i = bottom; i > top; i--)
                mat[i, left] = arr[index++];
            left++;
            Debug.Log("Left printed");

        } while (true);
       

    }
}
