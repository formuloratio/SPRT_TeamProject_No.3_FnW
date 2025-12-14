# 게임명: Fire & Water
<img width="1590" height="893" alt="스크린샷 2025-12-14 230457" src="https://github.com/user-attachments/assets/1eea222e-55b0-4c50-8596-711734faf6fb" />

## 📑 목차
1. [프로젝트 장르 및 소개](#프로젝트-장르-및-소개)
2. [주요기능](#주요기능)
3. [역할분담](#역할분담)
4. [구현내용](#구현내용)
5. [트러블슈팅](#트러블슈팅)
6. [기술스택](#기술스택)
7. [사용에셋 목록](#사용에셋-목록)

---

## 👨‍🏫 프로젝트 장르 및 소개

<table>
  <tr>
    <th align="left" width="180"> 항목 </th>
    <th align="left" width="500"> 내용 </th>
  </tr>
  <tr><td> 장르 </td><td> 2인용 협동 퍼즐 탈출 </td></tr>
  <tr><td> 소개 </td><td> Fire And Water를 모티브로 만들어보는 게임  </td></tr>
  <tr><td> 개발 기간 </td><td> 총 8일 { 2025.10.29 ~ 2025.11.05 } </td></tr>
</table>

* [저장소 원본 링크](https://github.com/formuloratio/Fire_AND_Water)

---

## 🔧 주요기능
### 게임플레이
- 1번과 2번 키를 눌러서 물 속성 플레이어와 불 속성 플레이어 교체 가능.
- 플레이어 속성에 따라 파괴할 수 있는 장애물(벽)과 지나갈 수 있는 장애물(바닥)이 존재.
- 플레이어가 알맞는 속성의 스위치를 킬 수 있으며, 스위치에 따라 엘리베이터가 움직이거나 장애물이 사라짐.
- 위의 조건들을 이용하여 모든 플레이어가 최상단의 문에 접근하면 게임 클리어.
- 스테이지는 총 3단계가 있으며 게임을 클리어 하면 다음 스테이지로 나아가는 방식.
  
[스테이지 1]
<img width="1594" height="893" alt="스크린샷 2025-12-14 230514" src="https://github.com/user-attachments/assets/1149bf0c-e622-460c-ac47-e7942a48db44" />
<img width="1595" height="895" alt="스크린샷 2025-12-14 230611" src="https://github.com/user-attachments/assets/3b63dd92-d112-43de-8bb7-230f2dd1c4f3" />
<img width="1592" height="891" alt="스크린샷 2025-12-14 230632" src="https://github.com/user-attachments/assets/71ef0792-97ae-4823-a749-859bde17500a" />
  
[스테이지 2]
<img width="1592" height="890" alt="스크린샷 2025-12-14 230645" src="https://github.com/user-attachments/assets/b5ba24a0-115a-4243-868e-fde87233ddbc" />
<img width="1592" height="892" alt="스크린샷 2025-12-14 230704" src="https://github.com/user-attachments/assets/6b7a1185-7a8c-4f8a-992c-00cd652ec162" />
  
[스테이지 3]
<img width="1592" height="891" alt="스크린샷 2025-12-14 230758" src="https://github.com/user-attachments/assets/fb17f53e-b5e1-46f8-89a6-b8910111f15a" />
<img width="1593" height="893" alt="스크린샷 2025-12-14 230851" src="https://github.com/user-attachments/assets/9e615370-fad6-4c42-b0c7-69f69b5fb256" />


### 핵심기술
- GameManager 에서 게임 실행의 전반적인 구동을 담당.
- DataService 에서 플레이어의 클리어 정보 저장을 담당.
- AchievementManager 에서 플레이어 클리어 정보를 데이터(업적)화 및 불러오기를 담당.
- AudioManager 에서 게임의 BGM, SFX, 출력을 담당.
- DataService 에서 플레이어의 클리어 정보 저장을 담당.
- SceneTrasitionManager 에서 게임 스테이지 신의 전환을 담당.
- PlayerController 에서 Player 캐릭터의 선택을 담당.
- BaseController 에서 Player 캐릭터의 움직임을 담당.
- AnimationHandler 에서 Player 캐릭터의 애니메이션 출력을 담당.
- PopupManager 에서 UI의 종류별로 출력을 담당.
- InteractionObject 에서 필드 오브젝트들과의 상호작용을 담당.

---


## 🧰 역할분담

<table>
  <tr>
    <th align="left" width="180"> 이름 </th>
    <th align="left" width="500"> 역할 </th>
  </tr>
  <tr><td> 엄성진 </td><td> 맵 디자인, 스테이지 난이도, 장애물 기능 </td></tr>
  <tr><td> 안건우 </td><td> 타이틀 구성, 업적, 사운드 </td></tr>
  <tr><td> 유원영 </td><td> 튜토리얼 설명, 플레이어 조작 </td></tr>
  <tr><td> 김동관 </td><td> 타임어택, UI 전반 </td></tr>
</table>

---

## 🖥️ 구현내용 [엄성진]


### 스크립트
---

---

## ⏲️ 트러블슈팅

### 캐릭터가 일정 범위 이상 벗어나면 투사체가 생성 즉시 사라지는 버그
* 문제 :
  * Update() 문에서 float maxRangeSqr = rangeWeaponHandler.AttackRange 처럼 투사체의 최대 유효거리를 설정하고 if 문으로 투사체의 현재 위치가 maxRangeSqr 보다 크면 오브젝트가 파괴되도록 설정되어있었다.
  * 발사체의 초기위치 값이 투사체가 생성된 위치가 기점이 아니라 캐릭터가 처음 생성된 위치가 기점으로 되어있었고 이를 해결하기 위해서는 투사체가 처음 생성된 위치 값을 가지고 유효 범위를 다시 계산했어야 했다.
* 해결 :
  * 위치라는 벡터 값을 가지고 float인 유효 거리를 계산하려다 보니 주어진 시간 상으로는 구현이 어렵다고 판단하여, 투사체의 유효 거리를 지정하는 방식이 아닌 투사체가 생성된 후 시간(1초)에 따라 파괴되도록 만들어서 해결하였다.

---


## 🧩 기술스택

<table>
  <tr>
    <th align="left" width="180"> 구분 </th>
    <th align="left" width="500"> 기술 </th>
  </tr>
  <tr>
    <td>Language</td>
    <td><img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"></td>
  </tr>
  <tr>
    <td>Framework</td>
    <td><img src="https://img.shields.io/badge/unity-FFFFFF?style=for-the-badge&logo=unity&logoColor=black"></td>
  </tr>
  <tr>
    <td>IDE</td>
    <td><img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white"></td>
  </tr>
  <tr>
    <td>Version Control</td>
    <td><img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white"></td>
  </tr>
  <tr>
    <td>Design</td>
    <td><img src="https://img.shields.io/badge/Figma-F24E1E?style=for-the-badge&logo=figma&logoColor=white"></td>
  </tr>
  <tr>
    <td>Documentation</td>
    <td><img src="https://img.shields.io/badge/Notion-000000?style=for-the-badge&logo=notion&logoColor=white"></td>
  </tr>
</table>

---

## 🚀 사용에셋 목록

<table>
  <tr>
    <th align="left" width="180"> 항목 </th>
    <th align="left" width="500"> 내용 </th>
  </tr>
  <tr><td> 맵 타일셋 </td><td> [Free Topdown Fantasy - Forest - Pixelart Tileset] (https://aamatniekss.itch.io/topdown-fantasy-forest) </td></tr>
  <tr><td> 그 외 </td><td> AI </td></tr>
</table>

