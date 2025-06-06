using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public int xStart, YStart;
    public InventoryObject inventory;
    public int xSpaceBetweenItems;
    public int ySpaceBetweenItems;
    public int numberOfColumns;
    Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();
    public GameObject selectionFrame;
    private GameObject currentSelectionFrame;
    private GameObject fallbackSelectionFrame;

    private void Start()
    {
        CreateDisplay();
        if (selectionFrame == null && fallbackSelectionFrame != null)
        {
            Debug.Log("Reassigning selection frame from fallback.");
            selectionFrame = fallbackSelectionFrame;
        }
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            itemDisplayed.Add(inventory.container[i], obj);
        }
    }

    private Vector3 getPosition(int i)
    {
        return new Vector3(
                xStart + (xSpaceBetweenItems * (i % numberOfColumns)),
                YStart + (-ySpaceBetweenItems * (i / numberOfColumns)),
                0f
            );
    }

    private void UpdateDisplay()
    {
        List<InventorySlot> slotsToRemove = new List<InventorySlot>();
        foreach (KeyValuePair<InventorySlot, GameObject> kvp in itemDisplayed)
        {
            if (!inventory.container.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                slotsToRemove.Add(kvp.Key);
            }
        }

        foreach (InventorySlot slot in slotsToRemove)
        {
            itemDisplayed.Remove(slot);
        }

        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (itemDisplayed.ContainsKey(inventory.container[i]))
            {
                itemDisplayed[inventory.container[i]].GetComponent<RectTransform>().localPosition = getPosition(i);
                itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    inventory.container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                itemDisplayed.Add(inventory.container[i], obj);
            }
        }

        UpdateSelectionFrame();
    }

    private void UpdateSelectionFrame()
    {
        if (currentSelectionFrame != null)
        {
            var selectedItem = inventory.GetSelectedItem();
            if (selectedItem != null)
            {
                int selectedIndex = inventory.container.IndexOf(selectedItem);
                if (selectedIndex != -1)
                {
                    currentSelectionFrame.GetComponent<RectTransform>().localPosition = getPosition(selectedIndex);
                }
                else
                {
                    Destroy(currentSelectionFrame);
                    currentSelectionFrame = null;
                }
            }
            else
            {
                Destroy(currentSelectionFrame);
                currentSelectionFrame = null;
            }
        }
    }

    private void OnItemSelected(InventorySlot slot)
    {
        AddSelectionFrame();
    }

    private void AddSelectionFrame()
    {
        if (selectionFrame == null)
        {
            return;
        }

        var selectedItem = inventory.GetSelectedItem();
        if (selectedItem == null)
        {
            if (currentSelectionFrame != null)
            {
                Destroy(currentSelectionFrame);
                currentSelectionFrame = null;
            }
            return;
        }

        if (currentSelectionFrame != null)
        {
            Destroy(currentSelectionFrame);
        }

        int selectedIndex = inventory.container.IndexOf(selectedItem);
        if (selectedIndex != -1)
        {
            currentSelectionFrame = Instantiate(selectionFrame, Vector3.zero, Quaternion.identity, transform);
            currentSelectionFrame.GetComponent<RectTransform>().localPosition = getPosition(selectedIndex);
            currentSelectionFrame.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Selected item index not found in container.");
        }
    }

    private void OnEnable()
    {
        inventory.OnItemSelected += OnItemSelected;
    }

    private void OnDisable()
    {
        inventory.OnItemSelected -= OnItemSelected;
    }
}