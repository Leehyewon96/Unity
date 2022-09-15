using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTest : MonoBehaviour
{
    UnityEvent myEvent;

    delegate int Calc(int n1, int n2);
    Calc delegateCalc = null;

    delegate void FuncHandler();
    FuncHandler funcHander = null;

    int Addnum(int n1, int n2)
    {
        return n1 + n2;
    }

    int SubNum(int n1, int n2)
    {
        return n1 - n2;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(myEvent == null)
        {
            myEvent = new UnityEvent();
        }

        myEvent.AddListener(Event1);
        myEvent.AddListener(Event2);

        delegateCalc = new Calc(Addnum);
        Debug.Log(delegateCalc(11, 33));

        delegateCalc = new Calc(SubNum);
        Debug.Log(delegateCalc(11, 33));

        funcHander = new FuncHandler(Func1);
        funcHander += new FuncHandler(Func2);
        funcHander += new FuncHandler(Func3);
        funcHander += new FuncHandler(Func1);
        //funcHander();
    }

    void Func1()
    {
        Debug.Log("Func1");
    }

    void Func2()
    {
        Debug.Log("Func2");
    }

    void Func3()
    {
        Debug.Log("Func3");
    }

    void Event1()
    {
        Debug.Log("Event 1 ~~~");
    }

    void Event2()
    {
        Debug.Log("Event 2 !!!");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))//우클릭
        {
            myEvent.Invoke(); //추가된 이벤트들이 순차적으로 실행됨
            funcHander();
        }
    }
}
