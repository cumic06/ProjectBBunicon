using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObseverFunc : I_Obsever
{
    public Delegate Func { get; set; }
    public Action<OptionPanel> Panel;
    public Action<EquipmentInfo> Info;


    public void SumDele(Action<OptionPanel> panel)
    {
        Func = panel;
    }
    public void SumDele(Action<EquipmentInfo> panel)
    {
        Func = panel;
    }

    //public delegate void Func<T>(T t);

    //public Func<> Funcs;

    //public Obsevers<U> Obsevers;
    //public Func<T> Func;
    //public Action<T> Obsevers = (a) => { };
    //ObseverManager�� Notify�Լ����� ���� ���׸� �Ű������� �޾� ����ϱ����� Func<T>(T t)�Լ��� ����ߴµ�
    //���� ObseverFunc�� ����Կ� �־ ���ϴ� ���� ������ �ٸ��� ������ ��ȯ���� object�� ����� ��� �����Ͱ��� ��ȯ������ ����Ҽ� �ְ���
    //�ڽ̿� �־ �޸𸮸� ���� ����ϱ⶧���� ���� ��ȯ���� �ִ� Action�� �������
    //public void Func(T t)
    //{
    //    Obsevers(t);

    //}
}

//public class Obsever
