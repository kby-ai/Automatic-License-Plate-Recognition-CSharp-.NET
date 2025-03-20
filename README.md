# Automatic-License-Plate-Recognition-C#

<p align="center">
  <a href="https://play.google.com/store/apps/dev?id=7086930298279250852" target="_blank">
    <img alt="" src="https://github-production-user-asset-6210df.s3.amazonaws.com/125717930/246971879-8ce757c3-90dc-438d-807f-3f3d29ddc064.png" width=500/>
  </a>  
</p>

### Our facial recognition algorithm is globally top-ranked by NIST in the FRVT 1:1 leaderboards. <span><img src="https://github.com/kby-ai/.github/assets/125717930/bcf351c5-8b7a-496e-a8f9-c236eb8ad59e" alt="badge" width="36" height="20"></span>  
[Latest NIST FRVT evaluation report 2024-12-20](https://pages.nist.gov/frvt/html/frvt11.html)  

![FRVT Sheet](https://github.com/user-attachments/assets/16b4cee2-3a91-453f-94e0-9e81262393d7)

#### 🆔 ID Document Liveness Detection - Linux - [Here](https://web.kby-ai.com)  <span><img src="https://github.com/kby-ai/.github/assets/125717930/bcf351c5-8b7a-496e-a8f9-c236eb8ad59e" alt="badge" width="36" height="20"></span>
#### 🤗 Hugging Face - [Here](https://huggingface.co/kby-ai)
#### 📚 Product & Resources - [Here](https://github.com/kby-ai/Product)
#### 🛟 Help Center - [Here](https://docs.kby-ai.com)
#### 💼 KYC Verification Demo - [Here](https://github.com/kby-ai/KYC-Verification-Demo-Android)
#### 🙋‍♀️ Docker Hub - [Here](https://hub.docker.com/u/kbyai)
### Documentation

# Automatic-License-Plate-Recognition-C#
## Overview

This repository demonstrates  `ANPR/ALPR(Automatic Number/License Plate Recognition)` SDK C#.Net version with unmatched accuracy and precision by applying `SOTA(State-of-the-art)` deep learning techniques. </br>
`KBY-AI`'s `LPR` solutions utilizes artificial intelligence and machine learning to greatly surpass legacy solutions. Now, in real-time, users can receive a vehicle's plate number through `API`.
> We can customize the `SDK` to align with customer's specific requirements.
> 
The `ALPR` system consists of the following steps:
- Vehicle image capture
- Preprocessing
- Vehicle detection
- Number plate extraction
- Charater segmentation
- Optical Character Recognition(OCR) </br>

The `ALPR` system works in these strides, the initial step is the location of the vehicle and capturing a vehicle image of front or back perspective of the vehicle, the second step is the localization of Number Plate and then extraction of vehicle Number Plate is an image. The final stride uses image segmentation strategy, for the segmentation a few techniques neural network, mathematical morphology, color analysis and histogram analysis. Segmentation is for individual character recognition. Optical Character Recognition (OCR) is one of the strategies to perceive the every character with the assistance of database stored for separate alphanumeric character.


### ◾License Plate Recognition SDK Product List
  | No.      | Repository | SDK Details | Status |
  |------------------|------------------|------------------|------------------|
  | 1        | [LPR - Linux](https://github.com/kby-ai/Automatic-License-Plate-Recognition-Docker)    | License Plate Recognition Linux SDK | Available |
  | 2        | [LPR - Docker](https://hub.docker.com/r/kbyai/license-plate-recognition)    | License Plate Recognition Docker Image | Available |
  | 3        | [LPR - Flutter](https://github.com/kby-ai/Automatic-License-Plate-Recognition-Flutter)    | License Plate Recognition Flutter SDK | Available |
  | ➡️        | <b>[LPR - C#](https://github.com/kby-ai/Automatic-License-Plate-Recognition-CSharp-.NET)</b>    | <b>License Plate Recognition C# SDK</b> | <b>Available</b> |
  | 5        | [LPR - Android](https://github.com/kby-ai/Automatic-License-Plate-Recognition-Android)    | License Plate Recognition Android SDK | Available |
  | 6        | LPR - iOS    | License Plate Recognition iOS SDK | Developing |

> To get more products, please visit products [here](https://github.com/kby-ai):<br/>

## Try the API
To try `KBY-AI` `ALPR` online, please visit [here](https://web.kby-ai.com/)
## Screenshot
> Please click on `Open` button and choose a image file to see the performance.
  ![image](https://github.com/user-attachments/assets/0e5f7989-ee7c-4ddf-98cd-71c568429eeb)

## SDK License
This project demonstrates `KBY-AI`'s `License Plate Recognition Server SDK`, which requires a license per machine.</br>
- To use the latest update, plesae contact `KBY-AI` team.</br>
- To request the license, please provide us with the `machine code` obtained from the `getMachineCode` function.</br>
- Ensure you copy the `license.txt` file to the `bin/Debug/net8.0-windows` folder, as shown in the image below:</br>
 ![image](https://github.com/user-attachments/assets/66f4ad73-a418-4a59-9722-1854180fdb76)

#### Please contact us:</br>
🧙`Email:` contact@kby-ai.com</br>
🧙`Telegram:` [@kbyai](https://t.me/kbyai)</br>
🧙`WhatsApp:` [+19092802609](https://wa.me/+19092802609)</br>
🧙`Discord:` [KBY-AI](https://discord.gg/CgHtWQ3k9T)</br>
🧙`Teams:` [KBY-AI](https://teams.live.com/l/invite/FBAYGB1-IlXkuQM3AY)</br>

## Performance Video

You can visit our YouTube video for `ANPR/ALPR` model's performance [here](https://www.youtube.com/watch?v=sLBYxgMdXlA) to see how well our demo app works.</br></br>
[![ANPR/ALPR Demo](https://img.youtube.com/vi/sLBYxgMdXlA/0.jpg)](https://www.youtube.com/watch?v=sLBYxgMdXlA)</br>

## Application of ALPR
`Automatic license-plate recognition (ALPR)` is a technology that uses `OCR(optical character recognition)` on images to read vehicle registration plates. It can use existing closed-circuit television, road-rule enforcement cameras, or cameras specifically designed for the task. ALPR can be used by police forces around the world for law enforcement purposes, including to check if a vehicle is registered or licensed. It is also used for electronic toll collection on pay-per-use roads and as a method of cataloguing the movements of traffic, for example by highways agencies.</br>
`ALPR` has many uses including:
- Recovering stolen cars
- Identifying drivers with an open warrant for arrest
- Catching speeders by comparing the average time it takes to get from stationary camera A to stationary camera B
- Determining what cars do and do not belong in a parking garage
- Expediting parking by eliminating the need for human confirmation of parking passes
