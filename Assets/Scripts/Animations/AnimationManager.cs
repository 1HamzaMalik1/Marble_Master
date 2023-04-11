/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    /// <summary>
    /// List of animation players.
    /// </summary>
    public List<AnimationPlayer> AnimationListeners;
    
    /// <summary>
    /// Run specified animations in listeners.
    /// </summary>
    /// <param name="throwType"></param>
    public void RunAnimation(AnimationThrowType throwType)
    {
        foreach (var animationListener in AnimationListeners)
        {
            animationListener.Play(throwType);
        }
    }

}
