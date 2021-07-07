using System;

namespace Event
{
    class Program
    {
        static void OnInputTest()
        {
            Console.WriteLine("  Input Received");
        }
        //delegate함수를 개나소나 다 호출하는 상황을 해결하기 위한 event
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;  // 구독신청
            inputManager.InputKey -= OnInputTest; // 구독 취소
            inputManager.InputKey += OnInputTest;  // 구독신청


            while (true)
            {
                inputManager.Update(); // a키를 누르면 알림이 간다
            }

            // inputManager.InputKey(); 이렇게 선언할 수 없다 --> 장점
        }
    }
}
