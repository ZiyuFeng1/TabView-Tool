using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TabViewScript : MonoBehaviour
{
    GameObject tabGroup;
    GameObject pageArea;
    int index;




    public void GetChildern()
    {
        if(GetComponentsInChildren<TabButton>().Length > 0)
        {
            TabButton[] count =this.GetComponentsInChildren<TabButton>();
            index = count.Length+1;
        }
        else
        {
            Debug.Log("Button没挂或者被删完了");
            return;
        }
        

        if(this.GetComponentsInChildren<TabGroup>().Length>0&& this.GetComponentsInChildren<PageArea>().Length>0)
        {
            
            tabGroup = this.GetComponentsInChildren<TabGroup>()[0].gameObject;
            tabGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(tabGroup.GetComponent<RectTransform>().sizeDelta.x, (tabGroup.GetComponent<RectTransform>().sizeDelta.y + 140));
            pageArea = this.GetComponentsInChildren<PageArea>()[0].gameObject;
        }
        else
        {
            Debug.Log("组件忘记挂了");
            return;
        }

        
       

        string buttonName = "Button"+ index.ToString().PadLeft(2, '0');
        string pageName = "Page"+ index.ToString().PadLeft(2, '0');
        string pageText = "This is Page"+index.ToString().PadLeft(2,'0');


        Tab.creatButtonAndPage(tabGroup, buttonName, pageArea, pageName, pageText);
        

    }


    [CustomEditor(typeof(TabViewScript))]
    public class TabViewEditor : Editor
    {
        


        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();
            TabViewScript myScript = (TabViewScript)target;

            if (GUILayout.Button("创建新页面"))
            {
                myScript.GetChildern();

            }

        }



    }

}
