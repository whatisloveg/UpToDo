FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY UpToDo.sln . 
COPY UpToDo.Hosts/UpToDo.Hosts.csproj UpToDo.Hosts/
COPY UpToDo.Application/UpToDo.Application.csproj UpToDo.Application/
COPY UpToDo.Infrastructure/UpToDo.Infrastructure.csproj UpToDo.Infrastructure/
COPY UpToDo.Domain/UpToDo.Domain.csproj UpToDo.Domain/
COPY UpToDo.Contracts/UpToDo.Contracts.csproj UpToDo.Contracts/

RUN dotnet restore

COPY . .
WORKDIR "/src/UpToDo.Hosts"
RUN dotnet publish -c Release -o /app/publish --no-restore --self-contained false /p:PublishTrimmed=true /p:UseAppHost=true


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UpToDo.Hosts.dll"]
