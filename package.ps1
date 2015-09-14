# Settings
$source = "C:\projects\c#\Multiprocessing.Scratch\Multiprocessing.Scratch\bin\Debug"
$destination = "C:\projects\c#\Multiprocessing.Scratch\Multiprocessing.Scratch\bin\Debug.zip"
$deploy = "E:\projects\mono\Multiprocessing.Scratch\Debug.zip"

# Check for existing file
if (Test-path $destination) { rm $destination }

# Zip it up
Add-Type -assembly "System.IO.Compression.FileSystem"
[io.compression.zipfile]::CreateFromDirectory($source, $destination)

# Copy to the deployment folder
if (Test-path $deploy) { rm $deploy }

cp $destination $deploy

#Clean up
rm $destination