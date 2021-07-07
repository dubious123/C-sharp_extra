using System;

namespace exception
{
    class Program
    {
        //커스텁 타입 Exception
        class TextException : Exception
        {

        }

        static void TestFunc()
        {
            throw new TextException();
        }
        static void Main(string[] args)
        {
            //1. 0으로 나눌 때
            //2. 잘못된 메모리 참조 (null)
            //3. 오버플로우

            //근데 게임을 만들 때 이것이 과연 필요한가? 
            //어차피 밑에것은 땜방이다
            //코드가 잘못됬다는 것은 이미 재앙
            //보통은 크래시가 나면 그냥 나게 냅두고 고친다

            //치명적이지는 않지만 그냥 사소한 예외는 받아서 처리할 수도 있다.
            try
            {
                int a = 10;
                int b = 0;
                int result = a / b; //이 아래는 실행이 안됨

                int c = 0;
            }
            catch (DivideByZeroException e) //특수한 상황 오류
            {

            }
            catch (Exception e) //Excoption은 모든 오류상황의 조상님
            {
                
            }
            //예외와 상관없이 이것은 무조건
            finally
            {
                //근데 에러가 나서 엉망인데 뭘 또 챙겨
                //근데 파일 입출력 관리할 때에는 에러가 나도 해야할 것은 있을 수 있어

            }

            //이렇게 커스템 예외를 만들 수 있다
            try
            {
                TestFunc(); // 함수 안에서 에러가 나도 catch한다.
            }
            catch (TextException e)
            {

            }
            finally
            {

            }
        }
    }
}
