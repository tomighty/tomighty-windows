param (
    [string]$directory,
    [string]$name
)

Add-Type -Assembly System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($directory, $name, [System.IO.Compression.CompressionLevel]::Optimal, $false)