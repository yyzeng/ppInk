@echo on
time /t
set projDir=%1
set projDir=%projDir:"=%
set msBuildDir=%2
set msBuildDir=%msBuildDir:"=%
C:\Windows\System32\xcopy.exe /s /Y /I "%projDir%\ppink" "%projDir%\ppinkS\"
rem for /f "tokens=* USEBACKQ" %%f in (`dir c:\Windows\Microsoft.NET\Framework64\msbuild.exe /b /s ^|find "v4"`) do set var=%%%f
set Path="%msBuildDir%";%Path%
set command=msbuild.exe "%projDir%\ppInk.sln" /t:Rebuild /p:outDir="%projDir%\ppinks" /p:DefineConstants=ppInkSmall /p:PreBuildEvent= /p:PostBuildEvent= 
echo "command : " %command%
call %command%
echo Script Done
