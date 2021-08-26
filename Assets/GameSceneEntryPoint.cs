using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] InputController inputController;

    [SerializeField] GameBoard gameBoard;
    
    [SerializeField] CardSpawner cardSpawner;
    [SerializeField] GridLayout gridLayout;
    
    public CardData data;

    void Start()
    {
        inputController.Init(Camera.main);
        inputController.Enable();

        cardSpawner.SpawnCard(new CardData());
        cardSpawner.SpawnCard(new CardData());
        cardSpawner.SpawnCard(data);

        gameBoard.Enable();
    }
}