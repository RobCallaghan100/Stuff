properties {
	$testMessage = 'Executed Test!'
  	$compileMessage = 'Building solution $solutionFile'
  	$cleanMessage = 'Executed Clean!'

	$solutionDirectory = (Get-Item $solutionFile).DirectoryName
	$outputDirectory = "$solutionDirectory\.build"
	$temporaryOutputDirectory = "$outputDirectory\temp"

	$buildConfiguration = "Release"
	$buildPlatform = "Any CPU"
}


FormatTaskName "`r`n`r`n----------- Executing {0} Task ---------"

task default -depends Test


task Init -description "Initialises the build by removing previous artifacts and creating output directories" -requiredVariables outputDirectory, temporaryOutputDirectory  {

	Assert ("Debug", "Release" -contains $buildConfiguration) `
		"Invalid build configuration '$buildConfiguration'. Valid id values are 'Debug' or 'Release'"

	Assert ("x86", "x64", "Any CPU" -contains $buildPlatform) `
		"Invalid build platform '$buildPlatform'. Valid id values are 'x86' or 'x64' or 'Any CPU'"

	# remove previous build results
	if (Test-Path $outputDirectory){
		Write-Host "Removing output directory located at $outputDirectory"
		remove-Item $outputDirectory -Force -Recurse
	}

	Write-Host "Creating output directory located at ..\builds"
	New-Item $outputDirectory -ItemType Directory | Out-Null

	Write-Host "Creating temporary directory located at $temporaryOutputDirectory"
	New-Item $temporaryOutputDirectory -ItemType Directory | Out-Null
}


task Clean -description "Remove temporary files" { 
  Write-Host $cleanMessage
}

 
task Compile `
	-depends Init `
	-description "Compile the code" `
	-requiredVariables solutionFile, buildConfiguration, buildPlatform, temporaryOutputDirectory `
{ 
	Write-Host $compileMessage
	Exec { 
		msbuild $solutionFile "/p:Configuration=$buildConfiguration;Platform=$buildPlatform;OutDir=$temporaryOutputDirectory" 
	}
}

 
task Test -depends Compile, Clean -description "Run unit tests" { 
  Write-Host $testMessage
}

