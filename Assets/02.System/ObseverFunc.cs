using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObseverFunc : I_Obsever
{


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
    //public Action<Inventory> Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<JangBeSlot> JangBeSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<OptionPanel> OptionPanel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<MoveButton> MoveButton { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Action<Inventory> OnInventory { get; set; }
    public Action<JangBeSlot> OnJangBeSlot { get; set; }
    public Action<OptionPanel> OnOptionPanel { get; set; }
    public Action<MoveButton> OnMoveButton { get; set; }
}

