﻿cls

# '[p]sake' is the same as 'psake' but $Error is not polluted
remove-module [p]sake

# find psake's path
$psakeModule = (Get-ChildItem (".\packages\psake*\tools\psake.psm1")).FullName | Sort-Object $_ | select -last 1
 
Import-Module $psakeModule

Invoke-psake -buildFile .\builds\default.ps1 `
	-taskList Test `
	-framework 4.5.2 `
	-properties @{ 
		"buildConfiguration" = "Release" 
		"buildPlatform" = "Any CPU"} `
	-parameters @{"solutionFile" = "..\psake.sln" }

Write-Host "Build exit code:" $LASTEXITCODE

# propogates exit code so that build fails when there is a problem
exit $LASTEXITCODE

