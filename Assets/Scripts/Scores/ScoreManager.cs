/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Texture BackgroundTexture;
    public int Scores = 0;

    public TextMesh TextMesh;

    void Update()
    {
        TextMesh.text = Scores.ToString();
        /*var aspectRatio = BackgroundTexture.width/BackgroundTexture.height;
        var height = Screen.width/aspectRatio;
        GUI.DrawTexture(new Rect(0,0,Screen.width, height), BackgroundTexture, ScaleMode.StretchToFill);
        Style.fontSize = (int)((height/(float)BackgroundTexture.height)*36);
        GUI.Label(new Rect( Screen.width/48f*32f, height/8f*2.5f, 250, 50), Scores.ToString(), Style);
         * */
    }
}
