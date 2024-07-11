using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class logic_script : MonoBehaviour
{
    public GameObject cardsContainer;
    public List<Image> selectedCardSlots;

    private List<Button> availableCards = new List<Button>();
    private int currentSlotIndex = 0;

    void Start()
    {
        Debug.Log("Start method called");

        if (cardsContainer == null)
        {
            Debug.LogError("Cards container is not assigned!");
            return;
        }

        Button[] cardButtons = cardsContainer.GetComponentsInChildren<Button>();
        availableCards.AddRange(cardButtons);

        Debug.Log($"Found {availableCards.Count} card buttons");

        if (availableCards.Count == 0)
        {
            Debug.LogError("No card buttons found in the Cards container!");
            return;
        }

        foreach (var card in availableCards)
        {
            card.onClick.AddListener(() => OnCardClicked(card));
            Debug.Log($"Added click listener to {card.gameObject.name}");
        }

        Debug.Log($"Selected card slots count: {selectedCardSlots.Count}");
    }

    void OnCardClicked(Button clickedCard)
    {
        Debug.Log($"Card clicked: {clickedCard.gameObject.name}");

        if (currentSlotIndex >= selectedCardSlots.Count)
        {
            Debug.Log("All slots are filled!");
            return;
        }

        Image cardImage = clickedCard.GetComponent<Image>();
        if (cardImage == null)
        {
            Debug.LogError("Clicked card doesn't have an Image component!");
            return;
        }

        selectedCardSlots[currentSlotIndex].sprite = cardImage.sprite;
        selectedCardSlots[currentSlotIndex].color = Color.white;

        clickedCard.interactable = false;

        currentSlotIndex++;

        Debug.Log($"Placed {clickedCard.gameObject.name} in slot {currentSlotIndex}");
    }
}