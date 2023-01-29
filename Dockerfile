FROM mcr.microsoft.com/dotnet/sdk:7.0 as builder

WORKDIR /.
COPY ./API/ ./API/
COPY ./Application/ ./Application/
COPY ./Domain/ ./Domain/
COPY ./Persistence/ ./Persistence/
COPY ./FunBooksAndVideos.sln ./FunBooksAndVideos.sln



WORKDIR /.
RUN dotnet restore

WORKDIR /API
RUN dotnet publish -c Release -o /out API.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0

EXPOSE 80
WORKDIR /app
ENTRYPOINT [ "dotnet", "/app/API.dll" ]

COPY --from=builder /out/ .
