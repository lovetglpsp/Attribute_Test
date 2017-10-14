using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TestAttribute;
using UnityEngine;
public class MsgManager  {

    //private delegate void NoParDelegate();
    //private delegate void ParDelegate(int value);

    private Dictionary<int, Action> allNoParDele = new Dictionary<int, Action>();
    private Dictionary<int, Action<int>> allParDele = new Dictionary<int, Action<int>>();

    private Dictionary<int, MethodInfo> allNoParameters = new Dictionary<int, MethodInfo>();
    private Dictionary<int, MethodInfo> allParameters = new Dictionary<int, MethodInfo>();
    object dObj;
    public MsgManager()
    {
        Message msg = new Message();
        Type type = typeof(Message);//Type.GetType("Message");
        dObj = Activator.CreateInstance(type);
        BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;



        MethodInfo[] finfos = type.GetMethods(flag);

        foreach (MethodInfo finfo in finfos)
        {
            foreach(Attribute attr in finfo.GetCustomAttributes(true))
            {
                MsgAttribute msgA = (MsgAttribute)attr;
                if (msgA!=null)
                {
                    int name = msgA.GetMessage();
                    if (finfo.GetParameters().Length > 0)
                    {
                        //Debug.Log(name);
                        allParameters.Add(name, finfo);//finfo.Invoke(dObj,null);
                        allParDele.Add(name, (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), msg, finfo.Name,true));
                    }
                    else
                    {
                        //Debug.Log(name);
                        allNoParameters.Add(name, finfo);//finfo.Invoke(dObj,null);
                        allNoParDele.Add(name, (Action)Delegate.CreateDelegate(typeof(Action), msg,finfo.Name, true));
                    }
                }
            }
        }
    }

    public void DoMessage(int n)
    {
        //Stopwatch watch1 = Stopwatch.StartNew();

        if (allNoParameters.ContainsKey(n))
        {
            allNoParameters[n].Invoke(dObj, null);
        }
        //watch1.Stop();
        //UnityEngine.Debug.Log(watch1.Elapsed.ToString());
    }
    public void DoMessage(int n,int value)
    {
        //Stopwatch watch2 = Stopwatch.StartNew();
        if (allParameters.ContainsKey(n))
        {
            object[] obj = new object[] { value };
            allParameters[n].Invoke(dObj, obj);
        }
        //watch2.Stop();
        //UnityEngine.Debug.Log(watch2.Elapsed.ToString());
    }
    public void DoMessageDele(int n)
    {
        //Stopwatch watch3 = Stopwatch.StartNew();
        if (allNoParDele.ContainsKey(n))
        {
            allNoParDele[n]();
        }
        //watch3.Stop();
        //UnityEngine.Debug.Log(watch3.Elapsed.ToString());
    }

    public void DoMessageDele(int n,int value)
    {
        //Stopwatch watch4 = Stopwatch.StartNew();
        if (allParDele.ContainsKey(n))
        {
            allParDele[n](value);
        }
        //watch4.Stop();
        //UnityEngine.Debug.Log(watch4.Elapsed.ToString());
    }
}
