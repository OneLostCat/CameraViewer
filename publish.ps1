# 删除旧文件
rm "publish\*" -Force -Recurse

# 发布
dotnet.exe publish "CameraViewer\CameraViewer.csproj" -o "publish"

# 删除多余文件
rm "publish\libvlc\win-x86" -Force -Recurse
rm "publish\libvlc\win-x64\*.lib" -Force -Recurse
