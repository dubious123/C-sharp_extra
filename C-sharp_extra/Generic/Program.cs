using System;

namespace Generic
{
    class Program
    {
        class MyLIst
        {
            object[] arr = new object[10]; // 속도가 느리다
        }









        class MyList2<T> //Generic, 클래스 일반화
        {
            T[] arr = new T[10];
            public T GetItem(int i)
            {
                return arr[i];
            }
        }

        class Monster
        {

        }

        static void Test<T>(T input) // Generic 함수 일반화
        {

        }
        static void Test2<T, K>(T input1, K input2) //일반화 여러개
        {

        }



        class MyClass<T, S, K, R> where T : Monster where S : new() where K : struct where R : class  //Generic 조건추가 , struct: 값, class: 참조, new(): 어떠한 기본인자도 받지 않는 생성자
        {

        }
        class MyClass2<T> where T : Monster // T: 몬수터, 또는 몬스터를 상속받은 ex) slime, skeleton, 등등등 
        {

        }

        class TestClass<T> where T : class
        {
            T me;
            
        }


        static void Main(string[] args)
        {
            var var1 = 3;
            var var2 = "Hello";     //속도가 빠르다, stack, 복사타입


            object obj = 3;       //속도가 느리다, 참조타입, heap에 메모리를 할당하여 3을 넣고 그것의 참조값을 가져와야함
            object obj2 = "Hello world";
            int num = (int)obj;           //string, int 등등은 모두 object를 상속받아서 사용중, 즉 object는 최상위 부모 클래스이다.
            string str = (string)obj2;






            MyList2<int> myIntList = new MyList2<int>();
            MyList2<Monster> myMonsterList = new MyList2<Monster>();







            TestClass<Monster> testClass = new TestClass<Monster>();
        }
    }
}
