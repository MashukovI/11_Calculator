# ���������� ������� ����� � ASP.NET 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# ������������� ������� ���������� ������ ����������
WORKDIR /app

# ���������� SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# �������� ����� � ���������
COPY . /src

# ������������� ������� ���������� ������ ����������
WORKDIR /src

# ������������� ����������� ���������� � ��������� ����������
RUN ls
RUN dotnet restore
RUN dotnet build "./11_Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./11_Calculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./

# ���������� ������� ������� ����������
ENTRYPOINT ["dotnet", "11_Calculator.dll"]
