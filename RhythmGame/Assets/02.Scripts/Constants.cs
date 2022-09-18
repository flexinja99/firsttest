public static class Constants    // public : 모든곳에서 접근가능 ,static : data 영역에 저장되기때문에 클래스 객체를 만들필요가 없다 주로 게임전체의 수를 제한하거나, 알고 싶을때 주로 이용함,
                                 // class :  개체지향 프로그래밍에서 개체를 만드는데 필수적인 설계도와 같음 EX):
                                 // 파란색글자 :
                                 // 키워드(예약어)란 ? 미리 정의되어있는 단어
                                 // 이미 문법용도로 사용되고있기때문에 식별용으로 개발자가 쓸 수 없다.
                                 //
                                 // 흰글자 :
                                 // 식별문자 (참조 있음, 명시적 표현)
                                 //
                                 // 청록색글자 :
                                 // 클래스 타입 식별문자(이름)
                                 //
                                 // 노란색글자 :
                                 // 함수 식별문자(이름)
                                 //
                                 // 하늘색글자 :
                                 // 함수의 파라미터 (매개변수) 의 식별문자(이름)
                                 //
                                 // 주황색글자:
                                 // 문자/ 문자열 상수
                                 //
                                 // 글자색이 어둡다면 :
                                 // (참조 없음 / 생략 가능 == 암시적 표현),
                                 // Constants : 상수


{
    public const float HIT_JUDGE_RANGE_BAD = 3.0f;  //const : 상수화, float : 실수형
    public const float HIT_JUDGE_RANGE_MISS = 2.0f;
    public const float HIT_JUDGE_RANGE_GOOD = 1.5f;
    public const float HIT_JUDGE_RANGE_GREAT = 1.0f;
    public const float HIT_JUDGE_RANGE_COOL = 0.5f;

    public const int SCORE_BAD = 0;  //int : 정수형
    public const int SCORE_MISS = 0;
    public const int SCORE_GOOD = 100;
    public const int SCORE_GREAT = 200;
    public const int SCORE_COOL = 300;
}