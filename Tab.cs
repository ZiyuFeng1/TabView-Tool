using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#if UNITY_EDITOR

public class Tab 
{
    [MenuItem("GameObject/UI/Tab View")]

    private static void ShowWindow()
    {
        //创建一个名为Canvas的物体
        CreateUIPanel();
        //在它下面创建一个子物体     
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void CreateUIPanel()
    {

        GameObject tabView = new GameObject("TabVeiw",typeof(RectTransform),typeof(TabViewScript));
        tabView.layer = 5;


       if (Selection.activeGameObject==null)

        {
            if(UnityEngine.Object.FindObjectOfType<Canvas>() == null)
            {
                GameObject canvas = new GameObject("Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
              
                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
               
                tabView.transform.SetParent(canvas.transform);
                canvas.layer = 5;
            }
            else
            {
              
                tabView.transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);
               
            }           
           
        }

        else 
        {
            tabView.transform.SetParent(Selection.activeGameObject.transform);
            if (tabView.GetComponentInParent<Canvas>() == null)
            {
                GameObject canvas = new GameObject("Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));            
                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
               
                tabView.transform.SetParent(canvas.transform);
               
                canvas.transform.parent = Selection.activeGameObject.transform;
                canvas.layer = 5;
            }
                      
            
        }
        
        tabView.GetComponent<RectTransform>().anchoredPosition=new Vector3(0.0f, 0.0f, 0.0f);

        if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
        {

            GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }



        



        
       
        //-------------------------标题-----------------------------------------

      

        GameObject image = new GameObject("Header Image", typeof(RectTransform),typeof(Image));
        image.transform.SetParent(tabView.transform);
        image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 450, 0);
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(1800, 110);
        image.GetComponent<Image>().color=new Color(1f,1f, 1f, 0.3f);
        image.layer = 5;
        GameObject text_image=new GameObject("text", typeof(RectTransform),typeof(Text),typeof(CanvasRenderer));
        text_image.transform.SetParent(image.transform);
        text_image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        text_image.GetComponent<RectTransform>().sizeDelta = new Vector2(1800, 60);
        text_image.GetComponent<Text>().text = "TITLE TEXT AT HERE";
        text_image.GetComponent<Text>().color = Color.black;
        text_image.GetComponent<Text>().fontSize = 40;
        text_image.GetComponent<Text>().alignment= TextAnchor.MiddleCenter;
        text_image.layer = 5;

        //---------------------------内容----------------------------------------
        GameObject box=new GameObject("Button&Page",typeof(RectTransform));
        box.transform.SetParent(tabView.transform);
        box.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        box.layer = 5;

        //—————————————左边选项-------------------------------
        GameObject tabArea= new GameObject("Tab Area",typeof (RectTransform),typeof(Image),typeof(CanvasRenderer),typeof(ScrollRect));
        tabArea.transform.SetParent(box.transform);
        tabArea.GetComponent<RectTransform>().anchoredPosition = new Vector3(-810f, -60f, 0f);
        tabArea.GetComponent<RectTransform>().sizeDelta = new Vector2(170f, 840f);
        tabArea.GetComponent<ScrollRect>().horizontal = false;
        tabArea.GetComponent<ScrollRect>().vertical = true;
        tabArea.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
        tabArea.GetComponent<ScrollRect>().elasticity = 0.3f;
        tabArea.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        
        tabArea.layer = 5;
        //------
        GameObject viewport = new GameObject("Viewport", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image),typeof(Mask));
        viewport.transform.SetParent(tabArea.transform);
        viewport.GetComponent<RectTransform>().anchoredPosition = new Vector3(-87, 420, 0);
        viewport.GetComponent<RectTransform>().sizeDelta=new Vector2(174,840);
      
        viewport.GetComponent<RectTransform>().pivot=new Vector3(0, 1, 0);
        viewport.GetComponent<Mask>().showMaskGraphic = false;
        
        tabArea.GetComponent<ScrollRect>().viewport = viewport.GetComponent<RectTransform>();


        viewport.layer = 5;

        //--------
        GameObject content= new GameObject("Content", typeof(RectTransform), typeof(GridLayoutGroup), typeof(TabGroup));
        content.transform.SetParent(viewport.transform);
        content.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 400);
        content.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        content.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        content.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        content.GetComponent<GridLayoutGroup>().spacing = new Vector2(0, 40);
        content.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
        content.GetComponent<TabGroup>().tabIdle = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
        content.GetComponent<TabGroup>().tabHover = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
        content.GetComponent<TabGroup>().tabActive = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Checkmark.psd");
        tabArea.GetComponent<ScrollRect>().content=content.GetComponent<RectTransform>();
        content.layer = 5;

   


        //-----------新建页面------------
        GameObject pageArea = new GameObject("Page Area", typeof(RectTransform),typeof(PageArea));
        pageArea.transform.SetParent(box.transform);
        pageArea.GetComponent<RectTransform>().anchoredPosition = new Vector3(120, -65, 0);
        pageArea.GetComponent<RectTransform>().sizeDelta = new Vector2(1540, 840);
        pageArea.layer = 5;

        //----------------------------------------------------
        creatButtonAndPage(content, "Button 01", pageArea, "Page 01","This is Page01");
        creatButtonAndPage(content, "Button 02", pageArea, "Page 02","This is Page02");
        creatButtonAndPage(content, "Button 03", pageArea, "Page 03","This is Page03");





    }

    static public void creatButtonAndPage(GameObject content,string buttonName,GameObject pageArea,string pageName,string pageText)
    {
        GameObject button = new GameObject(buttonName, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(TabButton));
        button.transform.SetParent(content.transform);
        button.GetComponent<TabButton>().tabGroup=content.GetComponent<TabGroup>();
        
        
        button.layer=5;

        





        GameObject scrollView = new GameObject(pageName, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(ScrollRect));
        scrollView.transform.SetParent(pageArea.transform);
        scrollView.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        scrollView.GetComponent<RectTransform>().sizeDelta = new Vector2(1540, 840);
        scrollView.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        
        scrollView.layer = 5;


        GameObject viewport_page = new GameObject("View Port", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Mask));
        viewport_page.transform.SetParent(scrollView.transform);
        viewport_page.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        viewport_page.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        viewport_page.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        viewport_page.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        viewport_page.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        viewport_page.GetComponent<Image>().sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd");
        viewport_page.GetComponent<Mask>().enabled = false;
        viewport_page.layer = 5;

        GameObject content_page = new GameObject("Content", typeof(RectTransform));
        content_page.transform.SetParent(viewport_page.transform);
        content_page.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        content_page.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 840);
        content_page.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        content_page.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        content_page.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        scrollView.GetComponent<ScrollRect>().content = content_page.GetComponent<RectTransform>();
        content_page.layer = 5;

        GameObject text_page=new GameObject("Text",typeof(Text));
        text_page.transform.SetParent(content_page.transform);
        text_page.GetComponent<Text>().text = pageText;
        text_page.GetComponent<Text>().color = Color.black;
        text_page.GetComponent<RectTransform>().anchoredPosition=new Vector3(0, 0, 0);
        text_page.GetComponent<RectTransform>().sizeDelta = new Vector2(1540, 840);
        text_page.GetComponent<Text>().fontSize = 100;



        if (content.GetComponent<TabGroup>().objectToSwap==null)
        {
            content.GetComponent<TabGroup>().objectToSwap=new List<GameObject>();
        }
        content.GetComponent<TabGroup>().objectToSwap.Add(scrollView);



    }

    
    






#endif





}






