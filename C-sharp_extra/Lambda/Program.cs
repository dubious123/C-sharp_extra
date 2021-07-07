using System;
using System.Collections.Generic;

namespace Lambda
{
    class Program
    {
        //Lambda : 일회용 함수를 만드는데 사용하는 문법이다 가끔 딱 한번만 쓰이고 버리는 함수가 필요할 때가 있는대 그때 유용하다.
        enum ItemType
        {
            Weapon,
            Armor,
            Amulet,
            Ring
        }
        enum Rarity
        {
            Normal,
            Uncommon,
            Rare
        }
        class Item
        {
            public ItemType ItemType;
            public Rarity Rarity;
        }
        static List<Item> _items = new List<Item>(); //인벤토리

        //게임 내에서 인벤토리에 어떠한 것이 있는지 알아야할 때가 많다. 무기가 무엇인지 휘귀도는 무엇인지 등등등
        //이때 그냥 각각의 용도에 맞는 함수를 만들수도 있다
        static Item FindWeapon()
        {
            foreach(Item item in _items)
            {
                if (item.ItemType == ItemType.Weapon) { return item; }
            }
            return null;
        }
        //매우 무식한 방법이다. 얼마나 많은 함수가 필요할지 모른다

        //delegate를 활동할 수 있다

        delegate bool ItemSelector(Item item);
        static Item FindItem(ItemSelector selector)
        {
            foreach(Item item in _items)
            {
                if (selector(item)) { return item; }
            }
            return null;
        }
        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }
        //조금 더 코드가 간편해졌다
        //조금 아쉽다, 여기에 적지 않은 함수 디테일을 어디에는 적긴 해야한다



        //그런데 Delegate에 Generic을 같이 사용할 수 있다.

        delegate Return MyFunc<T, Return>(T item);
        //오버로딩? 도 가능하다

        delegate Return MyFunc<T1, T2, Return>(T1 t1, T2 t2);
        delegate Return MyFunc<Return>();


        //그런데 C#에서는 위의것들을 이미 만들어놨다!!!
        //바로 Func

        
        //그런데 Func는 언제나 반환값이 있다.
        //반환값이 필요 없을때에는 Action을 사용한다.


        static Item FindItem2(MyFunc<Item, bool> myFunc)
        {
            foreach(Item item in _items)
            {
                if (myFunc(item)) { return item; }
            }
            return null;
        }



        
        static void Main(string[] args)
        {

            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            Console.WriteLine("Hello World!");

            Item item = FindItem(IsWeapon); //delegate버젼


            //Lambda식은 아니고 무형 함수, 또는 익명 함수라고 한다. 함수의 이름이 없기 때문. 영어로는 Anonymous Function이라고 한다.
            Item item2 = FindItem(delegate (Item item) { return item.ItemType == ItemType.Weapon; });


            //근데 이것도 어차피 적긴 적어야하네
            //Generic을 이용해서 적절하게 코드를 재사용할 수 있을까?


            //저것도 너무 길어서 더 짧게 만드는 문법을 만들었다
            //Lambda 식
            Item item3 = FindItem((Item item) => { return item.ItemType == ItemType.Weapon; });

            //그렇다고 Lambda식을 반드시 일회용으로만 사용해야하는것은 아니다.

            ItemSelector itemSelector = new ItemSelector(IsWeapon); //Delegate를 클래스처럼 호출하기 (복습)

            ItemSelector itemSelector1 = new ItemSelector(delegate (Item item) { return item.ItemType == ItemType.Weapon; }); //Anonymous Function 버전

            ItemSelector itemSelector2 = new ItemSelector((Item item) => { return item.ItemType == ItemType.Weapon; });//Lambda 버전


            //generic을 같이 사용하여 범용성을 높인 버전

            MyFunc<Item, bool> itemSelectorGeneric = new MyFunc<Item, bool>(IsWeapon);
            MyFunc<Item, bool> itemSelectorGeneric1 = new MyFunc<Item, bool>(delegate (Item item) { return item.ItemType == ItemType.Weapon; });
            MyFunc<Item, bool> itemSelectorGeneric2 = new MyFunc<Item, bool>((Item item) => { return item.ItemType == ItemType.Weapon; });


            MyFunc<Item, bool> itemSelectorGeneric3 = (Item item) => { return item.ItemType == ItemType.Weapon; }; //new 부분은 없어도 된다.
            FindItem2(itemSelectorGeneric3);




            //Func 를 사용해보자

            Func<Item, bool> itemSelectorFunc = (Item item) => { return item.ItemType == ItemType.Weapon; }; //이말은 우리가 직접 delegate를 사용하지 않아도 된다는 말


            //Action을 사용해부자
            Action<Item> itemSetter = (Item item) => { item.ItemType = ItemType.Weapon;  };
        }
    }
}
