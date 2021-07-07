using System;

namespace Delegate
{
    class Program
    {
        //Delegate 대리자

        //업체 사장과 통화를 하고 싶을 때
        //사장님의 비서에게 연락을 해야 한다.
        //우리의 연락처와 용건을 말 하고 거꾸러 사장님이 필요할 때 콜백을 하라고 한다.

        //UI 작업 시 버튼을 눌렀을 때 어떤 행동을 하게 하는 일이 빈번하다 

        static void ButtonPressed(/* 함수 자체를 인자로 넘겨주고 */)
        {
            // 함수를 호출() ---> 콜백 방식
            //어떤 버튼인지 검사하고 그에 따른 함수를 만든다. ---> 조금 힘듬
            //1. 설계적인 문제 : UI에 관련된 로직과 실제 게임 로직에 관련된 코드가 서로 섞인다.
            //2. 현실적인 문제 : 이 안에 있는 코드를 수정할 수 없는 상황이 매우 많다.
            // Console.WriteLine이라는 함수를 우리가 고칠 수는 없다.
            // 어떤 함수가 우리에게 바꿀 수 없는 형태로 제공될 때가 많다.
            // 함수 자체를 인수로 념겨주고 그 함수를 어떤 상황에서 구현되게 만들어주면 매우 아름답다
            // 버튼이 눌렸을 때 행동할 것을 함수로 미리 만들어주고 어떤 버튼이 눌렸을때 그 함수를 인자로 넘겨준다는 것이다
            // 아주 아름답다
            // 우리가 고칠 수 있어도 다양한 규칙으로 동작하는 함수를 만들고 싶을 때에도 매우 유용하다
            //C언어의 함수포인터와 매우 비슷하다
        }








        // 사용 예시

        delegate int OnClicked();  //함수가 아니라 이 이름 자체가 하나의 형식이다 void, int처럼
        //delegate -> 형식은 형식인데, 함수 자체를 인자로 넘겨주는 그런 형식
        // 반환: int, 입력: void, OnClicked가 delegate형식의 이름이다!

        static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }

        // 나중에 위 OnClicked()와 같은 형식의 함수를 하나 만들고

        //우리가 유니티에서 실제적으로 만들어야 하는것
        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }

        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate2");
            return 0;
        }






        //sorting을 할 때에도 사용할 수 있다

        //[10,20,30,40,50]
        //어쩔때에는 내림차수, 어쩔때에는 오름차순
        //비교하는 부분만 delegate로 빼주면 하나의 함수로 다양한 방법으로 작동하게 만들 수 있다


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ButtonPressed(TestDelegate);


            OnClicked clicked = new OnClicked(TestDelegate);  //Onclicked라는 형식의 함수에 내용은 TestDelegate인 함수를 새로 만들어서 clicked라고 하자
            // 위와 Onclicked clicked = TestDelegate;는 내부적으로 동일하다

            //위처럼 delegate 를 class처럼 선언하면 좋은점 : delegate를 chaining? 할 수 있다
            //여러개의 함수를 동시에 넘겨줄 수 있다

            //문제점: 그런데 실행순서가 보통은 chain된 순서이긴 한데 보장된 것은 아니다. 그래서 우회법을 사용해야한다. 
            //예를들어 다른 함수를 만들어서 2>3>1>로 호출하고 +=를 한다거나
            //delegate List를 만들어서 관리하단거나...



            clicked += TestDelegate2;
            ButtonPressed(clicked);









            //delegate의 치명적 단점
            clicked();
            //위처럼 개나소다 다 접근 가능
            //예를들어 위 clicked()는 buttonclicked()안에서만 작동해야 하는데 그 밖에서도 작동하게 됨
            // 그 해결책이 바로 event
        }
    }
}
