using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    private void Awake()
    {
        Instance = this;
    }
}
