FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем solution и все проекты
COPY *.sln .
COPY CodeCorrida.*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

# Восстанавливаем зависимости
RUN dotnet restore

# Копируем весь исходный код
COPY . .

# Публикуем приложение
RUN dotnet publish CodeCorrida.Web/CodeCorrida.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT='Docker'
ENV ASPNETCORE_URLS='http://+:80'
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED='true'

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CodeCorrida.Web.dll"]
