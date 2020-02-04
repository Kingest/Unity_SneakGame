using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 测试键盘按键点击按钮，失败了
/// </summary>
public class ButtonTest : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ButtonClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            
        }
    }
    public void ButtonClick()
    {

    }
}
