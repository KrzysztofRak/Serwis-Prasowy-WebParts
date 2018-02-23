Add-PSSnapin Microsoft.Sharepoint.Powershell –EA 0
$path =  "C:\Users\Administrator\Documents\visual studio 2015\Projects\SerwisPrasowy WebParts\SerwisPrasowy WebParts\bin\Debug\SerwisPrasowy_WebParts.wsp"
$name = "SerwisPrasowy_WebParts.wsp"

$siteCollection = "http://devlab.billennium.pl/sites/serwis-prasowy"
$siteCollectionFeatures = @("8cddb0f4-3f70-424a-b1ee-e0d13066264f")

foreach($feature in $siteCollectionFeatures)
{
	Write-Host -f green "`nDISABLE SITE COLLECTION FEATURE: $($feature)`n"
	Disable-SPFeature -Identity $feature -Force -Url $siteCollection -Confirm:$false
}

Write-Host -f green "`nUNINSTALL SOLUTION`n"
Uninstall-SPUserSolution -identity $name –Site $siteCollection -Confirm:$false

#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Uninstall in progress..."
start-sleep -s 5
}


Write-Host -f green "`nREMOVE SOLUTION`n"
Remove-SPUserSolution -identity $name  –Site $siteCollection -Confirm:$false

#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Removing solution in progress..."
start-sleep -s 5
}

Write-Host -f green "`nADD SOLUTION`n"
Add-SPUserSolution -LiteralPath $path -Site $siteCollection -Confirm:$false

Write-Host -f green "`nINSTALL SOLUTION`n"
Install-SPUserSolution -Identity $name –Site $siteCollection -Confirm:$false
 
#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Installing solution in progress..."
start-sleep -s 5
}


foreach($feature in $siteCollectionFeatures)
{
	Write-Host -f green "`nENABLE SITE COLLECTION FEATURE: $($feature)`n" 
	Enable-SPFeature -Identity $feature -Force -Url $siteCollection -Confirm:$false
}

Write-Host -f green "`nRESTARTING SPTimerV4 Service`n" 
restart-service SPTimerV4 -force 

