using System;
using ObjCRuntime;

[assembly: LinkWith ("libOneSignal.a",LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true
	,Frameworks="SystemConfiguration",LinkerFlags="-ObjC")]
