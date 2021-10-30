#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/VanhackTest.Web.Host/VanhackTest.Web.Host.csproj", "src/VanhackTest.Web.Host/"]
COPY ["src/VanhackTest.Web.Core/VanhackTest.Web.Core.csproj", "src/VanhackTest.Web.Core/"]
COPY ["src/VanhackTest.Application/VanhackTest.Application.csproj", "src/VanhackTest.Application/"]
COPY ["src/VanhackTest.Core/VanhackTest.Core.csproj", "src/VanhackTest.Core/"]
COPY ["src/VanhackTest.EntityFrameworkCore/VanhackTest.EntityFrameworkCore.csproj", "src/VanhackTest.EntityFrameworkCore/"]
RUN dotnet restore "src/VanhackTest.Web.Host/VanhackTest.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/VanhackTest.Web.Host"
RUN dotnet build "VanhackTest.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VanhackTest.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VanhackTest.Web.Host.dll"]