The Legned of Viking
===

> Homework for Window Programming class in NCKU CSIE  
> Project Developing Time: Nov 2022 – Dec 2022  
> Author: 郭沛蓉

### Demo Video
[link](https://youtu.be/bHysvyeFgFk)

### Environment 開發環境
* 編輯器版本：Unity 2021.3.13f1
* Windows 平台

### 專案簡介
* 一款以 Unity 開發的 3D 遊戲 (類似 Temple-Run 神廟逃亡)

### How To Use(Play) This Game 玩法說明
* 參考以下遊戲畫面

    <img width="500" src="https://imgur.com/xadkpDU.png" alt="玩法說明 UI"/>

### 功能簡介

#### 已完成功能 (points)
* **Program works normally (total 5%)**
* **Use package (total 5%)**
* **Player have normal behaviors (total 20%)**
    * Use “WASD” to Walk (2%)
        * 使用上下左右鍵也有同樣效果
    * Use “WASD + left shift” to Run (3%)
    * Use “space” to Jump (one jump at the same time), gravity and stand on the ground (5%)
    * Rotate left/right with camera “by mouse movement” (5%)
    * Look up/down without moving the character “by mouse movement“(5%)
        * 範圍在 -20 度 ~ 30 度之間
* **Battle mechanism (total 30%)**
    * Randomly generate emenies on the map (3%)
    * If player and enemy is close enough, enemy will chase player (3%)
    * Both player and enemy can attack each other (5%)
        * 敵人每 2 秒攻擊一次，每次攻擊玩家扣 0.1 血量
        * 玩家點擊滑鼠左鍵攻擊，每次攻擊敵人扣 0.2 血量
    * If enemy is dead, show it’s corpse (5%)
    * If enemy is dead, it drops coins, player can pick it up by press F, and increase the number of coins player have (5%)
        * 獲得金幣後，敵人屍體一同消失
        * 獲得金幣 score 分數 +1
    * UI for player’s health bar and number of coins, health bar for enemy too (7%)
    * If player’s is dead, show end game screen, and can go back to menu (2%)
* **Use Animator on player & enemy (total 15%)**
    * Normal animation, like walk, run, jump (10%)
    * attack animation (5%)
* **Game menu (total 5%)**
    * It can start your game and exit your application (2%)
    * Your game scene has the capability of switching back to your game menu (2%)
        * Q 鍵可暫停遊戲並可選擇返回 Menu
    * An interface in your game to illustrate how to play your game (1%)
        * 參見玩法說明圖片
* **A completed “readme” file to illustrate (total 5%)**
    * Environment
    * How to use (play) your game
    * Your game
    * Bonus
    * Feedback

#### 部分完成功能 (points)
* **Infinite ground spawner (total 20%)**
    * 如下圖所示，當玩家朝 +X 軸方向移動，地板會不斷產生

        <img width="600" src="https://imgur.com/NVvyapi.jpg" alt="Ground Spawner"/>

#### Bonus 加分！！

* **Music (up to 5%)**
    * 音效
        * 走路/跑步
        * 跳躍
        * 玩家攻擊
        * 撿硬幣
        * 滑鼠在按鈕上懸浮
        * 按下按鈕
    * 背景音樂
        * Menu 畫面音樂
        * 遊戲時音樂 (M 鍵可控制靜音)
* **A good game structure design (code) (up to 5%)**
    *  使用 component **"characterController"** 控制玩家/敵人移動

        ```cs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isRun = Input.GetKey(runInput);
        float speed = isRun ? runSpeed : walkSpeed;

        moveDirection = (transform.right * x + transform.forward * z).normalized;
        characterController.Move(moveDirection * speed * Time.deltaTime);
        ```

    * 使用 `LookAt()` 函式控制敵人追蹤玩家

        ```cs
        transform.LookAt(playerTransform);
        characterController.Move(gameObject.transform.forward * speed * Time.deltaTime);
        ```
    * 使用 component **"Event Trigger"** 控制按鈕音效  

        <img src="https://imgur.com/hmKkdAC.jpg" alt="Event Trigger"/>
* **Some special game objects which aren’t mentioned above (up to 5%)**
    * 遊戲場景的搭建使用各種 Prefabs (e.g. 花草樹木、柵欄、樓梯、石階...)
    * 更改 skybox
    * BGM 靜音效果 (M 鍵)
    * 暫停遊戲效果 (Q 鍵)
    * 玩家若掉落地面，遊戲結束

### Feedback 回饋
Unity 本身是很強大的編輯器，使開發者可以快速的完成許多效果，  
然而許多功能我都還沒發現，還需要時間去摸索。  
透過三個星期簡短的課程，我對 Unity 有了一些認識，  
日後有機會也能再精進自我，自學更多相關技術。

2022/12/12