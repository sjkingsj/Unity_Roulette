# 실행 예시

![3 1](https://user-images.githubusercontent.com/87646938/126896968-02e25332-e9c1-46d5-aa88-9a37d6e15501.jpg)

- 실행 화면



![3 2](https://user-images.githubusercontent.com/87646938/126896977-d342db15-ec84-414e-8d32-e22d809d970a.jpg)

- 화면을 누르면 룰렛이 돌아가다 감속한다.





# WEEK3_Unity

## Ch.3 How to Deploy and Move Object

### Roulette

#### 3.1 게임 설계하기

##### 3.1.1 게임 기획하기

- 룰렛 게임



##### 3.1.2 게임 리소스

1. 화면에 놓일 오브젝트 나열
   - 룰렛, 바늘
2. 컨트롤러 스크립트
   - 움직이는 오브젝트 찾기 : 룰렛 컨트롤러
3. 제너레이터 스크립트
   - 플레이할 때 나타나는 오브젝트
4. UI 갱신 감독 스크립트
   - UI를 조작하거나 진행 상황을 판단하는 감독 스크립트
5. 스크립트 흐름
   - 롤러 스크립트 -> 제너레이터 스크립트 -> 감독 스크립트
   - 흐름 : 프로젝트 작성 -> 오브젝트 배치 -> 스크립트 작성 -> 스크립트 적용



#### 3.2 프로젝트 & 씬 만들기

##### 3.2.1 프로젝트 만들기

- File -> New Project -> 템플릿 2D 선택
  - 리소스 추가 : Project 창으로 드래그 & 드롭
  - 실행할 때 화면 표시 설정 : 프레임 맞추기 - VSync 체크



##### 3.2.2 스마트폰용으로 설정

- 빌드 설정 : File -> Build Settings ->Platform(iOS/Android)->Switch Platform
- 화면 크기 설정 : Game -> 스마트폰의 크기로 설정// 흰색 사각형으로 표시된 범위



##### 3.2.3 씬 저장하기

- File -> Save As -> (GameScene)



#### 3.3 씬에 오브젝트 배치

##### 3.3.1 룰렛 배치

- roulette.png 이미지를 Scene 뷰로 드래그&드롭 (스프라이트)
- 오브젝트 위치 조절 : Inspector 탭에서 Position을 0,0,0으로 (중앙 배치)



##### 3.3.2 바늘 배치

- 바늘 이미지를 Scene 뷰로 드래그&드롭
- Position을 0, 3.2, 0으로 배치



##### 3.3.3 배경색 변경

- 카메라 오브젝트의 매개변수 바꾸기
- Main Camera -> Inspector -> Background -> (FBFBF2)





#### 3.4 룰렛 스크립트 작성

##### 3.4.1 스크립트의 역할

- 클릭하면 룰렛을 회전시키되 시간이 흐르면 회전 속도를 점점 줄여 멈추도록
  - 컨트롤러 스크립트



##### 3.4.2 룰렛 스크립트 작성

- Project창 -> Create -> C# Script -> (RouletteController)

  ```c#
  //(RouletteController)
  public class RouletteController : MonoBehaviour
  {
  	float rotSpeed = 0;
  	void Update()
  	{
  		//클릭하면 회전 속도를 설정
  		if (Input.GetMouseButtonDown(0))
  		{
   			this.rotSpeed = 10;
  		}
  
          //회전 속도만큼 룰렛을 회전
  		transform.Rotate(0, 0, this.rotSpeed);
  	}
  }
  
  //transform.Rotate  // Rotate 매서드 -> 오브젝트를 회전
  //Input.GetMouseButtonDown  // 클릭 확인 매서드
  	// 0 : ML, 1 : MR, 2 : Mwheel
  //Input.GetMouseButtonUp  // 손가락 뗀 순간 확인 매서드
  //Input.GetMouseButton  // 클릭 누르고 있는 동안 계속 확인 매서드
  ```





#### 3.5 스크립트를 적용

##### 3.5.1 룰렛에 스크립트 적용하기

- RouletteController 스크립트를 roulette 오브젝트로 드래그&드롭





#### 3.6 룰렛의 회전을 정지시키기

##### 3.6.1 회전 속도를 줄이기

- rotSpeed 값을 조금씩 줄이기 -> 감쇠 계수를 곱하여 줄일 것



##### 3.6.2 룰렛 스크립트 수정

```c#
// (RouletteController) 수정
public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;

    void Start()
	{
        
	}
    
	void Update()
	{
		// 클릭하면 회전 속도 설정
		if (Input.GetMouseButtonDown(0))
		{
 			this.rotSpeed = 10;
		}
        
		// 회전 속도만큼 룰렛 회전
		transform.Rotate(0, 0, rotSpeed);

        // 룰렛 감속
		this.rotSpeed *= 0.96f;
	}
}
```





#### 3.7 스마트폰에서 가동

##### 3.7.1 스마트폰 조작에 대응

- 마우스 왼쪽 클릭 시 동작 -> 화면을 탭했을 때 동작
  - GetMouseButtonbDown 으로 탭이랑 동작 일치



##### 3.7.2 iOS에 빌드

##### 3.7.3 Android에 빌드

- File -> Build Settings -> Player Settings
- Other Settings -> Package Name에 com.원하는이름.roulette
- Scenes/SampleScene 체크 해제, GameScene를 드래그&드롭
- Build & Run 

