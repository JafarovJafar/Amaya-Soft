using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] InputController inputController;

    [SerializeField] GameBoard gameBoard;
    
    [SerializeField] CardSpawner cardSpawner;
    [SerializeField] CustomLayout cardsLayout;

    [SerializeField] LevelGoalPanel levelGoalPanel;

    [SerializeField] LevelController levelController;
    [SerializeField] GameOverPanel gameOverPanel;
    
    void Start()
    {
        inputController.Init(Camera.main);
        inputController.Disable();

        cardSpawner.Init(cardsLayout);

        levelGoalPanel.Enable();
        
        gameBoard.Updated.AddListener(() =>
        {
            inputController.Enable();
        });
        gameBoard.Enable();

        levelController.Init();
        
        levelController.Completed.AddListener(() =>
        {
            inputController.Disable();
            gameOverPanel.Enable();
        });
        
        levelController.SetNewLevel.AddListener((bundleData) =>
        {
            inputController.Enable();
            
            string goal = bundleData.CardData[bundleData.CorrectItemIndex].Identifier;
            levelGoalPanel.SetGoal(goal);
        });

        levelController.LevelCompleted.AddListener(() =>
        {
            levelController.SetNextLevel();
        });

        levelController.SetNextLevel();
    }
}