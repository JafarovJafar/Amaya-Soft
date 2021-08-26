using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] GridLayout gridLayout;
    [SerializeField] GameObject cardPrefab;
    
    public void SpawnCard(CardData cardData)
    {
        GameObject cardGO = Instantiate(cardPrefab);

        Card card = cardGO.GetComponent<Card>();
        card.Init(cardData);
        cardGO.transform.localScale = Vector3.one;

        gridLayout.Add(cardGO.transform);
    }
}