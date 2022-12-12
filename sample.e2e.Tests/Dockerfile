FROM mcr.microsoft.com/playwright/dotnet:v1.28.0-focal
ARG DOTNET_CONFIGURATION=Release
ARG DOTNET_TARGET=net6.0
ARG DOTNET_RUNTIME=linux-x64

RUN rm -rf /var/lib/apt/lists/*

ENV DEBIAN_FRONTEND=noninteractive

WORKDIR /app
COPY bin/${DOTNET_CONFIGURATION}/${DOTNET_TARGET}/${DOTNET_RUNTIME}/publish/ /app
COPY run-analysis.sh /app

ENTRYPOINT [ "/bin/bash", "/app/run-analysis.sh" ]
