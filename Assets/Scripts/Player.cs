using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Update()
    {
        UpdatePlayerDirection();
        MovePlayer();
    }

    private void UpdatePlayerDirection()
    {
        gameManager.playerDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MovePlayer()
    {
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            gameManager.playerPosition += gameManager.playerDirection;
            for(int i = 0; i < gameManager.boxes.Length; i++)
            {
                Vector2 currentBox = gameManager.boxes[i];
                Vector2 targetBox = gameManager.playerPosition + gameManager.playerDirection;
                if(gameManager.playerPosition == currentBox && !gameManager.boxes.Equals(targetBox))
                {
                    gameManager.boxes[i] += gameManager.playerDirection;
                    if(CheckWall(gameManager.boxes[i]))
                    {
                        gameManager.boxes[i] -= gameManager.playerDirection;
                        gameManager.playerPosition -= gameManager.playerDirection;
                    }
                    break;
                }
            }
            if(gameManager.boxes.Equals(gameManager.playerPosition))
                gameManager.playerPosition -= gameManager.playerDirection;
            if(CheckWall(gameManager.playerPosition))
                gameManager.playerPosition -= gameManager.playerDirection;
        }
    }

    private bool CheckWall(Vector2 position)
    {
        return position.x < 0 || position.x >= gameManager.mapSizeX || position.y < 0 || position.y >= gameManager.mapSizeY;
    }
}
