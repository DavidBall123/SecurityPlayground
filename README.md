# SecurityPlayground
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest


# Persist data - local
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=localPassword@01' -p 1433:1433 -v D:\Mounts\SQL\SecurityPlayground\data:/var/opt/mssql/data -v D:\Mounts\SQL\SecurityPlayground\log:/var/opt/mssql/log -v D:\Mounts\SQL\SecurityPlayground\secrets:/var/opt/mssql/secrets -d mcr.microsoft.com/mssql/server:2022-latest

#  ef migrations 
dotnet ef migrations add initialDb
dotnet ef database update