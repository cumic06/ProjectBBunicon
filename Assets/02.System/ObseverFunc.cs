using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public delegate void Obsevers<T>(T t);

public class ObseverFunc<T> : I_Obsever
{
    //public Obsevers<U> Obsevers;
    public Func<T> Func;
    public Action<T> Obsevers = (a) => { };
    //ObseverManager�� Notify�Լ����� ���� ���׸� �Ű������� �޾� ����ϱ����� Func<T>(T t)�Լ��� ����ߴµ�
    //���� ObseverFunc�� ����Կ� �־ ���ϴ� ���� ������ �ٸ��� ������ ��ȯ���� object�� ����� ��� �����Ͱ��� ��ȯ������ ����Ҽ� �ְ���
    //�ڽ̿� �־ �޸𸮸� ���� ����ϱ⶧���� ���� ��ȯ���� �ִ� Action�� �������
    //public void Func(T t)
    //{
    //    Obsevers(t);

    //}
}
