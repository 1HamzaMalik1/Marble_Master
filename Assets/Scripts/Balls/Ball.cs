/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// Coords of next target;
    /// </summary>
    public Vector3 NextNode;

    /// <summary>
    /// ID of ball. -1 if bonus.
    /// </summary>
    public int BallId { get; private set; }

    /// <summary>
    /// Path controller.
    /// </summary>
    public BezierPathController PathController;

    public bool MustBeDestroyed = true;

    public void SetBallId(int id)
    {
        BallId = id;
        GetComponent<MeshRenderer>().material = (id == -1) ? GameObject.FindGameObjectWithTag("BallsFactory").GetComponent<BallsFactory>().BonusMaterial : GameObject.FindGameObjectWithTag("BallsFactory").GetComponent<BallsFactory>().AvailableMaterials[id];
    }

    private IEnumerator SelfDestroyCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (MustBeDestroyed) Destroy(gameObject);
    }

    /// <summary>
    /// Interaction between objects.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        GetComponent<AnimationPlayer>().Play(AnimationThrowType.OnCollide);
        if (PathController.BallSequence.Contains(this)) return;
        if (other.gameObject.tag == "BallsTrap") return;
        
        StopAllCoroutines();
        if (other.gameObject.tag == "Ball")
        {
            PathController.InsertBallInSequence(this, other.GetComponent<Ball>());
            MustBeDestroyed = false;
        }
    }

    private IEnumerator ShootCoroutine(Vector3 target, float time)
    {
        var passedTime = 0f;
        var startPosition = transform.position;
        while (passedTime < time)
        {
            passedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, target, passedTime / time);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Shoot(Vector3 target, float time)
    {
        StartCoroutine(ShootCoroutine(target, time));
        StartCoroutine(SelfDestroyCoroutine(time));
    }

}
