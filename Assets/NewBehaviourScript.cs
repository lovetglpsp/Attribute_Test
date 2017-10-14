using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
public class NewBehaviourScript:MonoBehaviour {

	// Use this for initialization
	void Start () {
        MsgManager m = new MsgManager();
        m.DoMessage(100);
        m.DoMessageDele(200, 4545);
        Debug.Log("++++++++++++++++++++++++++++++++++++++++");
        m.DoMessageDele(100);
        m.DoMessageDele(300);
        m.DoMessageDele(200,1212);
        //double a = 350;
        //for(int i=1;i<=30;++i)
        //{
        //    a = (a * 0.055) + a;
        //    Debug.Log(i +":"+a);
        //}
        //Type magicType = Type.GetType("Message");
        //ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
        //object magicClassObject = magicConstructor.Invoke(new object[] { });

        // Get the ItsMagic method and invoke with a parameter value of 100

        //MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
        //object magicValue = magicMethod.Invoke(magicClassObject, new object[] { 100 });

        //Debug.Log("MethodInfo.Invoke() Example\n");
        //Debug.Log(magicValue);
    }


}

