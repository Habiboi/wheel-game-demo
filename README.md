# Lucky Wheel Game - Senior Case Study

This project is a high-performance, data-driven "Lucky Wheel" game developed for a Senior Game Developer case. The architecture focuses on **scalability**, **clean code principles**, and **optimization**.

## 🚀 Key Features

* **Data-Driven Architecture:** All wheel configurations, zone rules, and rewards are managed via `ScriptableObjects`.
* **Weighted Random System:** Implemented a custom weighted probability algorithm for reward distribution, allowing fine-tuned game economy control.
* **Event-Driven Design:** Decoupled logic and UI using a central `EventManager` (Observer Pattern).
* **UI Optimization:** * Automated reference binding with `OnValidate`.
    * Optimized `TextMeshPro` updates using `StringBuilder`.
    * Non-blocking UI animations with `DOTween`.
* **Dynamic Visuals:** Automatic color and theme switching based on the current Zone Type (Normal, Safe, Super).

## 🏗 Architectural Decisions

### 1. Data Management (ScriptableObjects)
Instead of hardcoding game rules, I used a hierarchical SO structure to ensure the game is fully modular.



* **WheelSliceData:** Defines individual reward types and their base amounts.
* **WheelPresetData:** Defines the "look and feel" (colors, sprites) and the specific reward pool (Weighted List) for zones.
* **ZoneRuleData:** Controls the overall game flow logic (e.g., defining when Safe or Super zones appear).

### 2. Weighted Probability Selection
To satisfy the "Senior" requirement for game balance, I implemented a **Weighted Random Algorithm** in `Extensions.cs`. This allows designers to set "weights" for each reward within a specific preset, enabling the creation of rare "Grand Prizes" or frequent "Common Rewards" without any code changes.

### 3. Automated UI Referencing
To minimize human error and speed up the design process, I utilized `OnValidate` to automatically find and assign UI references (Images, Buttons, Texts) following a strict naming convention (`ui_image_...`, `_value`).

## 🛠 Tech Stack & Tools
* **Unity 6000.2.14+**
* **DOTween:** For smooth, performant UI animations and wheel spinning.
* **TextMeshPro:** For high-quality, dynamic text rendering.
* **Git:** Clean commit history with descriptive messages.

## 📱 Aspect Ratio & Optimization
The UI is built with **Unity UI (UGUI)** using responsive anchors and pivots.
* **Tested Ratios:** 20:9 (Tall), 16:9 (Standard), and 4:3 (Tablet).
* **Performance:** Unnecessary `Raycast Target` flags are disabled on static images and texts to reduce the GPU/CPU overhead during Canvas Rebuilds.

---

## 📦 How to Test
1.  **Clone the Repo:** `git clone [YOUR_GITHUB_URL_HERE]`
2.  **Unity Version:** Open the project with Unity 2022.3.x.
3.  **Run:** Open `MainScene` and press Play.
4.  **APK:** You can find the latest build in the [Releases](../../releases) section of this repository.

---

## 💡 Extra Notes for the Reviewer
* **Scalability:** You can add a new "Jackpot Zone" by simply creating a new `WheelPresetData` asset and adding it to the `ZoneRuleData` list. **Zero code changes required.**
* **Memory Management:** Used `StringBuilder` for the Zone Counter to prevent memory allocation (GC pressure) during rapid UI updates.
* **Leave Logic:** Implemented a "Leave" mechanism that allows players to safely exit with their rewards at appropriate zones, as per the requirements.
