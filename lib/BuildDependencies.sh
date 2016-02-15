xbuild ./Net35Essentials/Net35Essentials.sln /p:Configuration=Release /p:Platform="Any CPU"
mkdir -p Dependency\ Builds/Net35Essentials/DLLs/
rsync -avv ./Net35Essentials/src/Net35Essentials/bin/Release/ Dependency\ Builds/Net35Essentials/DLLs/

chmod +x ./GladBehaviour/lib/BuildDependencies.sh
cd GladBehaviour/lib/
./BuildDependencies.sh
cd ..
nuget restore GladBehaviour.sln
xbuild GladBehaviour.sln /p:Configuration=Release /p:Platform="Any CPU"
cd ..

mkdir -p Dependency\ Builds/GladBehaviour/DLLs/
rsync -avv ./GladBehaviour/src/GladBehaviour.Common/bin/Release/ Dependency\ Builds/GladBehaviour/DLLs/
rsync -avv ./GladBehaviour/src/GladBehaviour.Editor/bin/Release/ Dependency\ Builds/GladBehaviour/DLLs/

