taskkill.exe /IM dotnet.exe /t /f

Start-Process "dotnet.exe" "watch" `
    -WorkingDirectory "$PSScriptRoot\src\ODataExperiments.Server" `
    -WindowStyle minimized
