# Bad VR Design Demo

## Overview
A Unity VR application that deliberately demonstrates poor VR design practices. Each scene or interaction showcases a specific anti-pattern — motion sickness triggers, confusing affordances, inaccessible UI — to help students recognise and avoid them in their own projects.

## Problem It Solves
- VR design principles are easier to internalise through hands-on experience of bad design than through reading guidelines alone
- Educators need a ready-made artefact students can put on a headset and immediately feel why certain design choices fail
- Target users: VR/XR design students and educators; originally created for Oulu University

## Use Cases
1. A student puts on a headset and immediately experiences locomotion-induced motion sickness — making the concept tangible in under 30 seconds
2. An instructor walks a class through each bad-design scenario, pausing to discuss what design rule is being broken and how to fix it
3. A developer uses the project as a reference checklist of common VR mistakes to audit against their own builds

## Key Features
- Multiple bad-design scenarios covering common VR pitfalls
- Intentionally uncomfortable interactions to make design failures visceral and memorable
- Provided as a Unity project so educators can modify or extend the scenarios

## Tech Stack
- **Engine**: Unity (Universal Render Pipeline)
- **Language**: C#
- **Target platform**: PC VR (OpenXR / SteamVR compatible headsets)

## Getting Started

### Prerequisites
- Unity 2022.3 LTS or newer with the **XR Interaction Toolkit** package installed
- A PC VR headset (e.g. Meta Quest via Link, Valve Index, HTC Vive)

### Running the project
1. Clone the repository
2. Open the project in Unity Hub
3. Connect your VR headset
4. Open any scene from the `Assets/` folder and press **Play**

> This project is free for educational use. No warranty provided. Commercial use is not permitted.

**Created for Oulu University — June 2025**
