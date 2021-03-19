using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{

    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    //UI목록
    //모든 이름들을 찾아서 오브젝트를 연동시켜야 한다
    //컴포넌트를 갖고있는, 같은 이름을 갖고있는 거 찾기
    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }
    private void Start()
    {
        //리플렉션
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }


    int _score = 0;
    public void OnButtonClicked()
    {

    }

}
