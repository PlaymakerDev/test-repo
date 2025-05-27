using UnityEngine;

public class ItemBase : MonoBehaviour, IInteractable
{
    public ItemData data;

    public void Interact()
    {
        // Debug.Log("Interaction item : " + data.name);
        Debug.Log("Interaction item : " + data.itemName);
        InventoryManager.instance.AddItem(data);
        Destroy(gameObject);
    }
}
