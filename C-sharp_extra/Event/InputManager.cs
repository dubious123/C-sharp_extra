using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    //Observer Pattern
    //사용자가 키보드나 마우스를 조작하는것을 캐치하는 클래스
    class InputManager
    { 
        public delegate void OninputKey();

        //이벤트
        public event OninputKey InputKey;   //처음 delegate와 은닉 레벨을 맞춰줘야 한다.
        public void Update()
        {
            if (Console.KeyAvailable == false) { return; }
            //뭔가 입력되었다
            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                //모드에게 A가 입력되었음을 알려준다! ---> 어떻게 만들까? 
                InputKey(); //구독신청을 한다.
            }
        }
    }
}
