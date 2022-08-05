using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string name;
    public int id;
}


public class CSharpDictionary : MonoBehaviour
{
    Dictionary<string, string> myDictionary = new Dictionary<string, string>();
    public Dictionary<int, Item> ItemList = new Dictionary<int, Item>();



    private void Start()
    {
        myDictionary.Add("Name", "Sam");
        myDictionary.Add("Surname", "Smith");

        // Printing the Sam of Name    //
        Debug.LogFormat("<color=cyan> For Key=\"Name\", Value={0},</color>", myDictionary["Name"]);


        // Altering The Dictionary value associated with a Key //
        myDictionary["Name"] = "David";

        Debug.LogFormat("<color=cyan> For Changed Key=\"Name\", Value={0},</color>", myDictionary["Name"]);

        string value = "";
        if (myDictionary.TryGetValue("Name", out value))
        {
            Debug.LogFormat("<color=cyan> For Key=\"Namess\", Value={0},</color>", value);
        }
        else
        {
            Debug.LogFormat(value + "<color=yellow> For Key=\"Name\", Value={0}, Could not be found</color>");
        }

        // Get key before Inserting Them //
        if (myDictionary.ContainsKey("ID"))
            return;
        else
            myDictionary.Add("ID", "5462132");


        Debug.LogFormat(value + "<color=yellow> For Key=\"ID\", Value={0},</color>", myDictionary["ID"]);

        foreach (KeyValuePair<string, string> differentItem in myDictionary)
        {
            Debug.LogFormat("<color=green>For Each Loop      </color>" +
                "           <color=yellow>Key={0}, Value={1}, </color>",
                differentItem.Key, differentItem.Value);

        }

        // Getting The Keys Alone in Dictionary //
        Dictionary<string, string>.KeyCollection KeyColl = myDictionary.Keys;
        foreach (string s in KeyColl)
        {
            Debug.Log("Key = {0} " + s);
        }
        myDictionary.Add("NewKey", "NewValue");
        try
        {
            if (myDictionary.ContainsKey("NewKey"))
            {
                Debug.Log(myDictionary["NewKey"] + "<color=yellow>Deleted Successfuly</color>");
                myDictionary.Remove("NewKey");

            }
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError($"{myDictionary["NewKey"]} Does not Exist in the Current Context");

        }




        Item item_1 = new Item();
        item_1.name = "Paul";
        item_1.id   = 0;

       
        Item item_2 = new Item();
        item_2.name = "Simp";
        item_2.id = 1;

        Item item_3 = new Item();
        item_3.name = "Pammy";
        item_3.id = 2;



        ItemList.Add(0, item_1);
        ItemList.Add(1, item_2);
        ItemList.Add(2, item_3);



        Debug.Log($"{ItemList[0].name} Is the First Item");
        Debug.Log($"{ItemList[0].id} Is the First Item");

        var itemList_2 = ItemList[1].name;

        foreach (KeyValuePair<int, Item> item in ItemList)
        {
            Debug.Log("Item  is" + item);
        }


    }

}
