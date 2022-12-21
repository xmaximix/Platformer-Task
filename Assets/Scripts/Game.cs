using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] FollowCube followCube;
    [SerializeField] Button restartButton;

    private Vector3 startPlayerPosition;

    void Start()
    {
        player.Initialize();
        startPlayerPosition = player.transform.position;

        followCube.Initialize(player);

        restartButton.onClick.AddListener(MovePlayerAtStart);
    }

    private void MovePlayerAtStart()
    {
        player.transform.position = startPlayerPosition;
    }
}
