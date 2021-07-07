using System;

namespace Property
{
    //Getter, Setter를 좀더 편리하게 사용하자
    class Program
    {
        //객체지향 -> 은닉성
        class Knight
        {
            public int _hp;
            public int GetHp() { return _hp; }
            public void SetHp(int hp) { _hp = hp; }









            int _mp;

            public int Mp
            {
                get { return _mp; }
                set { _mp = value; }
            }



            int _life;
            public int Life
            {
                get { return _life; }
                private set { _life = value; }
            }



            //자동 구현 프로퍼티

            public int A
            {
                get;set;
            }


            public int B { get; set; } = 100; //선언과 동시에 초기화도 가능
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Knight knight = new Knight();
            knight._hp = 100;
            knight._hp = 41; //이러면 문제 --> 은닉성 , getter, setter --> breakPoint로 누가 언제 데이터에 접근했는지를 쉽게 알 수 있다.
            knight.SetHp(100);
            int current_knightHp = knight.GetHp();


            //getter, setter 1
            knight.Mp = 100;
            int current_knightMp = knight.Mp;


            
        }
    }
}
