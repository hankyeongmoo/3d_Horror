using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] static public int stageIndex;
    static public bool changeStage;

    public GameObject player;

    void Start()
    {
        stageIndex = 1;
        changeStage = false;
    }

    void Update()
    {
        if (changeStage == true && player != null)
        {
            player.transform.position = getInitialPos();
            changeStage = false;
        }
    }

    Vector3 getInitialPos()
    {
        switch (stageIndex)
        {
            case 2:
                return new Vector3 (-17.5f + 100f, 4.1f, -8f);
            case 3:
                return new Vector3 (-17.5f + 200f, 4.1f, -8f);
            case 4:
                return new Vector3 (-17.5f + 300f, 4.1f, -8f);
            case 5:
                return new Vector3 (-17.5f + 400f, 4.1f, -8f);
            default:
                return new Vector3 (-17.5f, 4.1f, -8f);
        }
    }
}
