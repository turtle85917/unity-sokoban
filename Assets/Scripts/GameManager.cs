using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mapSizeX;
    public int mapSizeY;
    public Camera Camera;
    public GameObject Player;
    public GameObject Ground;
    public GameObject Grounds;
    public GameObject Box;
    public GameObject Boxes;
    public GameObject Goal;
    public GameObject Goals;
    public Vector2[] boxes;
    public Vector2[] goals;
    public Vector2 playerPosition;
    public Vector2 playerDirection;
    public static GameManager instance;
    public readonly int step = 4;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Camera.transform.position = new Vector3(0, mapSizeY * step, mapSizeY * -step);
        Player = Instantiate(Player, GetPosition(playerPosition.x, playerPosition.y, 4), Quaternion.identity);
        for(int y = 0; y < mapSizeY; y++)
            for(int x = 0; x < mapSizeX; x++)
                Instantiate(Ground, GetPosition(x, y, 0), Quaternion.identity).transform.parent = Grounds.transform;
        foreach(Vector2 box in boxes)
            Instantiate(Box, GetPosition(box.x, box.y, 4), Quaternion.identity).transform.parent = Boxes.transform;
        foreach(Vector2 goal in goals)  
            Instantiate(Goal, GetPosition(goal.x, goal.y, 4), Quaternion.identity).transform.parent = Goals.transform;
    }

    public void Update()
    {
        Player.transform.position = Vector3.Lerp(
            Player.transform.position,
            GetPosition(playerPosition.x, playerPosition.y, 4),
            Time.deltaTime * 5f
        );
        for(int i = 0; i < Boxes.transform.childCount; i++)
        {
            Component child = Boxes.transform.GetChild(i);
            child.transform.position = Vector3.Lerp(child.transform.position, GetPosition(boxes[i].x, boxes[i].y, 4), Time.deltaTime * 5f);
            Switch switchObject = child.GetComponentInChildren<Switch>();
            switchObject.on = CheckGoal(boxes[i]);
        }
    }

    private bool CheckGoal(Vector2 box)
    {
        foreach(Vector2 goal in goals)
            if(goal.Equals(box))
                return true;
        return false;
    }

    private Vector3 GetPosition(float x, float y, float z)
    {
        return new((x - mapSizeX / 2) * step, z, (y - mapSizeY / 2) * step);
    }
}
