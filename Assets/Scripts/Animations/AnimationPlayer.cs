/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Animation player.
/// </summary>
[RequireComponent(typeof(Animation))]
public class AnimationPlayer : MonoBehaviour
{
    /// <summary>
    /// AnimationManager script.
    /// </summary>
    public AnimationManager AnimationManager;

    /// <summary>
    /// List of animations.
    /// </summary>
    public List<AnimationMatching> AnimationMatchings;

    private Animation _animation;

    private void Register()
    {
        var manager = GameObject.FindGameObjectWithTag("GlobalManager");
        AnimationManager = manager.GetComponent<AnimationManager>();
        AnimationManager.AnimationListeners.Add(this);
    }

    void Awake()
    {
        _animation = GetComponent<Animation>();
        Register();
        Play(AnimationThrowType.OnAwake);
    }

    /// <summary>
    /// Play animation assigned on action.
    /// </summary>
    /// <param name="throwType">ActionType.</param>
    public void Play(AnimationThrowType throwType)
    {
        try
        {
            foreach (
                var animationMatching in
                    AnimationMatchings.Where(
                        animationMatching => animationMatching.ThrowType == throwType && animationMatching.Clip != null)
                )
            {
                _animation.clip = animationMatching.Clip;
                _animation.Play(animationMatching.Clip.name);
            }
        }
        catch (Exception)
        {
        }
    }
}
