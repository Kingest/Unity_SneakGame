using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
//二进制储存方法需要引入的命名空间
public class PlayerHPControl : MonoBehaviour
{
    public float PlayerHP = 100;
    private Animator animator;
    public Slider slider;
    public Button save;
    public Button load;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        slider.value = 1f;
        //save.onClick.AddListener(SaveButton);
        //load.onClick.AddListener(LoadButtton);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerHP * 0.01f;
        if (PlayerHP <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }
    public void Damange(float damage)
    {
        PlayerHP -= damage;
        
    }
    //private SaveData Save()//注意此处不是void！！！！！！是Save对象
    //{
    //    SaveData saveData = new SaveData();
    //    saveData.hp = PlayerHP;
    //    return saveData;
    //}
    //private void SetData(SaveData save)
    //{
    //    PlayerHP = save.hp;
    //}
    //void BinSave()//二进制储存方法
    //{
    //    SaveData save1 = Save();
    //    //创建一个二进制格式化程序
    //    BinaryFormatter bf = new BinaryFormatter();
    //    //创建一个文件流
    //    FileStream fileStream = File.Create(Application.dataPath + "/SaveData" + "/byBin.txt");
    //    //用二进制格式化程序的序列化对象方法来序列化SaveData对象
    //    bf.Serialize(fileStream, save1);
    //    //关闭流
    //    fileStream.Close();
    //}
    //void BinLoad()
    //{
    //    if (File.Exists(Application.dataPath+"/SaveData"+"/byBin.txt"))//如果文件路径存在
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();//创建一个二进制格式化程序
    //        FileStream fileStream = File.Open(Application.dataPath + "/SaveData" + "/byBin.txt",FileMode.Open);//打开一个文件流
    //        SaveData save = (SaveData)bf.Deserialize(fileStream);//调用格式化反序列化方法，把文件流转换成一个SaveDate对象
    //        fileStream.Close();//关闭文件流
    //        SetData(save);
            
    //    }
    //}
   
    //public void SaveButton()//绑定按钮
    //{
    //    BinSave();
    //}
    //public void LoadButtton()
    //{
    //    BinLoad();
    //}

}
