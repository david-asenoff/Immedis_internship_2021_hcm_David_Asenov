#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HCM.Web/HCM.Web.csproj", "HCM.Web/"]
COPY ["HCM.Services/HCM.Services.csproj", "HCM.Services/"]
COPY ["HCM.Web.ViewModels/HCM.Web.ViewModels.csproj", "HCM.Web.ViewModels/"]
COPY ["HCM.Data.Common/HCM.Data.Common.csproj", "HCM.Data.Common/"]
COPY ["HCM.Data.Models/HCM.Data.Models.csproj", "HCM.Data.Models/"]
COPY ["HCM.Data/HCM.Data.csproj", "HCM.Data/"]
RUN dotnet restore "HCM.Web/HCM.Web.csproj"
COPY . .
WORKDIR "/src/HCM.Web"
RUN dotnet build "HCM.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HCM.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HCM.Web.dll"]