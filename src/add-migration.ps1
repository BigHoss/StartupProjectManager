[CmdletBinding()]
param(
    [String]$Name
)
if([string]::IsNullOrEmpty($Name))
{
    Write-Host "Enter Migration Name and press enter."

    $Name = Read-Host
}
if(![string]::IsNullOrEmpty($Name))
{
    Add-Migration $name -Project StartupProjectManager.Database
}

