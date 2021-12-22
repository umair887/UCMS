#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Student Managment System/Student Managment System.csproj", "Student Managment System/"]
RUN dotnet restore "Student Managment System/Student Managment System.csproj"
COPY . .
WORKDIR "/src/Student Managment System"
RUN dotnet build "Student Managment System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Student Managment System.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student Managment System.dll"]