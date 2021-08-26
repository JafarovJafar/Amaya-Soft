using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardSpawner : MonoBehaviour
{
    private CustomLayout _layout;
    [SerializeField] GameObject cardPrefab;

    private List<Card> _spawnedCards = new List<Card>();
    
    public void Init(CustomLayout layout)
    {
        _layout = layout;
    }

    public void SpawnCard(CardData cardData, UnityAction<Card> Spawned)
    {
        GameObject cardGO = Instantiate(cardPrefab);

        Card card = cardGO.GetComponent<Card>();
        card.Init(cardData);
        _spawnedCards.Add(card);
        
        _layout.Add(cardGO.transform);
        cardGO.transform.localScale = Vector3.one;
        
        Spawned?.Invoke(card);
    }

    public void ClearCards()
    {
        foreach (Card card in _spawnedCards)
        {
            Destroy(card);
        }
    }
}