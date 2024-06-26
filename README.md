# Aplib.Net
[![NuGet Version](https://img.shields.io/nuget/v/Aplib.Core)](https://www.nuget.org/packages/Aplib.Core/)
[![GitHub Release](https://img.shields.io/github/v/release/team-zomsa/aplib.net?label=GitHub%20Release)
](https://github.com/team-zomsa/aplib.net/releases)
[![GitHub Issues or Pull Requests](https://img.shields.io/github/issues/team-zomsa/aplib.net)](https://github.com/team-zomsa/aplib.net/issues)
[![GitHub Issues or Pull Requests](https://img.shields.io/github/issues-pr/team-zomsa/aplib.net)](https://github.com/team-zomsa/aplib.net/pulls)
[![GitHub deployments](https://img.shields.io/github/deployments/team-zomsa/aplib.net/github-pages?label=docfx)
](https://team-zomsa.github.io/aplib.net/)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=alert_status)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![SonarCloud Coverage](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=coverage)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=duplicated_lines_density)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=code_smells)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=reliability_rating)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=security_rating)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=sqale_index)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=team-zomsa_aplib.net&metric=vulnerabilities)](https://sonarcloud.io/project/overview?id=team-zomsa_aplib.net)


## Overview
Aplib.Net is a C# re-implementation of the Agent Programming LIBrary (Aplib) for Java.
The Java implementation of Aplib can be found [here](https://github.com/iv4xr-project/aplib) and is licensed to Utrecht University, created under the [iv4XR project](https://iv4xr-project.eu/).

Aplib.Net provides a set of tools for creating automatic playtesting agents for games. It is designed in such a way that it can be used in any game that uses the C# language. Additionally, we provide support for the [Unity game engine](https://unity.com/), due to its large user base.

A demo game, showcasing the functionality of the library, can be found in [this repository](https://github.com/team-zomsa/aplib.net-demo).


## Installation
Aplib.Net is available as a NuGet package or as a simple DLL file, that can then be added as a reference.

Both are available in the [GitHub Release](https://github.com/team-zomsa/aplib.net/releases).

An easier way of installing is also provided using the NuGet Gallery at NuGet.org, which can be found [here](https://www.nuget.org/packages/Aplib.Core/).

### Unity Installation
Unity installation is a bit tricky, but can be done in two ways. The first, and easier way is to install the [NuGet plugin](https://github.com/GlitchEnzo/NuGetForUnity) and import it via NuGet.

For a manual installation, a few steps must be taken. As Unity does not support external libraries in .NET Standard API, the API Compatibility level must be set to `.NET Framework` in Project Settings > Player > Configuration > Api Compatibility Level.

Download the latest DLL from the [GitHub Release](https://github.com/team-zomsa/aplib.net/releases) and place it in Assets/Plugins. In the root of your project, add a new file called `csc.rsp` and add the following line:

```
-r:Assets/Plugins/Aplib.Core.dll
```


## Analysis
We provide analysis metrics using SonarCloud, which can be found [here](https://sonarcloud.io/dashboard?id=team-zomsa_aplib.net).

It provides information on metrics such as the code coverage, code smells and technical debt.


## Documentation
Documentation is automatically generated using Docfx and can be found [here](https://team-zomsa.github.io/aplib.net/).


## Quick Start
A quick start guide can be found in the [GitHub Wiki](https://github.com/team-zomsa/aplib.net/wiki/Quick-Start-Guide).


## Contributing
The contribution guidelines can be found [here](https://github.com/team-zomsa/aplib.net/blob/main/CONTRIBUTING.md).


## License
The project is provided under the BSD 3 License, which can be found [here](https://github.com/team-zomsa/aplib.net/blob/main/LICENSE).