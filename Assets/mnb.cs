/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class mnb : MonoBehaviour {
	public static AndroidJavaClass adjav;
	public static int count = 0;
	// Use this for initialization
	void Start () {
	
		if( Application.platform == RuntimePlatform.Android ) {
			// Initialize Fluct/ZucksAdnetSDK
			adjav = new AndroidJavaClass("com.dxone.zumablast.MainActivity");
			
			// ZucksAdnetSDK display banner
		//	adjav.CallStatic("onexit");
		//	if(count%5==0)
			adjav.CallStatic("showAd");
		//	count++;
			//adjav.Call("myrate");
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
