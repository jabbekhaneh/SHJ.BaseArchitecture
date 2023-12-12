#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Prsentation/SHJ.BaseArchitecture.Web.API/SHJ.BaseArchitecture.Web.API.csproj", "src/Prsentation/SHJ.BaseArchitecture.Web.API/"]
COPY ["src/Libraries/SHJ.BaseArchitecture.Application/SHJ.BaseArchitecture.Application.csproj", "src/Libraries/SHJ.BaseArchitecture.Application/"]
COPY ["src/Libraries/SHJ.BaseArchitecture.Application.Contracts/SHJ.BaseArchitecture.Application.Contracts.csproj", "src/Libraries/SHJ.BaseArchitecture.Application.Contracts/"]
COPY ["src/Libraries/SHJ.BaseArchitecture.Infrastructure/SHJ.BaseArchitecture.Infrastructure.csproj", "src/Libraries/SHJ.BaseArchitecture.Infrastructure/"]
COPY ["src/Libraries/SHJ.BaseArchitecture.Shared/SHJ.BaseArchitecture.Shared.csproj", "src/Libraries/SHJ.BaseArchitecture.Shared/"]
COPY ["src/Libraries/SHJ.BaseArchitecture.Domain/SHJ.BaseArchitecture.Domain.csproj", "src/Libraries/SHJ.BaseArchitecture.Domain/"]
RUN dotnet restore "src/Prsentation/SHJ.BaseArchitecture.Web.API/SHJ.BaseArchitecture.Web.API.csproj"
COPY . .
WORKDIR "/src/src/Prsentation/SHJ.BaseArchitecture.Web.API"
RUN dotnet build "SHJ.BaseArchitecture.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SHJ.BaseArchitecture.Web.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SHJ.BaseArchitecture.Web.API.dll"]