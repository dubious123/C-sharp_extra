using System;
using System.Reflection;

namespace Reflection
{

    //Reflection X-Ray, 런타임 내에 어떤 클래스의 모든것을 뜯어볼 수 있게 한다.
    partial class Program
    {
        class Monster
        {
            //hp 입니다, 중요한 정보입니다 ===> 이것은 사람끼리의 대화, 컴퓨터는 몰라
            [Important("Very Important")]
            public int hp;
            protected int attack;
            float speed;

            void Attack() { }
        }

        //Attribute  ---> 컴퓨터가 런타임에 알 수 있게하는 주석

        public class Important : System.Attribute
        {
            string message;
            public Important(string message) { this.message = message; }
        }
        class Monster2
        {
            [Important("Very Important")]
            public int hp;
            protected int attack;
            float speed;

            void Attack() { }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Monster monster = new Monster();
            //object라는 최상위 클래스에 이미 구현되어있는 것
            Type type =  monster.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);
            
            foreach(FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic) { access = "public"; }
                else if (field.IsPrivate) { access = "Private"; }
                //attribute
                var attribute =  field.GetCustomAttributes();
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
