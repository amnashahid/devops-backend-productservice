

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80/tcp
#ENV ASPNETCORE_URLS=http://*:80
WORKDIR /app
COPY binpublish/ .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]