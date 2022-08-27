using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class ViewManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadSceneAsync("_UnityObjectPoolTest/Unity");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync("_UniRxObjectPoolTest/UniRx");
            }
        }
    }
}