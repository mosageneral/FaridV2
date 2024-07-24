FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/FaridV2.Web.Host/FaridV2.Web.Host.csproj", "src/FaridV2.Web.Host/"]
COPY ["src/FaridV2.Web.Core/FaridV2.Web.Core.csproj", "src/FaridV2.Web.Core/"]
COPY ["src/FaridV2.Application/FaridV2.Application.csproj", "src/FaridV2.Application/"]
COPY ["src/FaridV2.Core/FaridV2.Core.csproj", "src/FaridV2.Core/"]
COPY ["src/FaridV2.EntityFrameworkCore/FaridV2.EntityFrameworkCore.csproj", "src/FaridV2.EntityFrameworkCore/"]
WORKDIR "/src/src/FaridV2.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/FaridV2.Web.Host", "src/FaridV2.Web.Host"]
COPY ["src/FaridV2.Web.Core", "src/FaridV2.Web.Core"]
COPY ["src/FaridV2.Application", "src/FaridV2.Application"]
COPY ["src/FaridV2.Core", "src/FaridV2.Core"]
COPY ["src/FaridV2.EntityFrameworkCore", "src/FaridV2.EntityFrameworkCore"]
WORKDIR "/src/src/FaridV2.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "FaridV2.Web.Host.dll"]
