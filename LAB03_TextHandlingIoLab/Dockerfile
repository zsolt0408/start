FROM mono:5.18.1.0
ADD . /src
WORKDIR /src
RUN nuget restore -source "https://www.nuget.org/api/v2" ./TextAndIOHandling/TextAndIOHandling.sln
RUN msbuild /p:Configuration=Release ./TextAndIOHandling/TextAndIOHandling.sln
CMD ["mono", "./TextAndIOHandling/packages/xunit.runner.console.2.4.1/tools/net471/xunit.console.exe", "./TextAndIOHandling/TextAndIOHandling.Test/bin/Release/TextAndIOHandling.Test.dll" ]