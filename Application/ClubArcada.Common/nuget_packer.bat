nuget pack ClubArcada.Common.dll.nuspec

@echo off
for /f "delims=" %%x in ('dir /od /b *.*') do set recent=%%x
echo %recent%

nuget push %recent% b7bec0b4-ef4d-467e-860c-f2ea51da6a24 -Source https://www.nuget.org/api/v2/package