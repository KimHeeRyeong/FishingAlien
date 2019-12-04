# FishingAlien 
플레이 영상 : [https://www.youtube.com/watch?v=T9LNIpSd838](https://www.youtube.com/watch?v=T9LNIpSd838)  

- [1) 낚시 시스템](https://github.com/KimHeeRyeong/FishingAlien#1-낚시-시스템)
- [2) 외계 생물 패턴](https://github.com/KimHeeRyeong/FishingAlien#2-외계-생물-패턴)
- [3) 맵 생성 및 로드](https://github.com/KimHeeRyeong/FishingAlien#3-맵-생성-및-로드)

## 1) 낚시 시스템

#### - 미끼 선택
[관련 코드]  
[Fishing UI Controller](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/FishingSystem/FishingUIController.cs) : player가 가진 미끼와 그 갯수를 체크해 UI 표시  
![SelectBait](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/FishingSystem/selectBait.gif "Select_Bait")
#### - 낚시 시작
[관련 코드]  
[Fishing](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/FishingSystem/Fishing.cs) : 낚시가 가능할 때(십자표시가 행성에 겹칠때) 스페이스를 누르면 낚시 시작 
![SelectPlanet](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/FishingSystem/selectPlanet2.gif "Select_Planet")
#### - 플레이 및 낚시 종료 
 외계생물을 낚은 경우  
[관련 코드]  
[CheckFishingResult](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/FishingSystem/CheckFishingResult.cs) : 낚시 결과 낚은 외계생물이 있는 경우 안내 출력
![GetEnemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/FishingSystem/GetEnemy.gif "Get_Enemy")  

## 2) 외계 생물 패턴

[관련 코드]  
[Basic Enemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/Enemy/BasicEnemy.cs) : 주변을 돌아다님. 다른 Enemy code의 parent  
![Basic](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/AlienMovingPattern/Basic.gif "Basic")  

[관련 코드]  
[Boss Enemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/Enemy/BossEnemy.cs) : Report 위치 정보를 가짐. Tracking Enemy와 동일한 행동 패턴   
[Report Enemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/Enemy/ReportEnemy.cs) : Boss를 추적함  
![Boss_Report](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/AlienMovingPattern/Boss_Report.gif "Boss_Report")    

[관련 코드]  
[Escape Enemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/Enemy/EscapeEnemy.cs) : 미끼를 피해 도망감  
![Escape](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/AlienMovingPattern/Escape.gif "Escape")  

[관련 코드]  
[Tracking Enemy](https://github.com/KimHeeRyeong/FishingAlien/blob/master/Alien%20Fishing/Assets/Scripts/Enemy/TrackingEnemy.cs) : 미끼를 쫓아감  
![Tracking](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/AlienMovingPattern/Tracking.gif "Tracking")  


## 3) 맵 생성 및 로드
[관련 코드](https://github.com/KimHeeRyeong/FishingAlien/tree/master/Alien%20Fishing/Assets/Scripts/Map): 맵 관련 코드 파일 
#### - Generate Particle  
![ParticleGenerate](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/GenerateLoadMap/ParticleGenerate.gif "Generate Particle")
#### - Load Chunk   
![ChunkLoad](https://github.com/KimHeeRyeong/FishingAlien/blob/master/GIF/GenerateLoadMap/ChunkLoad.gif "Load Chunk")  
