#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gdc.Api/Gdc.Api.csproj", "Gdc.Api/"]
COPY ["Gdc.Domain/Gdc.Domain.csproj", "Gdc.Domain/"]
COPY ["Gdc.Ioc/Gdc.Ioc.csproj", "Gdc.Ioc/"]
COPY ["Gdc.Application/Gdc.Application.csproj", "Gdc.Application/"]
COPY ["Gdc.Features/Gdc.Features.csproj", "Gdc.Features/"]
COPY ["Gdc.Data/Gdc.Data.csproj", "Gdc.Data/"]
RUN dotnet restore "Gdc.Api/Gdc.Api.csproj"
COPY . .
WORKDIR "/src/Gdc.Api"
RUN dotnet build "Gdc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gdc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gdc.Api.dll"]