using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Material material;
    private Player player;
    private Color defaultColor;

    public void Initialize(Player player)
    {
        this.player = player;
        this.player.OnSlide += ChangeColor;

        if (material != null)
        {
            defaultColor = material.color;
        }
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    public void ChangeColor()
    {
        if (material != null)
        {
            material.color = Random.ColorHSV();
        }
    }

    private void OnDestroy()
    {
        if (material != null)
        {
            material.color = defaultColor;
        }

        player.OnSlide -= ChangeColor;
    }
}
