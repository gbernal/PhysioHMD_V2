using UnityEngine;
using UnityEngine.SceneManagement;
using aGlassDKII;

public class GameGaze : MonoBehaviour
{
    int count;
	void Start ()
	{
        print(aGlass.Instance.aGlassStart());
    }

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && (SceneManager.GetActiveScene ().buildIndex == 0 || SceneManager.GetActiveScene ().buildIndex == 1)) {
			Application.Quit ();
		}
        if (aGlass.Instance.GetEyeValid())
        {
            print(aGlass.Instance.GetGazePoint().x);
            print(aGlass.Instance.GetGazePoint().y);
        }
    }


	void OnDestroy ()
	{
        print(aGlass.Instance.aGlassStop());
    }

	public void GetPos (GameObject c, ref float cx, ref float cy)
	{
		if (aGlass.Instance.GetEyeValid()) {
			count = 0;
			if (!c.activeSelf) {
				c.SetActive (true);
			}
            cx = aGlass.Instance.GetGazePoint().x;
            cy = aGlass.Instance.GetGazePoint().y;
		} else {
			count++;
			if (count > 10 && c.activeSelf) {
				c.SetActive (false);
			}
		}
	}
}