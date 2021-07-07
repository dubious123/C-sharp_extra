using System;
using System.Collections.Generic;

namespace Interface
{
    //오버로딩 : 함수 이름 재사용
    //오버라이딩 : virtual, override, 만들어진 class가 부모인지, 자식인지, 어떤 자식인지등을 체크해서 해당 함수를 실행, c#문법: shield: 나까지만 상속, 나 밑은 이거 쓰지마
   
    
    //너가 몬스터라면 shout를 반드시 오버라이팅해서 사용해야해! 이렇게 강요하고 싶을 때 --->abstract
    // Monster는 생성 불가능 ex) new Monster() 불가능 abstract 클래스 안에서는 abstract 매서드 정의 가능
    //이 때 abstract 함수는 정의만 해야지 그 안에 무언가를 넣을 수 없다. 즉 {}이거 하면 X abstract는 virtual 대신 사용




    //날아다니는 오크를 만들자! 오크는 몬스터와 비행을 상속받는다. 이때 다중상속? C++은 사능, C#은 불가능
    //다중상속의 단점 = 죽음의 다이아몬드 다중상속하는 두 클래스에 같은 함수가 있을 때 어떤것을 실행할 지 모름 ex) 스캘래톤 오크


    // 해결책: interface i이름 (i는 그냥 관습), 그 안의 함수들은 그냥 반환인자만 표현해준다.
    // 나를 상속받는 아이들은 이러이러한 함수들(인터페이스)가 구현되어 있어야 하지만 어떻게 구현하는것은 너의 자유야

    // 인터페이스 클래스는 다중 상속해도 문제가 없다!
    abstract class Monster
    {
        public abstract void Shout();


    }
    interface iFlyable
    {
        void fly();
    }
    
    class Orc : Monster
    {
        public override void Shout()
        {
           
            Console.WriteLine("록타르 오가르!");
        }
    }
    class flyableOrc : Orc, iFlyable
    {
        public void fly()
        {

        }
    }
    class Skelleton : Monster
    {
        public override void Shout()
        {

            Console.WriteLine("꾸에엑!");
        }
    }
 

    class Program
    {
        static void DoFly(iFlyable Flyable) //iflyable인터페이스를 가진 것들만 올 수 있다
        {
            Flyable.fly();
        }
        static void Main(string[] args)
        {
            iFlyable flyable = new flyableOrc();  //이렇게 선언 가능, 

            DoFly(flyable); // 가능

            flyableOrc orc1 = new flyableOrc();
            DoFly(orc1);

            List<int> mylist ;
        }
    }
}
