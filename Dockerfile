FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings__HolidayConnectionMssql="Server=ENVSERVER;Initial Catalog=public-holidays-db;User ID=ENVID;Password=ENVPW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV DB_Server="tcp:public-holidays.database.windows.net,1433"
ENV DB_User="ad_mediapark"
ENV DB_Password="G47jYP7RtUbHJa"
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["public-holidays/public-holidays.csproj", "public-holidays/"]
RUN dotnet restore "public-holidays/public-holidays.csproj"
COPY . .
WORKDIR "/src/public-holidays"
RUN dotnet build "public-holidays.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "public-holidays.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "public-holidays.dll"]
