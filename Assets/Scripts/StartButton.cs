using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public void OnPressStart()
	{
		SceneManager.LoadScene("Gameplay");
	}
}
