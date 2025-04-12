# Flutter CLI - Model Context Protocol Server

## Overview

This project provides a server implementation for the Flutter CLI using the Model Context Protocol (MCP). It allows developers to create flutter project with specified platforms.

## Getting Started

### Prerequisites

- .NET SDK 9.0 or later
- Flutter SDK

### Running The Server

- Clone this repository
- Open the project in VS Code
- Build the project using `dotnet build` command
- Configure VS Code or other MCP client by adding below details

```json
        "fluttercli": {
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "FlutterCliMcpServer/FlutterCliMcpServer.csproj",
                "--no-build"
            ]
        }
```

- Update the path of the project

### Features

The server exposes two tools that can be invoked by client.

#### Available Tools

- **CreateFlutterProjectForSpecifiedPlatforms**: Create flutter project with specified project name for specified platforms.
- **CreateFlutterProject**: Create flutter project with specified project name for all platforms
