using System;

namespace nullable
{
    class Program
    {
        // 클랠스는 애초에 참조타입이라서 null이 가능하다.
        // int 같은것은 null을 할 수 없어
        // 0을 null처럼 약속해서 사용할 수는 있지만 어거지이다.
        class Monster
        {
            public int id { get; set; }
        }
        static Monster FindMonster(int id)
        {
            return null;
        }


        static int Find()
        {
            return 0;
        }
        static void Main(string[] args)
        {
            Monster monster = FindMonster(101);
            if(monster != null)
            {

            }

            //Nullable
            int? number = null;
            number = 3;
            // int a = number; 이것은 아됨
            int a = number.Value;  //이건 됨
            number = null;
            // int b = number.Value; 이렇게 하면 프로그램이 뻗음

            if(number != null)
            {

            }// 이런식으로 체크하거나

            if (number.HasValue)
            {

            }//등등 다양한 방법으로 체크를 해야함





            //좀더 편리하게

            int c = number ?? 0; // number가 value가 있다면 그 값을 넣고 아니면 초기값 0를 넣어라
            int b = (number.HasValue) ? number.Value : 0; //이것과 비슷한듯





            Monster monster1 = null;
            if (monster != null)
            {
                int monsterid = monster.id;
            }


            int? id = monster1?.id; //monster가 널이면 널, 아니면 id값을 넣으세요

            //?? , ?.
        }
    }
}
