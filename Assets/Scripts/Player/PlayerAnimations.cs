using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations 
{
    private SkeletonAnimation playerSpine;
    public SkeletonAnimation PlayerSpine => playerSpine;

    private const string runAnimation = "run";
    private const string idleAnimation = "idle";
    private const string jumpAnimation = "jump";
    private const string slideSlopeAnimation = "hoverboard";

    public PlayerAnimations(SkeletonAnimation playerSpine)
    {
        this.playerSpine = playerSpine;
    }

    public void EnableRunAnimation()
    {
        playerSpine.loop = true;
        playerSpine.AnimationName = runAnimation;
    }

    public void EnableIdleAnimation()
    {
        playerSpine.loop = true;
        playerSpine.AnimationName = idleAnimation;
    }

    public void EnableJumpAnimation()
    {
        playerSpine.loop = false;
        playerSpine.AnimationName = jumpAnimation;
    }

    public void EnableSlideSlopeAnimation()
    {
        playerSpine.loop = true;
        playerSpine.AnimationName = slideSlopeAnimation;
    }
}
