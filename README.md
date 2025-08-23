Requisitos
- PostgreSql
- .NET 8.0
- API KEY de https://gnews.io
  
Criar .env na root
```bash
# String de conexão do PostgreSQL
ConnectionStrings__DefaultConnection=Host=localhost;Port=5432;Database=bellosoft;Username=postgres;Password=2005

ApiSettings__ApiKey=SUA_APIKEY

JWT_KEY=CHAVE_SEGURA_GRANDE
JWT_ISSUER=MeuSistema
JWT_AUDIENCE=MeuSistemaUsuarios
JWT_EXPIRES=60
```

Executar ```dotnet restore``` para baixar as dependencias 

Executar ```dotnet run```
