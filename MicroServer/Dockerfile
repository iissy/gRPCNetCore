FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY . /publish
WORKDIR /publish

EXPOSE 50088/tcp
CMD ["dotnet", "ASY.Hrefs.MicroServer.dll"]