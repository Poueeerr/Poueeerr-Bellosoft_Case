Requisitos
- PostgreSql
- .NET 8.0
- API KEY de https://gnews.io
  
Criar .env na root
```bash
# String de conexão do PostgreSQL
ConnectionStrings__DefaultConnection=Host=localhost;Port=5432;Database=bellosoft;Username=postgres;Password=2005

ApiSettings__ApiKey=SUA_API_KEY_AQUI
```

Executar ```dotnet restore``` para baixar as dependencias 

Executar ```dotnet run```
