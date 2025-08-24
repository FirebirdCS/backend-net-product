# Imagen base en la cual basaremos nuestra imagen
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Exponemos el puerto 80 
EXPOSE 80

# Copiar csproj y restauramos nuestra app
COPY ./*.csproj ./
RUN dotnet restore

# Copiamos todos los archivos y compilamos o contruimos nuestra app
COPY . .
RUN dotnet publish -c Release -o publish

# Que Kestrel escuche en 80 dentro del contenedor
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Construimos o instanciamos nuestro contenedor
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
    #Indicamos el archivo dll compilado (nombre del proyecto)
ENTRYPOINT ["dotnet", "WebApi.dll"]