using UnityEngine;
using UnityEngine.UI;
public class Count321 : MonoBehaviour
{
    Text b;
    float scale = 1.7f;
    float acum = 0;
    void Start()
    {
        b = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        acum += Time.deltaTime;
        b.text = (3 - (int)(acum*scale)).ToString();
        if (acum >= 3/scale)
        {
            gameObject.SwitchPage("page");
        }
    }
}
