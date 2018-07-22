FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app/login

# copy csproj and restore as distinct layers
COPY WebAPI/*.sln ./WebAPI
COPY WebAPI/WebAPI/*.csproj ./WebAPI/WebAPI
RUN dotnet restore

# copy everything else and build app
COPY ./ ./
RUN dotnet publish -c Release -o out

#
#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
#WORKDIR /app
#COPY --from=build /app/login/out ./
#ENTRYPOINT ["dotnet", "WebAPI.dll"]
