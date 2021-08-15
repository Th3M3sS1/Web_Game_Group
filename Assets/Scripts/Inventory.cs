using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject inventoryObject;
    public Slot[] slots;

    private void Update()
    {   

        // for windows Control
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
        }
    }
    
    public void Additem(Item itemToBeAdded, Item startingItem=null)
    {

       /*
        foreach (Slot i in slots)
        {
            if (!i.slotsItem)
            {
                itemToBeAdded.transform.parent = i.transform;
                itemToBeAdded.gameObject.SetActive(false);
                
                return;
            }

        }*/
       
         int amountInStack = itemToBeAdded.amountInStack;
         List<Item> stackableItems= new List<Item>();
         List<Slot> emptySlots = new List<Slot>();

         if(startingItem && startingItem.itemId==itemToBeAdded.itemId && startingItem.amountInStack < startingItem.maxStackSize)
         {
             stackableItems.Add(startingItem);
         }

         foreach(Slot i in slots)
         {
             if (i.slotsItem)
             {
                 Item z = i.slotsItem;
                 if(z.itemId==itemToBeAdded.itemId && z.amountInStack < z.maxStackSize && z!=startingItem)
                 {
                     stackableItems.Add(z);
                 }
                 
            }
            else
            {
                emptySlots.Add(i);
            }

         }

         foreach(Item i  in stackableItems)
         {
             int amountThatCanBeAdded = i.maxStackSize - i.amountInStack;
             if (amountInStack<=amountThatCanBeAdded)
             {
                 i.amountInStack += amountInStack;
                Destroy(itemToBeAdded.gameObject);
                return;
             }
             else
             {
                 i.amountInStack = i.maxStackSize;
                 amountInStack -= amountThatCanBeAdded;
             }
         }
         itemToBeAdded.amountInStack = amountInStack;
         if (emptySlots.Count>0)
         {
             itemToBeAdded.transform.parent = emptySlots[0].transform;
            itemToBeAdded.gameObject.SetActive(false);
         }
         
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Item>())
        {
            Additem(col.GetComponent<Item>());
            SoundManager.PlaySound("collect");
        }
    }

}
