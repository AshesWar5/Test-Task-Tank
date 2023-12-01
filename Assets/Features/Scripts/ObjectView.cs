using UnityEngine;

namespace TestTask
{
    public class ObjectView : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}