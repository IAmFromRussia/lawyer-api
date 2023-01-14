FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lawyer-Api/Lawyer-Api.csproj", "Lawyer-Api/"]
RUN dotnet restore "Lawyer-Api/Lawyer-Api.csproj"
COPY . .
WORKDIR "/src/Lawyer-Api"
RUN dotnet build "Lawyer-Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lawyer-Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lawyer-Api.dll"]
