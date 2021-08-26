using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<CardBundleData> _cardBundles;
    
    [SerializeField] CardSpawner cardSpawner;

    private List<string> _completedLevelsIDs = new List<string>();

    public UnityEvent Completed = new UnityEvent();
    public UnityEventCardBundleData SetNewLevel = new UnityEventCardBundleData();

    private int _currentLevel;
    private int _levelsCount = Enum.GetNames(typeof(CardBundleData.Difficulties)).Length;

    private CardBundleData currentBundleData;

    public void Init()
    {
        _currentLevel = 0;
        cardSpawner.ClearCards();
    }

    public void SetNextLevel()
    {
        if (currentBundleData != null)
        {
            _completedLevelsIDs.Add(currentBundleData.ID);
            _currentLevel++;

            if (_currentLevel == _levelsCount - 1)
            {
                Completed?.Invoke();

                return;
            }
        }

        _currentLevel++;

        currentBundleData = _cardBundles.Find(x =>
            x.Difficulty == (CardBundleData.Difficulties) _currentLevel);

        SetLevel(currentBundleData);

        SetNewLevel?.Invoke(currentBundleData);
    }

    private void SetLevel(CardBundleData bundle)
    {
        cardSpawner.ClearCards();

        CardData cardData;
        
        for (int i = 0; i < bundle.CardData.Length; i++)
        {
            cardData = bundle.CardData[i];
            int currentIndex = i;
            
            cardSpawner.SpawnCard(cardData, (card) =>
            {
                card.Touched.AddListener(() =>
                {
                    if (currentIndex == bundle.CorrectItemIndex)
                    {
                        card.BehaveCorrect(() =>
                        {
                            Completed?.Invoke();
                        });
                    }
                    else
                    {
                        card.BehaveIncorrect();
                    } 
                });
            });
        }
    }
}