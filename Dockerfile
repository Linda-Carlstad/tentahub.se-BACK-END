FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
RUN mkdir /app
COPY . /app
RUN cd /app && \
    dotnet build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS DevServer
RUN mkdir /app
COPY --from=builder /app /app
WORKDIR /app
RUN dotnet dev-certs https --trust
CMD ["dotnet", "run", ""]