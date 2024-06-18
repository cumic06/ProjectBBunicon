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
    //ObseverManager의 Notify함수에서 받은 제네릭 매개변수를 받아 사용하기위해 Func<T>(T t)함수를 사용했는데
    //여러 ObseverFunc를 사용함에 있어서 원하는 실행 내용이 다를수 있으니 반환값을 object를 사용해 모든 데이터값을 반환값으로 사용할수 있게함
    //박싱에 있어서 메모리를 많이 사용하기때문에 따로 반환값이 있는 Action을 만들어사용
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

