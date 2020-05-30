"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Tres.Products.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
