using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day10_OOP
{
    #region OOP 요약
    /**
    # 객체지향과 클래스 
    ## 객체 vs Class vs Instance
        * 객체 : Object (개념)
        * Class : 객체를 만들 수 있는 설계도 (틀)
        * Instance : Class를 가지고 실제 객체를 생성한 결과물 (생성물)

        ---

    ## 객체지향(OOP)
        **1. 캡슐화(Uncapsulation)**
            구현 자체를 외부에 보이지 않게 하는 것
            단, 입출력의 부분은 외부에 보인다. 구현부는 보이지 않는다.

           >정보은닉 
            공개되지 않아야할 내용을 숨겨두게 하는 것.
            외부에 공개해도 될 내용인 경우는 공개.
            (접근 지시자: public, private, protected)

        **2. 상속화(Inheritance)**
            하위 객체가 상속받은 상위 객체에서 정의된 (필드/메서드)을 재활용해서 
            반복적인 코드를 최소화하고 공유하는 속성과 기능에 간편하게 접근합니다.
            단일상속을 기본으로 한다.

        **3. 추상화(Abstraction)**
            객체의 중요한 부분을 강조하기 위해 공통적인 속성과 기능을 추출하고 
            불필요한 세부 사항들은 제거,객체의 가장 본질적이고 공통적인 부분만을 표현합니다.

           >부모를 정의하는 시점에서 자식을 어떻게 변화 될지 파악할 수 없으므로
            부모에서는 선언만을 두는 형태 -> c에서는 순수 가상함수로 정의.
           > 
            (순수가상함수를 포함한 클래스 = 추상클래스)
            * 특징 : 객체화 불가, 상속받은 자식에서도 재정의 하지 않았다면 그 자식 또한 추상 클래스.
                    부모에 정의 되어있지 않은 기능을 재정의 하는 것.

        **4. 다형성(Polymorphism)**
            이름과 같이 객체의 속성이나 기능이 상황에 따라 여러 가지 형태를 가질 수 있는 성질입니다.
            
           >오버로딩(함수 중복 정의) - 같은 이름의 함수에 매개변수에 따라 다른 함수가 작동되는 것.
            오버라이딩(함수 재정의) - 함수를 자식클래스에서 재정의 하는것이 오버라이딩

            ---

    ## SOLID 원칙
        **1. 단일 책임 원칙**(**S**RP)
            책임을 분리한다. (클래스 하나는 자신의 역활만을 담당)
        **2. 개방 폐쇄 원칙**(**O**CP)
            확장에는 열려있고 변경에는 닫혀있음.(기능을 변경x, 상속이나 랩핑으로 둘러싼다)
        **3. 리스코프 치환 원칙**(**L**SP)
            자식class는 부모class자리에 대체 가능.(자식은 부모의 책임을 넘지 않음)
        **4. 인터페이스 분리 원칙**(**I**SP)
            인터페이스를 통해서 객체를 분리.(지나친 일반화(공통기능)를 경계)
        **5. 의존관계 역전 원칙**(**D**SP)
            인터페이스를 주어서 의존성의 관계를 역전 시키겠다. (커플링 해제시키려고 사용)

            ---

    ## 메모리
        ### 메모리 구조
            프로그램을 수행하기 위해 운영체제로부터 메모리(RAM)공간을 할당 받는다.
            메모리의 구조는 4가지로 구분된다. 
            **Code, Data, Heap, Stack**으로 나뉘며 위에서부터
            낮은 주소(low address)를 가지게 되고 아래로 갈수록 높은 주소(high address)를 가진다

            ** * 코드(Code)영역**
                프로그램의 코드가 저장되는 영역이며 소스코드가 들어가는 부분이다.
                함수, 제어문, 상수 등 실행파일을 구성하는 명령어가 저장된다.
                프로그램이 종료할때까지 메모리가 유지된다.(데이터가 변경되지 않는 읽기 전용 데이터)

            ** * 데이터(Data)영역**
                프로그램의 공용영역으로 불리며 전역변수, static변수, 문자열 상수가 저장되는 영역이다.
                프로그램 시작과 동시에(컴파일 시점) 할당되어 프로그램이 종료되기 전 까지 메모리가 있다.

            ** * 힙(Heap)영역 - " FIFO(선입선출) "**
                프로그래머가 관리할 수 있는 공간이며, malloc 함수와 new연산자를 통해 동적 할당을 진행하고 free와 delete를 이용하여 할당된 메모리를 해제를 할 수 있다.
                프로그램이 실행될때(런타임) 크기를 지정되어지며 종료 후 지정된 메모리는 사라진다.

                C#의 경우 참조 형식이 추가되는 메모리 공간이며, 참조 형식의 변수는 스택영역과 힙영역을 동시에 이용하는데, 스택영역에는 데이터의 주소를, 힙영역에는 데이터의 값을 저장한다.
                C#에서는 가비지 컬렉터가 주기적으로 힙을 청소하여 사용자 대신 메모리 관리를 한다..

            ** * 스택(Stack)영역 - " LIFO(후입선출) "**
                프로그램이 자동으로 사용하는 임시 메모리 영역이며, 함수 호출 시 생성되는 지역변수와 매개 변수가 저장되는 영역이고 스택의 크기는 컴파일 과정시 크기가 지정된다.
                스택영역의 할당의 경우 함수의 호출시 할당 되고 함수가 종료되면 사라진다.
                스택 영역에 저장되는 함수의 호출 정보를 스택 프레임(stack frame)이라고 한다.

                #### Heap vs Stack
                    힙과 스택은 같은 공간을 사용한다. 
                    이 때문에 문제가 발생하는데 
                    서로의 영역을 침범하게 되면 "over flow"가 발생한다.
                    공간이 이미 비어있는데 또 빼내가려고 하면 "under flow"가 발생한다.
                    다만, 이제는 용어가 변경이 되었기에 둘 다 "over flow"로 사용하면 맞다.

                ---

        ### 값 타입 vs 참조 타입
            C#의 메모리 할당에는 값 타입과 참조 타입으로 나뉜다.

            | '값타입(value type)' | '참조타입(reference type)' |
            |---|---|
            | 기본 변수, 구조체, 열거형 | Class, 배열, delegate, 인터페이스 등|
            | Stack에 직접 저장 | Heap에 주소값 저장 |
            | 값을 복사해서 독립적(깊은 복사) | 주소를 참조하기에 공유 된다.(얕은 복사) |
            | 상속 불가 | 상속 가능|

            ---

        ### class의 선언
            구조체와 만드는 것이 비슷하다.
           
           >필드 : 해당 클래스가 가지고 있는 변수들.
            메서드 : 해당 클래스가 가지고 있는 함수들.
            프로퍼티(property) : get, set 함수들. 

     */
    #endregion
    internal class Program
    {

        #region 과제 1.
        class Character()
        {
            public int level;
            public float Hp { get; set; }
            public float Speed { get; set; }
            public float Atk { get; set; }
            public bool bHit { get; set; }
            public float Dir { get; set; }

            public void MoveForward(float dir)
            {
                if(dir > 0)
                    Console.WriteLine($"{Speed} * {dir} 전진한 모습");
                else
                    Console.WriteLine($"{Speed} * {dir} 후진한 모습");
            }
            public void MoveRight(float dir)
            {
                if (dir > 0)
                    Console.WriteLine($"{Speed} * {dir} 오른쪽으로 이동한 모습");
                else
                    Console.WriteLine($"{Speed} * {dir} 왼쪽으로 이동한 모습");
            }
            private void Hitted(string name)
            {
                if (!bHit)
                    Console.WriteLine($"{name}의 회피한 모습");
                else
                    Console.WriteLine($"{name}의 공격당한 모습");
            }
            public void TakeDamage(string name, float damage) 
            {
                Hp -= damage;

                Hitted(name);
                Console.WriteLine($"{name}은 {damage}의 데미지를 입었다.");

                if (Hp<=0)
                    Console.WriteLine($"{name} 죽은 모습");
            } 
        }
        #endregion

        #region 과제 2.
        class Player : Character
        {
            public string name;

            public Player(string name)
            {
                this.name = name;
            }
        }

        class Monster : Character
        {
            public string name;

            public Monster(string name)
            {
                this.name = name;
            }
        }
        #endregion

        #region 과제 3.
        class CharacterManager()
        {
            public Player player = new Player("게임매니저 용사");
            public Monster monster = new Monster("게임매니저 몬스터");
        }
        #endregion

        #region 과제 2. _ 과제 3.
        static void Main(string[] args)
        {
            Player player = new Player("용사");
            Monster monster = new Monster("몬스터");
            CharacterManager characterManager = new CharacterManager();

            //과제 2
            player.Hp = 100.0f;
            player.level = 1;
            player.Speed = 300.0f;
            player.Atk = 30.0f;
            player.bHit = false;

            monster.Hp = 500.0f;
            monster.level = 10;
            monster.Speed = 100.0f;
            monster.Atk = 60.0f;
            monster.bHit = true;

            player.TakeDamage(player.name, monster.Atk);
            monster.TakeDamage(monster.name, player.Atk);

            //과제 3
            characterManager.player.Hp = 200.0f;
            characterManager.player.level = 2;
            characterManager.player.Speed = 400.0f;
            characterManager.player.Atk = 40.0f;
            characterManager.player.bHit = false;

            characterManager.monster.Hp = 600.0f;
            characterManager.monster.level = 20;
            characterManager.monster.Speed = 200.0f;
            characterManager.monster.Atk = 70.0f;
            characterManager.monster.bHit = true;

            characterManager.player.TakeDamage(characterManager.player.name, characterManager.monster.Atk);
            characterManager.monster.TakeDamage(characterManager.monster.name, characterManager.player.Atk);

        }
        #endregion
    }


}
