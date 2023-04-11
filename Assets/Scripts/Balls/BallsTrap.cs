/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using System.Linq;
using UnityEngine;

public class BallsTrap : MonoBehaviour
{

    public static bool _gameOver = false;

    public static bool _win = false;

    public BezierPathController PathController;

    public AnimationManager AnimationManager;

    public MusicManager MusicManager;
	
	public GameObject GameOverMenu;
	
	public GameObject GameWonMenu;

    void Start()
    {
        StartCoroutine(CheckWinCoroutine());
    }

    private IEnumerator CheckWinCoroutine()
    {
        while (true)
        {
            if (PathController.Factory.GeneratedBalls == PathController.Factory.GeneratedBallsAmount &&
                PathController.BallSequence.Count == 0 && !_gameOver)
            {
                _win = true;
				GameWonMenu.active = true;
                MusicManager.Win();
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var ball = other.GetComponent<Ball>();
            if (PathController.BallSequence.Contains(ball))
            {
                PathController.DestroyBall(ball);
            }
        }

        ///Check to loose;
        if (other.gameObject.tag == "Ball" && PathController.BallSequence.Contains(other.GetComponent<Ball>()) && _gameOver == false)
        {
            MusicManager.Loose();
            PathController.StopSequence();
            AnimationManager.RunAnimation(AnimationThrowType.OnGameOver);
            _gameOver = true;
			GameOverMenu.active = true;
            PathController.MoveToDestroyAll();
        }
    }

//    private void OnGUI()
//    {
//        if (_gameOver)
//        {
//            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 50), "GameOver!");
//        }
//        if (_win)
//        {
//            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 50), "Win!");
//        }
//    }
}
