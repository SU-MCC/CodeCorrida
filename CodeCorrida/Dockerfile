FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

COPY ["CodeCorrida.Web/CodeCorrida.Web.csproj", "CodeCorrida/"]
RUN dotnet restore "CodeCorrida/CodeCorrida.Web.csproj"

COPY . .
WORKDIR "/src/CodeCorrida"
RUN dotnet publish "CodeCorrida.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT='Docker'
ENV ASPNETCORE_URLS='http://+:80'
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED='true'

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeCorrida.Web.dll"]
