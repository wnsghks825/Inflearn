using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : UI_Base
{
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

    enum GameObjects
    {
        TestObject
    }

    private void Start()
    {
        //리플렉션
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

       GetText((int)Texts.ScoreText).text = "Bind Text";
    }


}
