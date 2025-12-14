# 프로젝트 이름 Fire & Water (Dungeon)

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [주요기능](#주요기능)
3. [개발기간](#개발기간)
4. [기술스택](#기술스택)
5. [와이어프레임](#와이어프레임)
6. [프로젝트 파일 구조](#프로젝트-파일-구조)
7. [Trouble Shooting](#trouble-shooting)


## 👨‍🏫 프로젝트 소개
- 프로젝트 명 : Fire & Water (Dungeon)
- 프로젝트 설명 : '극' 내향인들끼리 모여서 만든 협력퍼즐 탐험게임
- 프로젝트 시작 계기 : Unity를 활용해서 3가지의 모티브 게임 중 하나를 선택해서 만들게 됨.
- 프로젝트 팀원
    - 팀장 : 엄성진
    - 팀원 : 안건우
    - 팀원 : 김동관
    - 팀원 : 유원영

## 💜 주요기능

- 기능 1
    - GameManager 에서 게임 실행의 전반적인 구동을 담당

- 기능 2
    - DataService 에서 플레이어의 클리어 정보 저장을 담당

- 기능 3
    - AchievementManager 에서 플레이어 클리어 정보를 데이터(업적)화 및 불러오기를 담당

- 기능 4
    - AudioManager 에서 게임의 BGM, SFX,  출력을 담당

- 기능 5
    - DataService 에서 플레이어의 클리어 정보 저장을 담당
    
- 기능 6
    - SceneTrasitionManager 에서 게임 스테이지 신의 전환을 담당        

- 기능 7
    - PlayerController 에서 Player 캐릭터의 선택을 담당

- 기능 8
    - BaseController 에서 Player 캐릭터의 움직임을 담당

- 기능 9
    - AnimationHandler 에서 Player 캐릭터의 애니메이션 출력을 담당

- 기능 10
    - PopupManager 에서 UI의 종류별로 출력을 담당

- 기능 11
    - InteractionObject 에서 필드 오브젝트들과의 상호작용을 담당


## ⏲️ 개발기간
- 총 8일   { 2025.10.29(수) ~ 2025.11.05(수) }


### 🖥️ Language
*  C#


### 🔧 Version Control
*  Git + GitHub


### 🧩 IDE
* Visual Studio


### 🧰 Framework
* net9.0


### 🚀 배포 (Deploy)
- **빌드 환경:** Unity 2022.3.62f2
- **배포 방식:** 
- **결과물:** 

---
## 와이어프레임

<img width="960" height="540" alt="내향인 모임 ppt (3)" src="https://github.com/user-attachments/assets/a866025f-01bc-42cd-83e5-fdd8253d76e6" />


---
### 와이어프레임_초기

https://drive.google.com/file/d/1BGSdvtFrzQ0QccxZEe-LLJn0-wriQG4D/view

---
## 프로젝트 파일 구조

📦Assets

 📂Animations
 
 📂Obstacle
 
     📂Player
     
        📂Player_Dwarf
        📂Player_Elf
        📂Player_Physics
        📂Player_Switch_Icon
        
    📂Switch
    
📂Editor

    📜BootstrapSceneLoader.cs
    
📂Map_Pallete

📂Prefabs

    📂Interaction
    📂Player
    📂Trap
    📂UI
    
 📂Resources
 
     📂AudioAsset
     
         📂Player
         
     📂ImageAsset
     
         📂frames
         
             📂Map
             
         📂TitleImages
         
     📂ScriptableObjects
     
         📂Achievements
         
             📜Clear_Equal_1.asset
             📜Clear_Equal_2.asset
             📜Clear_Equal_3.asset
             📜Death_ Equal_1.asset
             📜Death_Equal_10.asset
             📜Death_Equal_2.asset
             📜Get_Rank_A.asset
             📜Get_Rank_B.asset
             📜Get_Rank_S.asset
             
 📂Scenes
 
     📜AchievementScene.unity
     📜GamePlayScene_Stage1.unity
     📜GamePlayScene_Stage2.unity
     📜GamePlayScene_Stage3.unity
     📜Initialization.unity
     📜PopupScene.unity
     📜TitleScene.unity
     
 📂Scripts
 
     📂Core
     
         📜AchievementManager.cs
         📜AudioManager.cs
         📜DataService.cs
         📜GameManager.cs
         📜SceneTransitionManager.cs
         📜SwitchingManager.cs
         
     📂Data
     
         📂ScriptableObjects
         
             📜AchievementData.cs
             
     📂Deprecated
     
         📜Fire.cs
         📜Player.cs
         📜Water.cs
         
     📂Features
     
         📂Controller
         
             📜AnimationHandler.cs
             📜BaseController.cs
             📜PlayerController.cs
             
        📂Entities
        
            📂Interaction
            
                📂Sample
                
                    📂Object
                    
                        📜IElementObject.cs
                        📜IReactiveObject.cs
                        📜MovingElevator.cs
                        📜Obstacle2.cs
                        📜ReactiveObstacle2.cs
                        📜StaticObstacle2.cs
                        📜Switch2.cs
                        
                    📂Player
                    
                        📜Player2.cs
                        📜PlayerController2.cs
                        
                📜Arrow.cs
                📜Bow.cs
                📜Door.cs
                📜Elevator.cs
                📜Hole.cs
                📜InteractionObject.cs
                📜Obstacle.cs
                📜Pitfall.cs
                📜Switch.cs
                📜Trap.cs
                📜Wall.cs
                
            📜Achievement.cs
            
        📂Scene
        
            📜AchievementScene.cs
            📜FollowBackground.cs
            📜GameScene.cs
            📜TitleScene.cs
            
        📂UI
        
            📜GameClearManager.cs
            📜GameOverManager.cs
            📜PopupManager.cs
            📜StageInitializer.cs
            📜TimerUI.cs
            📜TutorialPopup.cs
            
    📂Utils
    
        📜Constants.cs
        📜Enums.cs
        📜JsonSerializer.cs
        📜RuntimeInitializer.cs
        📜SceneLoader.cs
        
📂TextMesh Pro

        📂Documentation
        📂Fonts
        📂Resources
        📂Fonts & Materials
        📂Sprite Assets
        📂Style Sheets
        
    📂Shaders
    
    📂Sprites
    
📂Tiles

---
 ## Trouble Shooting

### 1. 플레이어 관련

<img width="960" height="540" alt="내향인 모임 ppt" src="https://github.com/user-attachments/assets/ec70f127-d9ab-4923-a5c1-1a66522ea975" />
<img width="960" height="540" alt="내향인 모임 ppt (4)" src="https://github.com/user-attachments/assets/fbed0ba6-4207-4600-938b-35b73ffee9c6" />


### 2. 장애물 관련

<img width="960" height="540" alt="내향인 모임 ppt (1)" src="https://github.com/user-attachments/assets/a8079fd1-19c5-413d-b48b-bf972a28fa41" />


### 3. 팝업 관련

<img width="960" height="540" alt="내향인 모임 ppt (2)" src="https://github.com/user-attachments/assets/c4d97656-c37a-422e-b6ce-f9d4d4d85b3a" />

