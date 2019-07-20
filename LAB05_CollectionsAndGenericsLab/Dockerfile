FROM mono:5.18.1.0
ADD . /src
WORKDIR /src
RUN nuget restore -source "https://www.nuget.org/api/v2" ./CollectionsAndGenerics/CollectionsAndGenerics.sln
RUN msbuild /p:Configuration=Release ./CollectionsAndGenerics/CollectionsAndGenerics.sln
CMD ["mono", "./CollectionsAndGenerics/packages/xunit.runner.console.2.4.1/tools/net471/xunit.console.exe", "./CollectionsAndGenerics/CollectionsAndGenerics.Test/bin/Release/CollectionsAndGenerics.Test.dll" ]