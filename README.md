# SecurityPlayground
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest


# Persist data
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 -v D:\Mounts\SQL\SecurityPlayground\data:/var/opt/mssql/data -v D:\Mounts\SQL\SecurityPlayground\log:/var/opt/mssql/log -v D:\Mounts\SQL\SecurityPlayground\secrets:/var/opt/mssql/secrets -d mcr.microsoft.com/mssql/server:2022-latest